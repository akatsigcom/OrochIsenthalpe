using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ANQ_DeleteKey : MonoBehaviour  // deleteButton pressed with delete key
{
    Button deleteButton;

    void Start()
    {
        deleteButton = GetComponent<Button>();

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            deleteButton.onClick.Invoke();
        }
    }
}
