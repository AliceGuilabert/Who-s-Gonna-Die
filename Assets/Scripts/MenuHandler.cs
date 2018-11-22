using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuHandler : MonoBehaviour {

    Fade myFade;

    private void Start()
    {
        myFade = GetComponent<Fade>();
    }

    public void Action(int nbFonction)
    {
        switch (nbFonction)
        {
            case (1):
                StartCoroutine(StartMission1());
                break;
            case (2):
                StartCoroutine(StartMission2());
                break;
            default:
                break;
        }
    }

    IEnumerator StartMission1()
    {
        StartCoroutine(myFade.FadeOut());
        yield return new WaitWhile(() => myFade.doing);
        SceneManager.LoadScene("Level1");
    }

    IEnumerator StartMission2()
    {
        StartCoroutine(myFade.FadeOut());
        yield return new WaitWhile(() => myFade.doing);
        SceneManager.LoadScene("Level2");
    }

}
