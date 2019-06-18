using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ANQ_InputMorseCode : MonoBehaviour        // manage input field
{
    InputField inputMorseCode;
    void Start()
    {
        inputMorseCode = GetComponent<InputField>();
        inputMorseCode.interactable = false;
    }

    void Update()
    {
        if (CodageMorse.rightMorse)
        {
            inputMorseCode.interactable = true;
        }
    }

}
