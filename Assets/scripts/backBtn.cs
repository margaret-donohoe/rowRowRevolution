using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class backBtn : MonoBehaviour
{
    public Button back;
    // Start is called before the first frame update
    void Start()
    {
        back.onClick.AddListener(GoHome);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GoHome()
    {
        StartCoroutine(WaitASec());
    }

    IEnumerator WaitASec()
    {
        yield return new WaitForSeconds(0.02f);
        SceneManager.LoadScene("Open");
    }
}
