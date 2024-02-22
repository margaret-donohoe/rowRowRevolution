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

    public AudioSource click;

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
        click.Play();
        StartCoroutine(inst());
    }
    public void Begin()
    {
        click.Play();
        if (numPlayers == 1)
        {
            click.Play();
            
            StartCoroutine(chz1());
        }
        else if (numPlayers == 2)
        {
            click.Play();
            
            StartCoroutine(chz2());
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
        click.Play();
    }
    public void ch2()
    {
        numPlayers = 2;
        click.Play();
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

    IEnumerator inst()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("instructions"); //scene explaining how the game works
    }

    IEnumerator chz1()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("choose1"); //scene explaining how the game works
    }

    IEnumerator chz2()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("choose2a"); //scene explaining how the game works
    }
}