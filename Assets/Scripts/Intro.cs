using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Intro : MonoBehaviour {

    DialogueDisplay myDiag;
    bool first;

    private void Start()
    {
        myDiag = GetComponent<DialogueDisplay>();
        first = true;
    }

    private void Update()
    {
        if(first)
        {
            StartCoroutine(PlayIntro());
            first = false;
        }
    }
    IEnumerator PlayIntro()
    {
        yield return new WaitForSeconds(0.5f);
        AudioSource as1 = GameObject.Find("presentation").GetComponent<AudioSource>();
        as1.Play();
        myDiag.RunDialogue(0);
        yield return new WaitWhile(() => !myDiag.endDisplayDialogue);
        as1.Stop();
        yield return new WaitWhile(() => myDiag.onDialogue);
        as1.Play();
        myDiag.RunDialogue(1);
        yield return new WaitWhile(() => !myDiag.endDisplayDialogue);
        as1.Stop();
        yield return new WaitWhile(() => myDiag.onDialogue);
        as1.Play();
        myDiag.RunDialogue(2);
        yield return new WaitWhile(() => !myDiag.endDisplayDialogue);
        as1.Stop();
        yield return new WaitWhile(() => myDiag.onDialogue);
        as1.Play();
        myDiag.RunDialogue(3);
        yield return new WaitWhile(() => !myDiag.endDisplayDialogue);
        as1.Stop();
        yield return new WaitWhile(() => myDiag.onDialogue);
        as1.Play();
        myDiag.RunDialogue(4);
        yield return new WaitWhile(() => !myDiag.endDisplayDialogue);
        as1.Stop();
        yield return new WaitWhile(() => myDiag.onDialogue);
        as1.Play();
        myDiag.RunDialogue(5);
        yield return new WaitWhile(() => !myDiag.endDisplayDialogue);
        as1.Stop();
        yield return new WaitWhile(() => myDiag.onDialogue);
        as1.Play();
        myDiag.RunDialogue(6);
        yield return new WaitWhile(() => !myDiag.endDisplayDialogue);
        as1.Stop();
        yield return new WaitWhile(() => myDiag.onDialogue);
        as1.Play();
        myDiag.RunDialogue(7);
        yield return new WaitWhile(() => !myDiag.endDisplayDialogue);
        as1.Stop();
        yield return new WaitWhile(() => myDiag.onDialogue);

        yield return new WaitForSeconds(1f);
        StartCoroutine(GetComponent<Fade>().FadeOut());
        yield return new WaitWhile(() => GetComponent<Fade>().doing);
        SceneManager.LoadScene("PrezMission1");
    }
}
