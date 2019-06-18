using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ANQ_MorseWords : MonoBehaviour
{
    string[] digicodePossibilities = {"0","1","2","3","4","5","6","7","8","9","A","B"};

    public static string code;
    public static string codeInMorse;

    void Start()
    {
        for (int i=0; i<6; i++)
        {
            code += digicodePossibilities[Random.Range(0, digicodePossibilities.Length)];
        }
        codeInMorse = ANQ_TextWords.ToMorse(code);
    }

    public static bool waitToEnd = true;
    int iterator = 0; 

    
    void Update()
    {
        if (!waitToEnd)
        {
            Spot(codeInMorse[iterator].ToString());
            waitToEnd = true;
            iterator+= 2;     // jump the space between the characters
        }
    }

    void Spot(string chara)     
    {
        if (chara == ".")
        {
            ANQ_AudioHigh.DotSound();
        }

        if (chara == "_")
        {
            ANQ_AudioBass.UnderscoreSound();
        }
        if (chara == " ")
        {
            ANQ_AudioHigh.BlankSound();
        }
    }

    public void StartSound()
    {
        waitToEnd = false;
    }
}
