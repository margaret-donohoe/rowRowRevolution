using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class chooseOneP : MonoBehaviour
{
    public Button setBtn;
    GameObject[] music;

    public AudioSource click;
    public AudioSource swish;

    public Button boatFancy;
    public Button boatOrchestra;
    public Button boatToy;


    public Button back;
    // Start is called before the first frame update
    void Start()
    {
        music = GameObject.FindGameObjectsWithTag("KEEP");
        setBtn.onClick.AddListener(Set);
        boatFancy.onClick.AddListener(SetFancy);
        boatOrchestra.onClick.AddListener(SetOrchestra);
        boatToy.onClick.AddListener(SetToy);
  
        back.onClick.AddListener(Back);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Set()
    {
        click.Play();
        foreach(GameObject m in music)
        {
            m.SetActive(false);
        }
        StartCoroutine(BeginGame());
    }

    void SetFancy()
    {
        swish.Play();
        PlayerPrefs.SetString("music", "fancy");
    }

    void SetOrchestra()
    {
        swish.Play();
        PlayerPrefs.SetString("music", "orchestra");
    }

    void SetToy()
    {
        swish.Play();
        PlayerPrefs.SetString("music", "toy");
    }


    IEnumerator BeginGame()
    {
        yield return new WaitForSeconds(0.4f);
        SceneManager.LoadScene("levelOne");
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
