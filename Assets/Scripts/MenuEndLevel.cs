using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuEndLevel : MonoBehaviour {

    public Text _objectif;
    public Text _morts;
    public Text commentaire;

    private AgePerso _currentAge;
    private AgePerso nextEtat;

    private int _currentLevel;

    private EndLevel myEnd;

    Sprite SPERM;
    Sprite YOUNG;
    Sprite ADULT;
    Sprite OLD;
    Sprite GRAVE;

    bool changing;

    public Animator fadeIN;
    public Animator fadeOUT;

    // Use this for initialization
    void Start () {
        myEnd = EndLevel.instance;

        SPERM = Resources.Load<Sprite>("sperme");
        YOUNG = Resources.Load<Sprite>("jeune");      //FULL
        ADULT = Resources.Load<Sprite>("adulte");    //-1
        OLD = Resources.Load<Sprite>("vieux");  //-2
        GRAVE = Resources.Load<Sprite>("grave");

        _objectif.text = EndLevel.objectif.ToString();
        _morts.text = EndLevel.morts.ToString();
        _currentAge = EndLevel.currentEtat;
        _currentLevel = EndLevel.nbLevel;

        Commentaire();

        switch (_currentAge)
        {
            case AgePerso.BABY:
                fadeOUT.SetTrigger("EtatBaby");
                break;
            case AgePerso.ADULT:
                fadeOUT.SetTrigger("EtatAdult");
                break;
            case AgePerso.OLD:
                fadeOUT.SetTrigger("EtatOld");
                break;
            default:
                break;
        }     
    }
	

    void Commentaire() { 
       if(_currentLevel == 1)
        {
            if (EndLevel.morts > EndLevel.objectif)
            {
                commentaire.text = "Bientôt l'heure de la retraite.";
                nextEtat = AgePerso.OLD;
            } else if (EndLevel.morts < EndLevel.objectif)
            {
                commentaire.text = "Même un enfant ferait mieux.";
                nextEtat = AgePerso.BABY;
            } else
            {
                commentaire.text = "Voilà un administrateur efficace !";
                nextEtat = AgePerso.ADULT;
            } 
        } else
        {
            if (EndLevel.morts > EndLevel.objectif)
            {
                if (_currentAge.Equals(AgePerso.ADULT))
                {
                    commentaire.text = "Bientôt l'heure de la retraite.";
                    nextEtat = AgePerso.OLD;
                }
                else if (_currentAge.Equals(AgePerso.BABY))
                {
                    commentaire.text = "Bien rattrapé gamin.";
                    nextEtat = AgePerso.ADULT;
                }
                else if (_currentAge.Equals(AgePerso.OLD))
                {
                    commentaire.text = "Ton heure a sonné ...";
                    nextEtat = AgePerso.GRAVE;
                }
                else Debug.LogError("Problème ici");

            }
            else if (EndLevel.morts < EndLevel.objectif)
            {
                if (_currentAge.Equals(AgePerso.ADULT))
                {
                    commentaire.text = "Même un enfant ferait mieux.";
                    nextEtat = AgePerso.BABY;
                }
                else if (_currentAge.Equals(AgePerso.BABY))
                {
                    commentaire.text = "Une bien triste fin ...";
                    nextEtat = AgePerso.SPERM;
                }
                else if (_currentAge.Equals(AgePerso.OLD))
                {
                    commentaire.text = "Bien rattrapé papi.";
                    nextEtat = AgePerso.ADULT;
                }
                else Debug.LogError("Problème ici");
            }
            else
            {
                if (_currentAge.Equals(AgePerso.ADULT))
                {
                    commentaire.text = "Voilà un administrateur efficace.";
                    nextEtat = AgePerso.ADULT;
                }
                else if (_currentAge.Equals(AgePerso.BABY))
                {
                    commentaire.text = "Voilà un enfant bien dégourdi.";
                    nextEtat = AgePerso.BABY;
                }
                else if (_currentAge.Equals(AgePerso.OLD))
                {
                    commentaire.text = "Papi a de la ressource !";
                    nextEtat = AgePerso.OLD;
                }
                else Debug.LogError("Problème ici");
            }
        }
    }


    public void End()
    {
        StartCoroutine(ChangeFaceEnd());
    }

    IEnumerator ChangeFaceEnd ()
    {
        switch (_currentAge)
        {
            case AgePerso.BABY:
                fadeOUT.SetTrigger("Baby");
                break;
            case AgePerso.ADULT:
                fadeOUT.SetTrigger("Adult");
                break;
            case AgePerso.OLD:
                fadeOUT.SetTrigger("Old");
                break;
            default:
                Debug.LogError("Non valide");
                break;
        }
        yield return new WaitForSeconds(0.3f);

        switch (nextEtat)
        {
            case AgePerso.SPERM:
                fadeIN.SetTrigger("Sperm");
                break;
            case AgePerso.BABY:
                fadeIN.SetTrigger("Baby");
                break;
            case AgePerso.ADULT:
                fadeIN.SetTrigger("Adult");
                break;
            case AgePerso.OLD:
                fadeIN.SetTrigger("Old");
                break;
            case AgePerso.GRAVE:
                fadeIN.SetTrigger("Grave");
                break;
            default:
                break;
        }

        yield return new WaitForSeconds(3);
        
        if(_currentLevel == 1)
        {
            EndLevel.objectif = 2;
            EndLevel.nbLevel = 2;
            EndLevel.morts = 0;
            EndLevel.currentEtat = nextEtat;
            GetComponent<Fade>().FadeOut();
            yield return new WaitWhile(() => GetComponent<Fade>().doing);
            SceneManager.LoadScene("PrezMission2");
        } else
        {
            GetComponent<Fade>().FadeOut();
            yield return new WaitWhile(() => GetComponent<Fade>().doing);

            if(nextEtat.Equals(AgePerso.GRAVE)) SceneManager.LoadScene("GameOverOld");
            else if (nextEtat.Equals(AgePerso.SPERM)) SceneManager.LoadScene("GameOverYoung");
            else SceneManager.LoadScene("Victory");
        }
    }
	
}
