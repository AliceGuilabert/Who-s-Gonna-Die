using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alarme : Interactable {

    private void OnMouseDown()
    {
        GameObject g = GameObject.Find("LevelManager");
        LevelManager lm = g.GetComponent<LevelManager>();
        DialogueDisplay dialogue = g.GetComponent<DialogueDisplay>();
        if (lm.age == AgePerso.BABY) {
            dialogue.RunDialogue(10);
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
