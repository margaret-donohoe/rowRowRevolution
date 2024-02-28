using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chooseTwoA : MonoBehaviour
{
    public Button setBtn;
    GameObject[] music;

    public AudioSource click;
    public AudioSource swish;

    public Button boat1;
    public Button boat2;
    public Button boat3;

    public Button back;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindGameObjectsWithTag("KEEP");
        setBtn.onClick.AddListener(Set);
        boat1.onClick.AddListener(SetOne);
        boat2.onClick.AddListener(SetTwo);
        boat3.onClick.AddListener(SetThree);
        back.onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void Set()
    {
        click.Play();
        StartCoroutine(BeginGame());
    }

    void SetOne()
    {
        swish.Play();
        PlayerPrefs.SetString("music1", "fancy");
    }

    void SetTwo()
    {
        swish.Play();
        PlayerPrefs.SetString("music1", "orchestra");
    }

    void SetThree()
    {
        swish.Play();
        PlayerPrefs.SetString("music1", "toy");
    }

    IEnumerator BeginGame()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("choose2b");
    }

    public void Back()
    {
        StartCoroutine(GoBack());
    }

    IEnumerator GoBack()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("Open");
    }
}
