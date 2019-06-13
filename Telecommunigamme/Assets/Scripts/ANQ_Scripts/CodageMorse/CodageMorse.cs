using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CodageMorse : MonoBehaviour
{
    public static int word = 0; // indicate the word to code in morse (0:cerf, 1:2, 2:droite)
    public static bool haschanged = false; // indicate if a word was just found
    public static bool displayResult = false; // indicate if textResult has to display
    public static bool isBlocked = false; // if the word is too long, the player will be prevented from writing


    ////// Buttons for Morse writings
 


    public void ClickDot()
    {

        if (!isBlocked)
        {
            Text textMorse = GetComponent<Text>();
            if (haschanged)    // text is erased after finding a word
            {
                textMorse.text = "";
                textMorse.color = Color.black;
                haschanged = false;
            }
            if (textMorse.text == "Code en morse les mots ci-dessus")   //make the first sentence disappear
            {
                textMorse.text = "";
            }

            textMorse.text = textMorse.text + ". ";     // add ". " to the text
        }
    }

    public void ClickUnderscore()

    {
        if (!isBlocked)
        {
            Text textMorse = GetComponent<Text>();
            if (haschanged)     // text is erased after finding a word
            {
                textMorse.text = "";
                textMorse.color = Color.black;
                haschanged = false;
            }
            if (textMorse.text == "Code en morse les mots ci-dessus")       //make the first sentence disappear
            {
                textMorse.text = "";
            }
            textMorse.text = textMorse.text + "_ ";     // add "_ " to the text
        }
    }

    public void ClickSpace()

    {
        if (!isBlocked)
        {
            Text textMorse = GetComponent<Text>();
            if (haschanged)          // text is erased after finding a word
            {
                textMorse.text = "";
                textMorse.color = Color.black;
                haschanged = false;
            }
            if (textMorse.text != "Code en morse les mots ci-dessus")       //make the first sentence disappear
            {
                textMorse.text = textMorse.text + "  ";     // add "  " to the text
            }
        }
    }

    public void ClickDelete()       // delete the last character given
    {
        Text textMorse = GetComponent<Text>();

        if (textMorse.text == "Code en morse les mots ci-dessus")  //make the first sentence disappear
        {
            textMorse.text = "";
        }

        textMorse.text = textMorse.text.Remove(textMorse.text.Length - 2); // it is 2 here because of the space added to each input character

        if (isBlocked)     // lift the input lock and put the text back in black
        {
            isBlocked = false;
            textMorse.color = Color.black;
        }
    }

    ////// Codage Morse

    public void Verification()      // check if the right morse translation was given for each word
    {
        Text textMorse = GetComponent<Text>();
        if (word == 0)
        {
            if (textMorse.text == ANQ_TextWords.animalMorse) // if equal, it will put the text in green, indicate it has changed, indicate the new word, indicate to display
            {
                textMorse.text = "";
                word = 1;
                displayResult = true;
            }
        }
        if (word == 1)
        {
            if (textMorse.text == ANQ_TextWords.numberMorse)
            {
                textMorse.text = "";
                word = 2;
                displayResult = true;

            }
        }
        if (word == 2)
        {
            if (textMorse.text == ANQ_TextWords.directionMorse)
            {
                textMorse.text = "";
                word = 3;
                displayResult = true;

            }
        }
    }


    public void TooLong()       // check if the input morse word is too long compared to right morse word to find
    {
        Text textMorse = GetComponent<Text>();
        if (word == 0 & !haschanged)
        {
            if (textMorse.text.Length >= ANQ_TextWords.animalMorse.Length)      // the input will be stopped and the text will be red colored
            {
                textMorse.color = Color.red;
                isBlocked = true;
            }
        }

        if (word == 1 & !haschanged)
        {
            if (textMorse.text.Length >= ANQ_TextWords.numberMorse.Length)
            {
                textMorse.color = Color.red;
                isBlocked = true;

            }
        }

        if (word == 2 & !haschanged)
        {
            if (textMorse.text.Length >= ANQ_TextWords.directionMorse.Length)
            {
                textMorse.color = Color.red;
                isBlocked = true;
            }
        }
    }



    ////// DECODAGE MORSE

    public static bool rightMorse = false;

    public void VerificationReport()      // check if the right morse translation was given for the code
    {
        Text textMorse = GetComponent<Text>();

        if (textMorse.text == ANQ_MorseWords.codeInMorse) // if equal, it will put the text in green, indicate it has changed, indicate to display
        {
            textMorse.color = Color.green;
            haschanged = true;
            displayResult = true;
            rightMorse = true;
        }
    }

    public void TooLongReport()       // check if the input morse word is too long compared to right morse word to find
    {
        Text textMorse = GetComponent<Text>();
        if (word == 0 & !haschanged)
        {
            if (textMorse.text.Length >= ANQ_MorseWords.codeInMorse.Length)      // the input will be stopped and the text will be red colored
            {
                textMorse.color = Color.red;
                isBlocked = true;
            }
        }
    }

}
