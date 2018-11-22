using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Corgi : Interactable {
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
