using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ANQ_BrailleToCode : MonoBehaviour
{
    Text brailleToFind;

    void Start()
    {
        brailleToFind = GetComponent<Text>();
        brailleToFind.text = ANQ_GenerateBigButterfly.rightBrailleWord;
    }


}
