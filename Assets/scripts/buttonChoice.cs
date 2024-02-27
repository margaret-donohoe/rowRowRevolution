using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class begin : MonoBehaviour
{
    //public Button button;

    public Button chooseFancy;
    public Button chooseOrchestra;
    public Button chooseToy;


    //public Button instructions;
    //public AudioSource music;

    // Start is called before the first frame update
    void Start()
    {
        //music.Play();
        //instructions.onClick.AddListener(goDirections);
        //button.onClick.AddListener(buttonClick);
        choose90s.onClick.AddListener(fancy);
        chooseOrchestra.onClick.AddListener(orchestra);
        chooseToy.onClick.AddListener(toy);

        

        //PlayerPrefs.SetString("color", "red");
    }
    /*
    void buttonClick()
    {
        SceneManager.LoadScene("game");
    }

    void goDirections()
    {
        Debug.Log("press");
        SceneManager.LoadScene("directions");
    }
    */

    void fancy()
    {
        PlayerPrefs.SetString("music", "fancy");
    }

    void orchestra()
    {
        PlayerPrefs.SetString("music", "orchestra");
    }

    void toy()
    {
        PlayerPrefs.SetString("music", "toy");
    }

  
    
}


