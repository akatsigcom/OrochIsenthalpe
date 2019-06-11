﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnTriggerEnterDialogue : MonoBehaviour
{
    public OnClickDialogueTrigger trig;
    private bool done = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (done == false)
        {
            Debug.Log("Trigger detecté");

            trig.TriggerDialogue();
            done = true;
        }
    }
}
