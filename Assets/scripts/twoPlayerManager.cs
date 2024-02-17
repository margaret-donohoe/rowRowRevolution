using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System.Diagnostics;
using System.Threading;
using System;
using TMPro;

public class twoPlayerManager : MonoBehaviour
{
    public TextMeshProUGUI stopwatch;
    public Stopwatch timer = new Stopwatch();

    public GameObject startPoint;
    public GameObject playerPrefab;
    public int numberOfPlayers = 2;
    // Start is called before the first frame update
    void Start()
    {
        timer.Start();
        //var gamepads = Gamepad.all;
        if (numberOfPlayers == 2)
        {
            var player1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Arrows", pairWithDevice: Keyboard.current); ;
            player1.transform.position = startPoint.transform.position;
            player1.gameObject.transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);


            var player2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "WASD", pairWithDevice: Keyboard.current);
            player2.transform.position = startPoint.transform.position;
            player2.gameObject.transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 1f);
            player2.gameObject.GetComponent<AudioSource>().panStereo = 1.0f;
        }
        else
        {
            print("Please connect a Controller!!!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan t = timer.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}", t.Minutes, t.Seconds);
        stopwatch.text = elapsedTime;

    }
}