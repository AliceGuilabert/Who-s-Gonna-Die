using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class DialogueNode {

    public int NodeID = -1;
    public string Text;

    public DialogueNode() { }

    public DialogueNode(string text)
    {
        Text = text;
    }
}
