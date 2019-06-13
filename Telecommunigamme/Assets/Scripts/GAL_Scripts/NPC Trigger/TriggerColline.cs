using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerColline : MonoBehaviour
{
    public OnClickDialogueTrigger trig;

    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.SetFtColline() == false)
        {
            Debug.Log("Trigger detecté");

            trig.TriggerDialogue();
            GameManager.GetFtColline(true);
        }
    }
}
