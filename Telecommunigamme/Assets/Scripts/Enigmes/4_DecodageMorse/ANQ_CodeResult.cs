using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ANQ_CodeResult : MonoBehaviour
{

    public static Text codeResult;

    void Update()
    {
        VerificationDecodage();
        TooLongDecodage();
    }

    public void VerificationDecodage()      // check if the right morse translation was given for the code
    {
        codeResult = GetComponent<Text>();

        if (codeResult.text == ANQ_MorseWords.code) // if equal, it will put the text in green, indicate it has changed, indicate to display
        {

            codeResult.color = Color.green;

        }
    }

    public void TooLongDecodage()       // check if the input morse word is too long compared to right morse word to find
    {
        Text codeResult = GetComponent<Text>();

        if (codeResult.text.Length >= ANQ_MorseWords.code.Length & codeResult.text != ANQ_MorseWords.code)      // the input will be stopped and the text will be red colored
        {
            codeResult.color = Color.red;
        }
        if (codeResult.text.Length < ANQ_MorseWords.code.Length)
        {
            codeResult.color = Color.black;
        }
        
    }

}
