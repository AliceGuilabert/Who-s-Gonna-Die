using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monsieur : Interactable {

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
