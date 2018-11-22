using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foule : Interactable {

    public void Actif()
    {
        //Debug.Log("Pushing car");
        isActive = true;
        ToggleButton();
    }

    public void Inactif()
    {
        //Debug.Log("Entering car");
        isActive = false;
        ToggleButton();
    }
}
