using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Diagnostics;
using UnityEngine.InputSystem;

public class pInput : MonoBehaviour
{
    public TextMeshProUGUI prompt;
    private TextMeshProUGUI stopwatch;
    public Stopwatch timer = new Stopwatch();

    public PlayerInputActions playerControls;
    private InputAction move;
    private Vector2 movement;

    public float r1 = 2;
    public float r2 = 3;
    public float r3 = 4;

    public Sprite upE;
    public Sprite downE;
    public Sprite rightE;
    public Sprite leftE;

    SpriteRenderer currentArrow;

    public GameObject camera;
    public GameObject[] PathNode;
    //public GameObject pointParent;
    public GameObject Player;
    public float MoveSpeed;
    float Timer;
    static Vector3 CurrentPositionHolder;
    int CurrentNode;
    private Vector2 startPosition;


    // Use this for initialization
    private void Awake()
    {
        stopwatch = GameObject.FindWithTag("time").GetComponent<TextMeshProUGUI>();
        playerControls = new PlayerInputActions();
    }
    void Start()
    {
        //PathNode = pointParent.GetComponentsInChildren<Transform>();
        //PathNode = GetComponentInChildren<>();
        timer.Start();
        CheckNode();
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
        movement = move.ReadValue<Vector2>();
        if (movement.x > 0f)
        {
            PlayerHit("right");
        }
        else if (movement.x < 0f)
        {
            PlayerHit("left");
        }
        else if (movement.y > 0f)
        {
            PlayerHit("up");
        }
        else if (movement.y < 0f)
        {
            PlayerHit("down");
        }
    }

    void Update()
    {
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

            if (CurrentNode < PathNode.Length - 1)
            {
                CurrentNode++;
                CheckNode();
            }
        }
    }

    public float PlayerHit(string dir)
    {
        prompt.text = dir;
        
        float score = new float();
        currentArrow = PathNode[CurrentNode].GetComponentInChildren<SpriteRenderer>();
        float distance = Vector3.Distance(currentArrow.transform.position, Player.transform.position);

        if (currentArrow.sprite.name == "arrow_upF")
        {
            if(dir == "up")
            {
                if (distance < r1)
                {
                    score = 1;
                }
                else if (distance < r2)
                {
                    score = 0.67f;
                }
                else if (distance < r3)
                {
                    score = 0.33f;
                }
                else
                {
                    score = 0;
                }
            }
            currentArrow.sprite = upE;
        }

        else if (currentArrow.sprite.name == "arrow_rightF")
        {
            if (dir == "right")
            {
                if (distance < r1)
                {
                    score = 1;
                }
                else if (distance < r2)
                {
                    score = 0.67f;
                }
                else if (distance < r3)
                {
                    score = 0.33f;
                }
                else
                {
                    score = 0;
                }
            }
            currentArrow.sprite = rightE;
        }

        else if (currentArrow.sprite.name == "arrow_downF")
        {
            if (dir == "down")
            {
                if (distance < r1)
                {
                    score = 1;
                }
                else if (distance < r2)
                {
                    score = 0.67f;
                }
                else if (distance < r3)
                {
                    score = 0.33f;
                }
                else
                {
                    score = 0;
                }
            }
            currentArrow.sprite = downE;
        }

        else if (currentArrow.sprite.name == "arrow_leftF")
        {
            if (dir == "left")
            {
                if (distance < r1)
                {
                    score = 1;
                }
                else if (distance < r2)
                {
                    score = 0.67f;
                }
                else if (distance < r3)
                {
                    score = 0.33f;
                }
                else
                {
                    score = 0;
                }
            }
            currentArrow.sprite = leftE;
        }
        else
        {
            score = 0;
        }

        if (score != null)
        {
            if (score == 0.33f)
            {
                //prompt.text = "OKAY";
            }
            else if (score == 0.67f)
            {
                //prompt.text = "GOOD";
            }
            else if (score == 1)
            {
                //prompt.text = "PERFECT";
            }
            else if (score == 0)
            {
                //prompt.text = "FAIL";
            }
        }
        return score;
    }
        
}