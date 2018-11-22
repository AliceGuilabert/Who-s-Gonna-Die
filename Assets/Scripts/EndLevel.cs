using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLevel : MonoBehaviour {

    #region Singleton

    public static EndLevel instance;

    void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("More than one instance of EndLevel found!");
            return;
        }

        instance = this;
    }

    #endregion

    public static AgePerso currentEtat = AgePerso.ADULT;
    public static int objectif = 2;
    public static int morts = 0;

    public static int nbLevel = 1;

}
