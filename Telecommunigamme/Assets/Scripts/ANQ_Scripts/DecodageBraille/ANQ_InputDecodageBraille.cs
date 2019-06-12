using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ANQ_InputDecodageBraille : MonoBehaviour
{
    InputField inputDecodageBraille;
    void Start()
    {
        inputDecodageBraille = GetComponent<InputField>();
        inputDecodageBraille.interactable = false;


    }

    void Update()
    {
        if (ANQ_GenerateBigButterfly.rightOrder)
        {
            inputDecodageBraille.interactable = true;
        }
        else
        {
            inputDecodageBraille.interactable = false;
        }

    }

}
