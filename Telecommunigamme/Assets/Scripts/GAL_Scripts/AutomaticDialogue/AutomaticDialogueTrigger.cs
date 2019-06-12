using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class AutomaticDialogueTrigger : DialogueTrigger
{

    public AutomaticDialogueTrigger() {}

    new public void TriggerDialogue()
    {
        dialogue = load_dialogue(dialoguePath);
        FindObjectOfType<AutomaticDialogueManager>().StartDialogue(dialogue);
    }


}
