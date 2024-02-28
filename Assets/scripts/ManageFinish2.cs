using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ManageFinish2 : MonoBehaviour
{
    public Button again;
    public Button menu;
    public Button quit;
    public TextMeshProUGUI time1;
    public TextMeshProUGUI time2;
    public GameObject oneWins;
    public GameObject twoWins;

    private int whoWon;
    public TextMeshProUGUI winText;

    // Start is called before the first frame update
    void Start()
    {
        time1.text = PlayerPrefs.GetString("p1time");
        time2.text = PlayerPrefs.GetString("p2time");
        again.onClick.AddListener(PlayAgain);
        menu.onClick.AddListener(Home);
        quit.onClick.AddListener(Quit);

        whoWon = PlayerPrefs.GetInt("winner");
        if(whoWon == 1)
        {
            winText.transform.position = new Vector2(oneWins.transform.position.x, oneWins.transform.position.y);
        }
        if (whoWon == 2)
        {
            winText.transform.position = new Vector2(twoWins.transform.position.x, twoWins.transform.position.y);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("choose2a");
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
