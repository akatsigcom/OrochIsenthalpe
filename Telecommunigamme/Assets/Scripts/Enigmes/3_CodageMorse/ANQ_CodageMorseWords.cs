using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ANQ_CodageMorseWords : MonoBehaviour
{

    public void Update() // will display the found words with their morse translation
    {
        Text textResult = GetComponent<Text>();

        if (CodageMorse.word == 1 & CodageMorse.displayResult)
        {
            textResult.text = ANQ_TextWords.animalWord + " : " + ANQ_TextWords.animalMorse;
            CodageMorse.displayResult = false;

        }
        if (CodageMorse.word == 2 & CodageMorse.displayResult)
        {
            textResult.text = textResult.text + Environment.NewLine + ANQ_TextWords.numberWord + " : " + ANQ_TextWords.numberMorse;
            CodageMorse.displayResult = false;

        }
        if (CodageMorse.word == 3 & CodageMorse.displayResult)
        {
            textResult.text = textResult.text + Environment.NewLine + ANQ_TextWords.directionWord + " : " + ANQ_TextWords.directionMorse;
            CodageMorse.displayResult = false;

        }
    }
}
