using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ANQ_BrailleResult : MonoBehaviour
{
    void Update()
    {
        Text textResult = GetComponent<Text>();
        if (ANQ_GenerateBigButterfly.rightBrailleWord == textResult.text)
        {
            textResult.color = Color.green;

        }
    }
}
