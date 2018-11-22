using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour {


    Fade myFade;

    private void Start()
    {
        myFade = GetComponent<Fade>();
    }

    public void Action(int nbFonction)
    {
        switch (nbFonction) {
            case (1):
                StartCoroutine(Restart());
                break;
            case (2):
                StartCoroutine(QuitterJeux());
                break;
            default:
                break;
        }
    }

    IEnumerator QuitterJeux()
    {
        StartCoroutine(myFade.FadeOut());
        yield return new WaitWhile(() => myFade.doing);
        Application.Quit();
    }

    IEnumerator Restart()
    {
        StartCoroutine(myFade.FadeOut());
        yield return new WaitWhile(() => myFade.doing);
        SceneManager.LoadScene("Intro");
    }
}
