using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Diagnostics;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class pInput : MonoBehaviour
{
    public TextMeshProUGUI prompt;
    private TextMeshProUGUI stopwatch;
    public Stopwatch timer = new Stopwatch();

    public PlayerInputActions playerControls;
    private InputAction move;
    private Vector2 movement;
    private string tempTime;

    public GameObject lineStart;
    public GameObject lineEnd;
    private float distanceToEnd;
    private float totalDistance;
    private float startxPos;
    private float lineLength;
    public GameObject finishLinePoint;
    public GameObject placeMarker;

    private musicManage music;
    public AudioSource musicSource;
    public AudioClip fancyMusic;
    public AudioClip orchestraMusic;
    public AudioClip toyMusic;

    private string boatType;
    //public GameObject boatObject;
    public Sprite fancyBoat;
    public Sprite orchestraBoat;
    public Sprite toyBoat;  

    public float r1 = 0.25f;
    public float r2 = 0.75f;
    public float r3 = 1;

    bool alreadyHit;

    public ParticleSystem perfectHit;

    private float totalScore;
    private float tScore;
    private int numScores;
    private string scoreTxt;
    public Sprite upE;
    public Sprite downE;
    public Sprite rightE;
    public Sprite leftE;

    SpriteRenderer currentArrow;

    public GameObject camera;
    private GameObject arrowNear;
    public GameObject[] PathNode;
    //public GameObject pointParent;
    public GameObject Player;
    public float MoveSpeed;
    float Timer;
    static Vector3 CurrentPositionHolder;
    int CurrentNode;
    private Vector2 startPosition;

    private pInput player;
    
    // Use this for initialization
    private void Awake()
    {
        startxPos = placeMarker.transform.position.x;
        placeMarker.transform.position = lineStart.transform.position;
        distanceToEnd = Vector2.Distance(finishLinePoint.transform.position, Player.transform.position);
        totalDistance = distanceToEnd;
        lineLength = lineEnd.transform.position.x - lineStart.transform.position.x; // LENGTH OF MINIMAP LINE
        player = gameObject.GetComponent<pInput>();
        stopwatch = GameObject.FindWithTag("time").GetComponent<TextMeshProUGUI>();
        //music = gameObject.GetComponent<musicManage>();
        playerControls = new PlayerInputActions();
    }
    void Start()
    {
        //PathNode = pointParent.GetComponentsInChildren<Transform>();
        //PathNode = GetComponentInChildren<>();
        timer.Start();
        //StartCoroutine(BeginMove());
        CheckNode();
        /*
        if (PlayerPrefs.GetString("music")!= null) {
            boatType = PlayerPrefs.GetString("music");
        }
        else () {
            boatType = "fancy";
        }
        */
        boatType = PlayerPrefs.GetString("music");
        print(boatType);
        assignMusicBoat();
        music = gameObject.GetComponent<musicManage>();
    }

    void assignMusicBoat() {
        if (boatType == "fancy") {
            print("boat is fancy");
            gameObject.GetComponent<SpriteRenderer>().sprite = fancyBoat;
        }

        if (boatType == "orchestra") {
            gameObject.GetComponent<SpriteRenderer>().sprite = orchestraBoat;
        }

        if (boatType == "toy") {
            gameObject.GetComponent<SpriteRenderer>().sprite = toyBoat;
        }

    }




    void CheckNode()
    {
        Timer = 0;
        startPosition = Player.transform.position;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
    }

    private void OnEnable() 
    {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable()
    {
        move.Disable();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(Vector2.Distance(finishLinePoint.transform.position, Player.transform.position) < distanceToEnd)
        {
            distanceToEnd = Vector2.Distance(finishLinePoint.transform.position, Player.transform.position);
            MoveMarker();
        }

        TimeSpan t = timer.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}", t.Minutes, t.Seconds);
        stopwatch.text = elapsedTime;
        camera.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -10f);
        Timer += Time.deltaTime * MoveSpeed;

        if (Player.transform.position != CurrentPositionHolder)
        {

            Player.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, Timer);
        }
        else
        {
            music.CheckTime();

            if (CurrentNode < PathNode.Length - 1)
            {
                CurrentNode++;
                CheckNode();
            }
        }
    }

    void Update()
    {
        movement = move.ReadValue<Vector2>();

        if(currentArrow != null)
        {
            if (movement.x != 0 || movement.y != 0 && alreadyHit == false)
            {
                alreadyHit = true;

                if (movement.x > 0f)
                {
                    tScore = PlayerHit("right");
                }
                else if (movement.x < 0f)
                {
                    tScore = PlayerHit("left");
                }
                else if (movement.y > 0f)
                {
                    tScore = PlayerHit("up");
                }
                else if (movement.y < 0f)
                {
                    tScore = PlayerHit("down");
                }

                totalScore += tScore;
                numScores++;
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            arrowNear = collision.gameObject;

            currentArrow = arrowNear.GetComponent<SpriteRenderer>();

        }
        if (collision.gameObject.tag == "End")
        {
            tempTime = stopwatch.text;
            StartCoroutine(FinishGame());
        }
    }


public float PlayerHit(string dir)
    {
        //prompt.text = dir;
        
        float score = new float();
        
        float distance = Vector2.Distance(currentArrow.transform.position, Player.transform.position);


        if (currentArrow.sprite.name == "arrow_upF")
        {
            if(dir == "up")
            {
                if (distance < r1)
                {
                    scoreTxt = "perfect";
                }
                else if (distance < r2)
                {
                    scoreTxt = "good";
                }
                else if (distance < r3)
                {
                    scoreTxt = "fine";
                }
                else
                {
                    scoreTxt = "fail";
                }
                currentArrow.sprite = upE;
            }
        }
        else if (currentArrow.sprite.name == "arrow_rightF")
        {
            if (dir == "right")
            {
                if (distance < r1)
                {
                    scoreTxt = "perfect";
                }
                else if (distance < r2)
                {
                    scoreTxt = "good";
                }
                else if (distance < r3)
                {
                    scoreTxt = "fine";
                }
                else
                {
                    scoreTxt = "fail";
                }
                currentArrow.sprite = rightE;
            }
        }
        else if (currentArrow.sprite.name == "arrow_downF")
        {
            if (dir == "down")
            {
                if (distance < r1)
                {
                    scoreTxt = "perfect";
                }
                else if (distance < r2)
                {
                    scoreTxt = "good";
                }
                else if (distance < r3)
                {
                    scoreTxt = "fine";
                }
                else
                {
                    scoreTxt = "fail";
                }
                currentArrow.sprite = downE;
            }
        }
        else if (currentArrow.sprite.name == "arrow_leftF")
        {
            if (dir == "left")
            {
                if (distance < r1)
                {
                    scoreTxt = "perfect";
                }
                else if (distance < r2)
                {
                    scoreTxt = "good";
                }
                else if (distance < r3)
                {
                    scoreTxt = "fine";
                }
                else
                {
                    scoreTxt = "fail";
                }
                currentArrow.sprite = leftE;
            }
        }
        else
        {
            //score = 0;
        }

        if (score != null)
        {
            StartCoroutine(TellPlayer(scoreTxt));
            
        }
        
        return score;
    }

    IEnumerator TellPlayer(string s)
    {
        if (s == "okay")
        {
            prompt.text = "OKAY";
        }
        else if (s == "good")
        {
            prompt.text = "GOOD";
        }
        else if (s == "perfect")
        {
            perfectHit.transform.position = new Vector2(Player.transform.position.x, player.transform.position.y);
            perfectHit.Play();
            prompt.text = "PERFECT";
        }
        else if (s == "fail")
        {
            prompt.text = "FAIL";
        }

        yield return new WaitForSeconds (4f);
        alreadyHit = false;
    }

    IEnumerator FinishGame()
    {
        PlayerPrefs.SetString("p1time", tempTime);
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene("OneEnd");
    }

    public int GetNodeIndex()
    {
        return CurrentNode;
    }

    public float GetAverage()
    {
        float avg = totalScore / numScores;
        return avg;
    }

    public void ZeroScore()
    {
        totalScore = 0;
        numScores = 0;
    }

    public void SetSpeed(float p)
    {
        MoveSpeed = p * MoveSpeed;
    }

    public void MoveMarker()
    {
        float previousPos = placeMarker.transform.position.x;
        float trackAmtDone = (totalDistance - distanceToEnd) / totalDistance;
        float lineAmtDone = trackAmtDone * lineLength;
        float newXpos = startxPos + lineAmtDone;
        placeMarker.transform.position = new Vector2(newXpos, placeMarker.transform.position.y);
        //SET YPOS BASED ON RATIO OF POSITION FROM END OFTRACK TO POSITION FROM END OF MINIMAP LINE
    }
}