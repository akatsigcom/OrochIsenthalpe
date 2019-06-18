using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class ANQ_AudioBass : MonoBehaviour
{
    public static AudioSource audioBass;
    int timer = 0;  
    public static bool startTimerBass = false;
    int maxTime = 60;       // duration of low sound
    public static float volumeBass;

    void Start()
    {
        audioBass = GetComponent<AudioSource>();
        audioBass.Stop();
        volumeBass = audioBass.volume;

    }

    void Update()
    {

        if (startTimerBass)
        {
            timer++;

            if (timer > maxTime)
            {
                startTimerBass = false;
                timer = 0;
                audioBass.Stop();
                ANQ_MorseWords.waitToEnd = false;

            }
        }

    }

    public static void UnderscoreSound()    // starts low pitched sound
    {
        startTimerBass = true;
        audioBass.Play(0);

    }
}