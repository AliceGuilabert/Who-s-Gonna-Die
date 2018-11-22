using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {

    [SerializeField]
    private int timeNiveau;
    private float currentTime;

    public GameObject image;
    private Image myTimer;

    public delegate void TimerEventHandler();
    public static event TimerEventHandler EndOfTime;

    // Use this for initialization
    void Start () {
        currentTime = timeNiveau;
        myTimer = image.GetComponent<Image>();
        StartCoroutine(TimerFunction());
	}

    IEnumerator TimerFunction()
    {
        while (currentTime > 0)
        {
            if (!GetComponent<Pause>().onBreak) { 
                currentTime--;
                myTimer.fillAmount = currentTime / timeNiveau;
            }
            yield return new WaitForSeconds(1);
        }

        if (EndOfTime != null) EndOfTime();
    }


}
