using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class chooseTwoP : MonoBehaviour
{
    public Button setBtn;
    GameObject[] music;
    private Vector2 location;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindGameObjectsWithTag("KEEP");
        setBtn.onClick.AddListener(Set);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Set()
    {
        foreach(GameObject m in music)
        {
            m.SetActive(false);
        }
        SceneManager.LoadScene("levelOne");
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        location = context.ReadValue<Vector2>();
    }
}

