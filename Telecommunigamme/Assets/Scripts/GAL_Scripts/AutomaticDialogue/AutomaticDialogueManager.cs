using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticDialogueManager : DialogueManager
{
    private float update;

    public int discutionDelay = 3;

    public AutomaticDialogueManager() { }

    private void Update()
    {
        update += Time.deltaTime;
        if (update > (float)discutionDelay)
        {
            update = 0.0f;
            DisplayNextSentence();
        }

    }
    void WaitNextSentence()
    {
        Update();
    }

}
