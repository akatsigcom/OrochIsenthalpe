using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickDialogueManager : DialogueManager
{
    public OnClickDialogueManager() { }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("IsOpen", true);
        GameManager.instance.DeactivateMove();

        speeches.Clear();
        sentences.Clear();

        foreach (Speech speech in dialogue.discution)
        {
            speeches.Enqueue(speech);
        }

        DisplayNextSpeech();

    }

    void EndDialogue()
    {

        animator.SetBool("IsOpen", false);
        GameManager.instance.ActivateMove();

    }
}
