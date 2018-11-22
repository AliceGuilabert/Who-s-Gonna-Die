using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoucheEgout : Interactable {

    private void OnMouseDown()
    {
        GameObject g = GameObject.Find("LevelManager");
        LevelManager lm = g.GetComponent<LevelManager>();
        DialogueDisplay dialogue = g.GetComponent<DialogueDisplay>();
        if (lm.age == AgePerso.OLD) {
            dialogue.RunDialogue(9);
            isHL = true;
        } else
            ToggleButton();
    }

    public void Actif()
    {
        isActive = true;
        ToggleButton();
    }

    public void Inactif()
    {
        isActive = false;
        ToggleButton();
    }
}
