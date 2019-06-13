using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPlaine : MonoBehaviour
{
    public AutomaticDialogueTrigger trig;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (GameManager.SetFtPlaine() == false)
        {
            Debug.Log("Trigger detecté");

            trig.TriggerDialogue();
            GameManager.GetFtPlaine(true);
        }
    }
}
