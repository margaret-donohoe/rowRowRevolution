using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PInput2 : MonoBehaviour
{

    private GameObject camera;
    private GameObject pointParent;
    private Transform[] Path;
    private GameObject Player;
    public float MoveSpeed;
    private twoPlayerManager twoP;
    float Timer;
    static Vector3 CurrentPositionHolder;
    int CurrentNode;
    private Vector2 startPosition;


    // Use this for initialization
    void Start()
    {
        twoP = GameObject.Find("HUD").GetComponent<twoPlayerManager>();
        pointParent = GameObject.Find("RIVER PATH");
        //camera = gameObject.transform.GetChild(0).gameObject;
        Player = gameObject;
        Path = twoP.GetArray();
        //Debug.Log(PathNode);
        CheckNode();
    }

    void CheckNode()
    {
        Timer = 0;
        startPosition = Player.transform.position;
        CurrentPositionHolder = Path[CurrentNode].transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        camera.transform.position = new Vector3(Player.transform.position.x + 4, Player.transform.position.y, -10f);
        Timer += Time.deltaTime * MoveSpeed;


        if (Player.transform.position != CurrentPositionHolder)
        {
            Player.transform.position = Vector3.Lerp(startPosition, CurrentPositionHolder, Timer);
        }
        else
        {

            if (CurrentNode < Path.Length - 1)
            {
                CurrentNode++;
                CheckNode();
            }
        }
    }

    public void SetCamera(GameObject c)
    {
        camera = c;
    }
}