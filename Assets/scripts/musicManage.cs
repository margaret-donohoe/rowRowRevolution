using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicManage : MonoBehaviour
{
    private AudioSource pAudio;
    private pInput Player;

    public AudioClip minusThree;
    public AudioClip minusTwo;
    public AudioClip minusOne;
    private AudioClip center;
    public AudioClip plusOne;
    public AudioClip plusTwo;
    public AudioClip plusThree;

    // Start is called before the first frame update
    void Start()
    {
        //SET AUDIO CLIPS BASED ON BOAT TYPE HERE



        Player = gameObject.GetComponent<pInput>();
        pAudio = gameObject.GetComponent<AudioSource>();
        center = pAudio.clip;

        pAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckTime()
    {
        int i = Player.GetNodeIndex();
        bool check = (i % 4 == 0);
        print(check);
        float current = pAudio.pitch;

        if (i > 4 && i % 4 == 0) // NOT WORKING
        {
            float score = Player.GetAverage();

            if(score >= 0.75) // high score, music speeds up
            {
                
                pAudio.pitch = current + 0.1f;
                Player.SetSpeed(pAudio.pitch);
            }

            else if(score <= 0.25) // low score, music slows down
            {
                pAudio.pitch = current - 0.1f;
                Player.SetSpeed(pAudio.pitch);
            }
            else
            {
                Player.SetSpeed(pAudio.pitch);
            }

        }

        Player.ZeroScore();
    }
}
