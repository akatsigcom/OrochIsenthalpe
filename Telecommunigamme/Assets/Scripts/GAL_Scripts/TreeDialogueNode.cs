using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeDialogueNode
{
    public int nodeID = -1;
    public Dialogue Text;
    public string Question; 
    public List<TreeDialogueOption> Options;

    public TreeDialogueNode()
    {
        Options = new List<TreeDialogueOption>();
    }

    public TreeDialogueNode(Dialogue text)
    {
        Text = text;
        Options = new List<TreeDialogueOption>();
    }
}
