using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ManageFinish1 : MonoBehaviour
{
    public Button again;
    public Button HELL;
    public Button menu;
    public Button quit;
    public TextMeshProUGUI time;

    // Start is called before the first frame update
    void Start()
    {
        time.text = PlayerPrefs.GetString("p1time");
        again.onClick.AddListener(PlayAgain);
        HELL.onClick.AddListener(LevelTwo);
        menu.onClick.AddListener(Home);
        quit.onClick.AddListener(Quit);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("levelOne");
    }

    public void LevelTwo()
    {
        SceneManager.LoadScene("levelHELL");
    }

    public void Home()
    {
        SceneManager.LoadScene("Open");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
