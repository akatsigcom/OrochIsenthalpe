using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ANQ_spaceKey : MonoBehaviour // space pressed with space key
{
    Button spaceButton;

    void Start()
    {
        spaceButton = GetComponent<Button>();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            spaceButton.onClick.Invoke();
        }
    }
}
