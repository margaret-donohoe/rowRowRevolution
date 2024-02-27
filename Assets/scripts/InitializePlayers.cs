using UnityEngine;
using UnityEngine.InputSystem;

public class InitializePlayers : MonoBehaviour
{
    public GameObject playerPrefab;
    public int numberOfPlayers = 2;

    void Start()
    {
        var gamepads = Gamepad.all;
        if (numberOfPlayers == 2)
        {
            var player1 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad1", pairWithDevice: gamepads[0]);
            player1.transform.position = new Vector3(0f, -3.2f, 0f);
            player1.gameObject.transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0f, 0f, 0.5f, 1f);


            var player2 = PlayerInput.Instantiate(playerPrefab, controlScheme: "Gamepad2", pairWithDevice: gamepads[1]);
            player2.transform.position = new Vector3(2f, -3.2f, 0f);
            player2.gameObject.transform.GetChild(0).GetComponent<Camera>().rect = new Rect(0.5f, 0f, 0.5f, 1f);

        }
        else
        {
            print("Please connect 2 Controllers!!!");
        }
    }
}

