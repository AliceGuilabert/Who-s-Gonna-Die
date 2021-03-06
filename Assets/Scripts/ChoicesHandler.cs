﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoicesHandler : MonoBehaviour {

    bool first;
    DialogueDisplay myDialog;
    public List<Interactable> objInScene;
    Dictionary<string, bool> choices = new Dictionary<string, bool>();

    public delegate void InteractEventHandler(Dictionary<string, bool> choices);
    public static event InteractEventHandler OnAnimation;

    // Use this for initialization
    void Start()
    {
        first = true;
    }

    private void Update()
    {
        if (first)
        {
            first = false;
        }
    }


    public void Next()
    {
        foreach (Interactable obj in objInScene)
        {
            choices.Add(obj.nameObject, obj.isActive);
        }

        if (OnAnimation != null)
        {
            OnAnimation(choices);
        }
    }
}
