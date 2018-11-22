using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum AgePerso
{
    SPERM,
    BABY,
    ADULT,
    OLD,
    GRAVE
}
public class LevelManager : MonoBehaviour {
    public AgePerso age { get; set; }

    private int objectifLevel;

    public bool victory = false;
    public bool endOfLevel = false;
    public int NumberOfDeath;

    public int indexDialogueBeginYoung;
    public int indexDialogueBeginAdult;
    public int indexDialogueBeginOld;

    private int indexDialogueBegin;

    public int indexDialogueYoungFail;
    public int indexDialogueSuccess;
    public int indexDialogueOldFail;

    public int indexDialogueYoungLessFail;
    public int indexDialogueYoungSuccess;
    public int indexDialogueYoungManyFail;

    public int indexDialogueAdultLessFail;
    public int indexDialogueAdultSuccess;
    public int indexDialogueAdultManyFail;

    public int indexDialogueOldLessFail;
    public int indexDialogueOldSuccess;
    public int indexDialogueOldManyFail;

    private bool begin = true;

    ChoicesHandler myChoices;

    Sprite YOUNG;
    Sprite ADULT;
    Sprite OLD;

    // Use this for initialization
    void Start () {

        age = EndLevel.currentEtat;
        objectifLevel = EndLevel.objectif;

        // fonduTimeBreak = GameObject.Find("TimeColorFilter").GetComponent<Animator>();
        YOUNG = Resources.Load<Sprite>("jeune");      //FULL
        ADULT = Resources.Load<Sprite>("adulte");    //-1
        OLD = Resources.Load<Sprite>("vieux");  //-2
        GameObject faceHolder = GameObject.Find("FaceHolder");
        switch (age)
        {
            case AgePerso.BABY:
                //Load image Baby
                faceHolder.GetComponent<Image>().sprite = YOUNG;
                indexDialogueBegin = indexDialogueBeginYoung;
                break;
            case AgePerso.ADULT:
                //Load image Adult
                faceHolder.GetComponent<Image>().sprite = ADULT;
                indexDialogueBegin = indexDialogueBeginAdult;
                break;
            case AgePerso.OLD:
                //Load image Old
                faceHolder.GetComponent<Image>().sprite = OLD;
                indexDialogueBegin = indexDialogueBeginOld;
                break;
            default:
                Debug.LogError("Age non valide");
                break;
        }

        Timer.EndOfTime += EndTime;
        myChoices = GetComponent<ChoicesHandler>();
    }

    private void Update()
    {
        if (begin) {
            GetComponent<DialogueDisplay>().RunDialogue(indexDialogueBegin);
            begin = false;
        }
    }

    public void EndTime()
    {
        Debug.Log("C'est finiis");
        //GameObject.Find("Chrono").GetComponent<AudioSource>().Play();

        GameObject[] hl = GameObject.FindGameObjectsWithTag("Highlight");
        GameObject[] actions = GameObject.FindGameObjectsWithTag("Actions");

        for (int i = 0; i < hl.Length; ++i) {
            hl[i].SetActive(false);
        }

        for (int i = 0; i < actions.Length; ++i) {
            actions[i].SetActive(false);
        }

        GameObject.Find("Chrono").transform.Find("background").gameObject.SetActive(false);

        AudioSource audioSource = GameObject.Find("Maps").GetComponent<AudioSource>();
        audioSource.Play();

        myChoices.Next();

        if (NumberOfDeath < objectifLevel) {
            GetComponent<DialogueDisplay>().RunDialogue(indexDialogueYoungFail);
        } else if (NumberOfDeath > objectifLevel) {
            GetComponent<DialogueDisplay>().RunDialogue(indexDialogueOldFail);
        } else {
            GetComponent<DialogueDisplay>().RunDialogue(indexDialogueSuccess);
            victory = true;

            /*AudioClip clip1 = Resources.Load<AudioClip>("Sounds/victory_01");
            AudioSource as1 = GetComponent<AudioSource>();
            as1.clip = clip1;
            as1.loop = false;
            as1.Play();*/
        }
        endOfLevel = true;
        EndLevel.morts = NumberOfDeath;
        StartCoroutine(Load());
    }

    IEnumerator Load()
    {
        yield return new WaitForSeconds(5);
        GetComponent<Fade>().FadeOut();
        yield return new WaitWhile(() => GetComponent<Fade>().doing);
        SceneManager.LoadScene("FinMission");
    }

}
