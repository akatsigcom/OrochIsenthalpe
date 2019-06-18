using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ANQ_InputDecodageBraille : MonoBehaviour       //Manage input text
{
    InputField inputDecodageBraille;
    void Start()
    {
        inputDecodageBraille = GetComponent<InputField>();
        inputDecodageBraille.interactable = false;
    }

    void Update()
    {
        if (ANQ_GenerateBigButterfly.rightOrder)    // when butterflies rightly ordered --> input interactable
        {
            inputDecodageBraille.interactable = true;
        }
        else
        {
            inputDecodageBraille.interactable = false;
        }

    }

}
