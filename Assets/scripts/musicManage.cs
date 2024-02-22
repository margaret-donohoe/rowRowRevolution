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
        //float j = i / 4 * 4;
        bool changed = false;

        float prevTime = pAudio.time;
        float timeRatio = prevTime / pAudio.clip.length;

        if(i % 4 == 0)
        {
            float score = Player.GetAverage();

            if(score >= 0.75) // high score, music speeds up
            {
                float current = pAudio.pitch;
                pAudio.pitch = current - 0.1f;
            }

            else if(score <= 0.25) // low score, music slows down
            {
                if (pAudio.clip == minusTwo)
                {
                    pAudio.clip = minusThree;
                    changed = true;
                }
                else if (pAudio.clip == minusOne && changed == false)
                {
                    pAudio.clip = minusTwo;
                    changed = true;
                }
                else if (pAudio.clip == center && changed == false)
                {
                    pAudio.clip = minusOne;
                    changed = true;
                }
                if (pAudio.clip == plusOne && changed == false)
                {
                    pAudio.clip = center;
                    changed = true;
                }
                else if (pAudio.clip == plusTwo && changed == false)
                {
                    pAudio.clip = plusOne;
                    changed = true;
                }
                else if (pAudio.clip == plusThree && changed == false)
                {
                    pAudio.clip = plusTwo;
                    changed = true;
                }
            }

            pAudio.time = timeRatio / pAudio.clip.length; //sets time of clip based on time of previous clip
        }

        Player.ZeroScore();
    }
}
