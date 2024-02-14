using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Diagnostics;
using System.Threading;

public class pInput : MonoBehaviour
{
    public TextMeshProUGUI stopwatch;
    public Stopwatch timer = new Stopwatch();

    public GameObject camera;
    public GameObject[] PathNode;
    public GameObject Player;
    public float MoveSpeed;
    float Timer;
    static Vector3 CurrentPositionHolder;
    int CurrentNode;
    private Vector2 startPosition;


    // Use this for initialization
    void Start()
    {
        timer.Start();
        //PathNode = GetComponentInChildren<>();
        CheckNode();
    }

    void CheckNode()
    {
        Timer = 0;
        startPosition = Player.transform.position;
        CurrentPositionHolder = PathNode[CurrentNode].transform.position;
    }

    // Update is called once per frame
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
}