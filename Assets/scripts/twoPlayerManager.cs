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

    public GameObject camera1;
    public GameObject camera2;

    public GameObject startPoint;
    public GameObject startPoint2;
    public GameObject player1Prefab;
    public GameObject player2Prefab;
    private int numberOfPlayers = 2;

    private pInput2a playerOne;
    private pInput2b playerTwo;
    // Start is called before the first frame update
    void Start()
    {
        timer.Start();
        //var gamepads = Gamepad.all;
        if (numberOfPlayers == 2)
        {
            var player1 = PlayerInput.Instantiate(player1Prefab, controlScheme: "Arrows", pairWithDevice: Keyboard.current); ;
            //player1.transform.position = startPoint.transform.position;
            //player1.gameObject.GetComponent<PInput2>().SetCamera(camera1);
            player1.gameObject.GetComponent<AudioSource>().panStereo = 0.0f;
            playerOne = player1.gameObject.GetComponent<pInput2a>();
            playerOne.gameObject.transform.position = startPoint.transform.position;
            camera1.transform.position = new Vector3(playerOne.transform.position.x, playerOne.transform.position.y, -10f);

            var player2 = PlayerInput.Instantiate(player2Prefab, controlScheme: "WASD", pairWithDevice: Keyboard.current);
            //player2.transform.position = startPoint2.transform.position;
            //player2.gameObject.GetComponent<PInput2>().SetCamera(camera2);
            player2.gameObject.GetComponent<AudioSource>().panStereo = 1.0f;
            playerTwo = player2.gameObject.GetComponent<pInput2b>();
            //camera1.GetComponent<Camera>().rect = new Rect();
            playerTwo.gameObject.transform.position = startPoint2.transform.position;
            camera2.transform.position = new Vector3(playerTwo.transform.position.x, playerTwo.transform.position.y, -10f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        TimeSpan t = timer.Elapsed;
        string elapsedTime = String.Format("{0:00}:{1:00}", t.Minutes, t.Seconds);
        stopwatch.text = elapsedTime;

    }

    void FixedUpdate()
    {
        camera1.transform.position = new Vector3(playerOne.transform.position.x, playerOne.transform.position.y, -10f);
        camera2.transform.position = new Vector3(playerTwo.transform.position.x, playerTwo.transform.position.y, -10f);
    }
}