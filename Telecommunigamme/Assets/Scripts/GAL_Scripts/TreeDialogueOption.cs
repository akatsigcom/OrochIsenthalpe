using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDialogueOption
{
    public string Text;
    public int DestinationNodeID;

    public TreeDialogueOption() { }

    public TreeDialogueOption(string text, int dest)
    {
        this.Text = text;
        this.DestinationNodeID = dest;
    }
}
