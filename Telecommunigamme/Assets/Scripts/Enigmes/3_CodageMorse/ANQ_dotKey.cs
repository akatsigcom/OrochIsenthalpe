using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ANQ_dotKey : MonoBehaviour // dot pressed with up key
{
    Button dotButton;

    void Start()
    {
        dotButton = GetComponent<Button>();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            dotButton.onClick.Invoke();
        }
    }
}
