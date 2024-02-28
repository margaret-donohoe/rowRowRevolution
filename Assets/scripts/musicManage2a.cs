using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SynchronizerData;


public class musicManage2a : MonoBehaviour
{
    private AudioSource pAudio;
    private pInput2a Player;
    private AudioClip center;

    public float bpm = 120f; // Tempo in beats per minute of the audio clip.
    public float startDelay = 1; // Number of seconds to delay the start of audio playback.
    public delegate void AudioStartAction(double syncTime);
    public static event AudioStartAction OnAudioStart;

    public BeatValue beatValue = BeatValue.QuarterBeat;
    public int beatScalar = 1;
    public BeatValue beatOffset = BeatValue.None;
    public bool negativeBeatOffset = false;
    public BeatType beatType = BeatType.OnBeat;
    //float initTime;

    void Start()
    {
        //SET AUDIO CLIPS BASED ON BOAT TYPE HERE
        //center = pAudio.clip;
        Player = gameObject.GetComponent<pInput2a>();
        pAudio = gameObject.GetComponent<AudioSource>();
        pAudio.pitch = 1;
        double initTime = AudioSettings.dspTime;
        pAudio.Play();
        //StartCoroutine(StartAudio());
        //pAudio.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckTime()
    {
        int i = Player.GetNodeIndex();
        bool check = (i % 4 == 0);
        float current = pAudio.pitch;

        if (i > 4 && i % 4 == 0) // NOT WORKING
        {
            float score = Player.GetAverage();

            if (score >= 0.75) // high score, music speeds up
            {

                //pAudio.pitch = current + 0.1f;
                Player.SetSpeed(0.9f);
            }

            else if (score <= 0.25) // low score, music slows down
            {
                //pAudio.pitch = current - 0.1f;
                Player.SetSpeed(1.1f);
            }
            else
            {
                //pAudio.pitch = pAudio.pitch;
                Player.SetSpeed(1);
            }

        }

        //Player.ZeroScore();
    }


    public float GetBPM()
    {
        return bpm;
    }
}