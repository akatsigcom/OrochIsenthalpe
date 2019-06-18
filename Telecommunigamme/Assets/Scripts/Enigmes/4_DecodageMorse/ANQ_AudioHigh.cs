using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]


public class ANQ_AudioHigh : MonoBehaviour
{
    public static AudioSource audioHigh;
    int timer = 0;
    public static bool startTimerHigh = false;
    int maxTime = 50;       // duration of high sound
    static bool startTimerBlank = false;
    int maxTimeBlank = 100; // duration of blank sound

    public static float volumeHigh; 

    void Start()
    {
        audioHigh = GetComponent<AudioSource>();
        audioHigh.Stop();
        volumeHigh = audioHigh.volume;
    }

    void Update()
    {

        if (startTimerHigh)
        {
            timer++;

            if (timer > maxTime)
            {
                startTimerHigh = false;
                timer = 0;
                audioHigh.Stop();
                ANQ_MorseWords.waitToEnd = false;
            }
        }

        if (startTimerBlank)
        {
            timer++;

            if (timer > maxTimeBlank)
            {
                startTimerBlank= false;
                timer = 0;
                ANQ_MorseWords.waitToEnd = false;
            }
        }

    }

    public static void DotSound()   // starts high pitched sound
    {
        startTimerHigh= true;
        audioHigh.Play(0);
    }

    public static void BlankSound() // no sound
    {
        startTimerBlank = true;
    }

}
