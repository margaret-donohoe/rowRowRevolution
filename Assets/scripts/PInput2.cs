using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;

public class PInput2 : MonoBehaviour
{

    private GameObject camera;
    private GameObject pointParent;
    private Transform[] PathNode;
    private GameObject Player;
    public float MoveSpeed;
    float Timer;
    static Vector3 CurrentPositionHolder;
    int CurrentNode;
    private Vector2 startPosition;


    // Use this for initialization
    void Start()
    {
        pointParent = GameObject.Find("RIVER PATH");
        camera = gameObject.transform.GetChild(0).gameObject;
        Player = gameObject;
        PathNode = pointParent.GetComponentsInChildren<Transform>();
        Debug.Log(PathNode);
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

        camera.transform.position = new Vector3(Player.transform.position.x + 4, Player.transform.position.y, -10f);
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