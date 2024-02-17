using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chooseTwoA : MonoBehaviour
{
    public Button setBtn;
    GameObject[] music;
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
        SceneManager.LoadScene("choose2B");
    }
}
