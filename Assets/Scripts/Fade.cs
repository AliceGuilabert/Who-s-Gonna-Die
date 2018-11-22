using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour {

    public Image fadeImage;
    public Animator fadeAnimator;

    public bool doing;

    private void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        doing = true;
        fadeImage.GetComponent<Image>().enabled = true;
        fadeAnimator.SetBool("Fade", false);
        yield return new WaitUntil(() => fadeImage.color.a == 0);
        fadeImage.GetComponent<Image>().enabled = false;
        doing = false;
    }

    public IEnumerator FadeOut()
    {
        doing = true;
        fadeImage.GetComponent<Image>().enabled = true;
        fadeAnimator.SetBool("Fade", true);
        yield return new WaitUntil(() => fadeImage.color.a == 1);
        doing = false;
    }
}
