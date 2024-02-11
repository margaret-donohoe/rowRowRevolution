using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;
public class TitleScreen : MonoBehaviour
{
    public Button instructions;
    public Button startBtn;
    public Button one;
    public Button two;
    public TextMeshProUGUI prompt;

    private int numPlayers = 0;

    void Start()
    {
        prompt.alpha = 0;
        instructions.onClick.AddListener(Help);
        startBtn.onClick.AddListener(Begin);
        one.onClick.AddListener(ch1);
        two.onClick.AddListener(ch2);
    }
    public void Help() 
    {
        SceneManager.LoadScene("instructions"); //scene explaining how the game works
    }
    public void Begin()
    { 
        if(numPlayers == 1)
        {
            SceneManager.LoadScene("choose1"); //scene where one player can choose their boat
        }
        else if (numPlayers == 2)
        {
            SceneManager.LoadScene("choose2"); //scene where two players can choose their boats
        }
        else
        {
            prompt.alpha = 1;
            StartCoroutine(FadeOut());
        }
    }
    public void ch1()
    {
        numPlayers = 1;
    }
    public void ch2()
    {
        numPlayers = 2;
    }

    IEnumerator FadeOut()
    {
        yield return new WaitForSeconds(1);
        while (prompt.alpha > 0)
        {
            prompt.alpha -= 0.1f;
            yield return new WaitForSeconds(0.05f);
        }
    }
}