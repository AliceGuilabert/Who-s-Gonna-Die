using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;

public class Dialogue {

    public List<DialogueNode> Nodes;

    public Dialogue()
    {
        Nodes = new List<DialogueNode>();
    }

    public static Dialogue LoadDialogue(string name)
    {

        XmlSerializer serz = new XmlSerializer(typeof(Dialogue));
        StreamReader reader = new StreamReader(Application.dataPath + "/StreamingAssets/" + name);

        Dialogue dia = (Dialogue)serz.Deserialize(reader);

        return dia;
    }

}
