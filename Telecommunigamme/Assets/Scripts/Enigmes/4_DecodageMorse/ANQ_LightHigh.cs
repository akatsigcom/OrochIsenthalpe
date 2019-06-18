using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANQ_LightHigh : MonoBehaviour  //Manage green light
{
    Light _light;
    public int band;
    public float minIntensity, maxIntensity;

    void Start()
    {
        _light = GetComponent<Light>();
    }

    void Update()
    {

        if (ANQ_AudioHigh.startTimerHigh)   // light is emitted with intensity of the sound
        {
            _light.enabled = true;
            _light.intensity = (ANQ_AudioPeerHigh.audioBandBuffer[band] * (maxIntensity - minIntensity)) + minIntensity;
        }
        else
        {
            _light.enabled = false;
        }

    }
}
