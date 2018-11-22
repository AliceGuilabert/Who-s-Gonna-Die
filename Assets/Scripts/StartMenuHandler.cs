using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuHandler : MonoBehaviour {

    Fade myFade;

    private void Start()
    {
        myFade = GetComponent<Fade>();
    }

    public void Action(int nbFonction)
    {
        switch (nbFonction) {
            case (1):
                StartCoroutine(StartJeux());
                break;
            case (2):
                StartCoroutine(Quitter());
                break;
            default:
                break;
        }
    }

    IEnumerator StartJeux()
    {
        StartCoroutine(myFade.FadeOut());
        yield return new WaitWhile(() => myFade.doing);
        SceneManager.LoadScene("Intro");
    }

    IEnumerator Quitter()
    {
        StartCoroutine(myFade.FadeOut());
        yield return new WaitWhile(() => myFade.doing);
        Application.Quit();
    }
}
