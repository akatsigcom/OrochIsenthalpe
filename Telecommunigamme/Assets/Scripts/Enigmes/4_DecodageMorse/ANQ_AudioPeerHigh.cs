using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANQ_AudioPeerHigh : MonoBehaviour
{
    new AudioSource audio;
    public static float[] samples = new float[512]; 
    public static float[] freqBand = new float[8];  
    public static float[] bandBuffer = new float[8];
    float[] bufferDecrease = new float[8];  

    float[] freqBandHighest = new float[8];
    public static float[] audioBand = new float[8];
    public static float[] audioBandBuffer = new float[8];

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        GetSpectrumAudioSource();
        MakeFrequencyBands();
        BandBuffer();
        CreateAudioBands();
    }

    void CreateAudioBands()     // create bands according to frequency
    {
        for (int i = 0; i < 8; i++)
        {
            if (freqBand[i] > freqBandHighest[i])
            {
                freqBandHighest[i] = freqBand[i];
            }
            audioBand[i] = (freqBand[i] / freqBandHighest[i]);
            audioBandBuffer[i] = (bandBuffer[i] / freqBandHighest[i]);
        }
    }

    void GetSpectrumAudioSource()   
    {
        audio.GetSpectrumData(samples, 0, FFTWindow.Blackman);
    }

    void BandBuffer()   // to smooth the decrease of intensity
    {
        for (int g = 0; g < 8; ++g)
        {
            if (freqBand[g] > bandBuffer[g])
            {
                bandBuffer[g] = freqBand[g];
                bufferDecrease[g] = 0.005f;
            }
            if (freqBand[g] < bandBuffer[g])
            {
                bandBuffer[g] -= bufferDecrease[g];
                bufferDecrease[g] *= 1.2f;
            }
        }

    }

    void MakeFrequencyBands()
    {
        /*
         *  22050 / 512 = 43Hz
         *  
         *  20-60Hz
         *  60-250Hz
         *  250-500Hz
         *  500-2000Hz
         *  2000-4000Hz
         *  4000-6000Hz
         *  6000-20 000Hz
         *  
         *  0 - 2 = 86Hz
         *  1 - 4 = 172Hz   87-258
         *  2 - 8 = 344Hz   259-602    
         *  3 - 16 = 688Hz  603-1290
         *  4 - 32 = 1376Hz 1291-2666
         *  5 - 64 = 2752Hz 2667-5418
         *  6 - 128 = 5504Hz    5419-10922
         *  7 - 256 = 11008Hz   10923-21930
         *  510
         */

        int count = 0;

        for (int i = 0; i < 8; i++)
        {
            float average = 0;
            int sampleCount = (int)Mathf.Pow(2, i) * 2;

            if (i == 7)
            {
                sampleCount += 2;
            }
            for (int j = 0; j < sampleCount; j++)
            {
                average += samples[count] * (count + 1);
                count++;
            }
            average /= count;
            freqBand[i] = average * 10;
        }
    }
}