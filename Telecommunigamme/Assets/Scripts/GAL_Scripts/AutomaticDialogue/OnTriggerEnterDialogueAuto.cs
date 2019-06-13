using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterDialogueAuto : MonoBehaviour
{
    public AutomaticDialogueTrigger trig;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
            trig.TriggerDialogue();

    }
}
