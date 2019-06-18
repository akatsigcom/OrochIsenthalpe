using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ANQ_MorseResult : MonoBehaviour    // display result
{
    void Update()
    {
        Text textResult = GetComponent<Text>();
        if (CodageMorse.displayResult)
        {
            textResult.color = Color.green;
        }
    }
}
