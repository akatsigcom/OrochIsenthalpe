using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ANQ_BrailleText : MonoBehaviour
{
    Text brailleResult;  // Text above taquin

    void Update()
    {
        brailleResult = GetComponent<Text>();

        if (Puzzle.currentWordOK)
        {
            brailleResult.text = "Bravo !";   //Success 
        }
        else
        {
            brailleResult.text = Puzzle.brailleWord[0].ToString().ToUpper() + Puzzle.brailleWord.Substring(1); // Word to find still displayed with capital letter
        }
    }
}
