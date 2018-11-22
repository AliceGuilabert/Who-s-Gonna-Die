using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueDisplay : MonoBehaviour
{
    public bool endDisplayDialogue;

    public bool onDialogue;

    private Dialogue dia;

    private GameObject dialogue_window;

    private GameObject node_text;

    public string DialogueDataFileName;

    // Use this for initialization
    void Start()
    {
        onDialogue = false;
        endDisplayDialogue = false;

        dia = Dialogue.LoadDialogue(DialogueDataFileName);
        dialogue_window = GameObject.Find("Dialogue");

        node_text = GameObject.Find("TextDialogue");

        dialogue_window.SetActive(false);
    }

    public void RunDialogue(int nodeStart)
    {
        onDialogue = true;
        dialogue_window.SetActive(true);
        StartCoroutine(AnimateText(dia.Nodes[nodeStart]));
    }

    public void EndDialogue(Text texte)
    {
        texte.text = "...";
        dialogue_window.SetActive(false);
        onDialogue = false;
    }


    private IEnumerator AnimateText(DialogueNode node)
    {
        string strComplete = node.Text;
        int i = 0;
        node_text.GetComponent<Text>().text = "";
        yield return new WaitForSeconds(0.1F);
        while (i < strComplete.Length && !Input.GetMouseButton(0))
        {
            node_text.GetComponent<Text>().text += strComplete[i++];
            yield return new WaitForSeconds(0.02F);
        }

        if(i != strComplete.Length)
        {
            node_text.GetComponent<Text>().text = node.Text;
        }
        endDisplayDialogue = true;
        yield return new WaitForSeconds(0.3F);

        while (!Input.GetMouseButton(0))
        {
            yield return new WaitForSeconds(0.02F);
        }

        endDisplayDialogue = false;
        EndDialogue(node_text.GetComponent<Text>());

    }

}

