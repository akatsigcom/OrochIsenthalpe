using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ANQ_BrailleText : MonoBehaviour
{
    Text brailleResult;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        brailleResult = GetComponent<Text>();
        if (Puzzle.currentWordOK)
        {
            brailleResult.text = "Bravo !";
        }
        else
        {
            brailleResult.text = Puzzle.brailleWord;
        }
    }
}
