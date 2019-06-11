using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialoguePossible : MonoBehaviour
{

    public GameObject Button;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        Button.SetActive(true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        Button.SetActive(false);


    }


}
