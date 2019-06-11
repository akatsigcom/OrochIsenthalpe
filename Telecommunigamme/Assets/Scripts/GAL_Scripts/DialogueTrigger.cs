using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

public class DialogueTrigger : MonoBehaviour
{
    public string dialoguePath;

    protected Dialogue dialogue;


    protected static Dialogue load_dialogue(string path)
    {
        XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
        StreamReader reader = new StreamReader(path);

        Dialogue dia = (Dialogue)serz.Deserialize(reader);
        return dia;
    }



}
