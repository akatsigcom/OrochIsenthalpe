using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class TriggerAveugle : MonoBehaviour
{
    public string dialoguePath_FirstMeet;
    public string dialoguePath_LoopDia;


    public void TriggerDialogue()
    {
        Dialogue dialogue = new Dialogue();
        if (GameManager.SetFtAveugle() == false)
        {
            dialogue = load_dialogue(dialoguePath_FirstMeet);
            FindObjectOfType<OnClickDialogueManager>().StartDialogue(dialogue);
            GameManager.GetFtAveugle(true);
        }
        else
        {
            dialogue = load_dialogue(dialoguePath_LoopDia);
            FindObjectOfType<OnClickDialogueManager>().StartDialogue(dialogue);
        }
        
    }

    private static Dialogue load_dialogue(string path)
    {
        XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
        StreamReader reader = new StreamReader(path);

        Dialogue dia = (Dialogue)serz.Deserialize(reader);
        return dia;
    }
}
