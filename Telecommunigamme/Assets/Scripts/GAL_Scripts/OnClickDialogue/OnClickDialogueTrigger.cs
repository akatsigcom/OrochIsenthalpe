using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnClickDialogueTrigger : DialogueTrigger
{
    public OnClickDialogueTrigger() { }

    public void TriggerDialogue()
    {
        dialogue = load_dialogue(dialoguePath);
        FindObjectOfType<OnClickDialogueManager>().StartDialogue(dialogue);
    }

    public void TriggerDialogue(Dialogue dia)
    {
        FindObjectOfType<OnClickDialogueManager>().StartDialogue(dia);
    }

    public void TriggerDialogue(string chem)
    {
        dialogue = load_dialogue(chem);
        FindObjectOfType<OnClickDialogueManager>().StartDialogue(dialogue);
    }
}
