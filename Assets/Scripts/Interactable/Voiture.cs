using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Voiture : Interactable {

    public void Actif()
    {
        //Debug.Log("Pushing car");
        isActive = true;
    }

    public void Inactif()
    {
        //Debug.Log("Entering car");
        isActive = false;
    }
}
