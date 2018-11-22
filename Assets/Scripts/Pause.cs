using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour {
    public bool onBreak = false;
    public GameObject breakMenuContainer;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnBreakButton()
    {
        if (!onBreak) {
            onBreak = true;
            breakMenuContainer.SetActive(true);

        } else {
            onBreak = false;
            breakMenuContainer.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
