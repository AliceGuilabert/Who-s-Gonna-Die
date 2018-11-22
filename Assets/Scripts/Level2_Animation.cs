using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level2_Animation : MonoBehaviour {

    public GameObject unluckyMen;
    public GameObject alarme;
    public GameObject animAlarme;
    public GameObject plaque;
    public GameObject corgi;

    public GameObject car;
	public GameObject potDeFleur;
	public GameObject velo;
	// rajouter audio pour déclencher le son de l'alarme
	
	
    private Animator unluckyMenAnimator;
	private Animator plaqueAnimator; // je sais pas si c'est judicieux un animator juste pour bouger un sprite mais bon
    private Animator potDeFleurAnimator; // le pot de fleur tombera de toute façon et se cassera, ptet pas besoin de trigger
    private Animator veloAnimator;
    private Animator corgiAnimator;
    private Animator carAnimator;
    private Animator animAlarmeAnimator;

    bool[] summary = new bool[3];

	// Use this for initialization
	void Start () {

        ChoicesHandler.OnAnimation += Init;

        unluckyMenAnimator = unluckyMen.GetComponent<Animator>();
        plaqueAnimator = plaque.GetComponent<Animator>();
        carAnimator = car.GetComponent<Animator>();
        potDeFleurAnimator= potDeFleur.GetComponent<Animator>();
		veloAnimator = velo.GetComponent<Animator>();
        corgiAnimator = corgi.GetComponent<Animator>();
        animAlarmeAnimator = animAlarme.GetComponent<Animator>();
    }

	
	public void Init(Dictionary<string, bool> choices)
    {
        summary[0] = choices["bouge"];
        summary[1] = choices["plaque"];
        summary[2] = choices["alarme"];

        ChooseAnimation();
    }


    bool ArrayCompare3(bool[] tab1, bool[] tab2)
    {
        if (tab1[0] == tab2[0] && tab1[1] == tab2[1] && tab1[2] == tab2[2]) return true;
        return false;
                
    }

    void ChooseAnimation()
    {
        if (ArrayCompare3(summary,new bool[]{ false, false, false }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 3;
            StartCoroutine(Scenario0());
        } else if (ArrayCompare3(summary, new bool[] { false, true, false }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 1;
            StartCoroutine(Scenario1());
        }
        else if (ArrayCompare3(summary, new bool[] { false, false, true }))
        {
            GetComponent<LevelManager>().NumberOfDeath =3;
            StartCoroutine(Scenario2());
        }
        else if (ArrayCompare3(summary, new bool[] { true, false, false }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 3;
            StartCoroutine(Scenario3());
        }
        else if (ArrayCompare3(summary, new bool[] { false, true, true }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 2;
            StartCoroutine(Scenario4());
        } 
        else if (ArrayCompare3(summary, new bool[] { true, false, true }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 2;
            StartCoroutine(Scenario5());
        }
        else if (ArrayCompare3(summary, new bool[] { true, true, false }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 1;
            StartCoroutine(Scenario6());
        }
        else if (ArrayCompare3(summary, new bool[] {true, true, true }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 1;
            StartCoroutine(Scenario7());
        }
        
    }

    void playDeathSound()
    {
        AudioClip clip = Resources.Load<AudioClip>("Sounds/point_05");
        AudioSource as1 = GetComponent<AudioSource>();
        as1.clip = clip;
        as1.loop = false;
        as1.Play();
    }

    IEnumerator Scenario0()
    {
        Debug.Log("Debut Scénario0");

        carAnimator.SetTrigger("GoForward");
        AudioClip clip1 = Resources.Load<AudioClip>("Sounds/car_rolling");
        AudioClip clip2 = Resources.Load<AudioClip>("Sounds/scream_male_01");
        AudioSource as1 = GameObject.Find("Voiture").GetComponent<AudioSource>();
        as1.clip = clip1;
        as1.loop = false;
        as1.Play();

        yield return new WaitForSeconds(0.1f);
        potDeFleurAnimator.SetTrigger("Fall");
		veloAnimator.SetTrigger("GoAndDie");
		corgiAnimator.SetTrigger("GoAndDie");

        yield return new WaitForSeconds(1.15f);
		unluckyMenAnimator.SetTrigger("Die");

        AudioSource as2 = GameObject.Find("movePerso_0").GetComponent<AudioSource>();
        as2.clip = clip2;
        as2.loop = false;
        as2.Play();

        as2 = GameObject.Find("velo").GetComponent<AudioSource>();
        yield return new WaitForSeconds(0.3f);
        as2.clip = clip2;
        as2.loop = false;
        as2.Play();

        for (int i = 0; i < 2; ++i) {
            yield return new WaitForSeconds(0.3f);
            playDeathSound();
        }

        yield return new WaitForSeconds(1);
        as1.Stop();
    }

    IEnumerator Scenario1()
    {
        Debug.Log("Debut Scénario1");

        AudioClip clip1 = Resources.Load<AudioClip>("Sounds/car_rolling");
        AudioSource as1 = GameObject.Find("Voiture").GetComponent<AudioSource>();
        as1.clip = clip1;
        as1.loop = false;
        as1.Play();
        carAnimator.SetTrigger("GoForward");

        potDeFleurAnimator.SetTrigger("Fall");
        plaqueAnimator.SetTrigger("egout");
        veloAnimator.SetTrigger("GoAndLive");

        yield return new WaitForSeconds(1f);        
        unluckyMenAnimator.SetTrigger("Die");
        yield return new WaitForSeconds(1.15f);
        corgiAnimator.SetTrigger("GoAndLive");

        yield return new WaitForSeconds(1);
    }

    IEnumerator Scenario2()
    {
        Debug.Log("Debut Scénario2");

        AudioClip clip1 = Resources.Load<AudioClip>("Sounds/alarm");
        AudioSource as1 = GameObject.Find("alarme").GetComponent<AudioSource>();
        as1.clip = clip1;
        as1.loop = false;
        as1.Play();

        animAlarmeAnimator.SetTrigger("On");

        AudioClip clip2 = Resources.Load<AudioClip>("Sounds/car_rolling");
        AudioSource as2 = GameObject.Find("Voiture").GetComponent<AudioSource>();
        as2.clip = clip2;
        as2.loop = false;
        as2.Play();

        carAnimator.SetTrigger("GoLeft");
        potDeFleurAnimator.SetTrigger("Fall");
        
        corgiAnimator.SetTrigger("GoAndDie");
        yield return new WaitForSeconds(0.15f);
        veloAnimator.SetTrigger("GoAndDie");
        yield return new WaitForSeconds(1f);
        unluckyMenAnimator.SetTrigger("Die");
        

        
        yield return new WaitForSeconds(1);
    }

    IEnumerator Scenario3()
    {
        AudioClip clip2 = Resources.Load<AudioClip>("Sounds/car_rolling");
        AudioSource as2 = GameObject.Find("Voiture").GetComponent<AudioSource>();
        as2.clip = clip2;
        as2.loop = false;
        as2.Play();

        carAnimator.SetTrigger("GoForward");

        
        veloAnimator.SetTrigger("GoAndDie");
		corgiAnimator.SetTrigger("GoAndDie");

        yield return new WaitForSeconds(1);
        unluckyMenAnimator.SetTrigger("GoAndDie");

        yield return new WaitForSeconds(1);
        potDeFleurAnimator.SetTrigger("Fall");
        yield return new WaitForSeconds(1);
    }

    IEnumerator Scenario4()
    {
        Debug.Log("Debut Scénario4");

        animAlarmeAnimator.SetTrigger("On");

        AudioClip clip2 = Resources.Load<AudioClip>("Sounds/car_rolling");
        AudioSource as2 = GameObject.Find("Voiture").GetComponent<AudioSource>();
        as2.clip = clip2;
        as2.loop = false;
        as2.Play();
        carAnimator.SetTrigger("GoLeft");

        AudioClip clip1 = Resources.Load<AudioClip>("Sounds/alarm");
        AudioSource as1 = GameObject.Find("alarme").GetComponent<AudioSource>();
        as1.clip = clip1;
        as1.loop = false;
        as1.Play();

        potDeFleurAnimator.SetTrigger("Fall");
        plaqueAnimator.SetTrigger("egout");

        veloAnimator.SetTrigger("GoAndDie");
        yield return new WaitForSeconds(1);
        unluckyMenAnimator.SetTrigger("Die");
        yield return new WaitForSeconds(1.15f);
		corgiAnimator.SetTrigger("GoAndLive");
        
        yield return new WaitForSeconds(1);
    }

    IEnumerator Scenario5()
    {
        Debug.Log("Debut Scénario5");

        AudioClip clip2 = Resources.Load<AudioClip>("Sounds/car_rolling");
        AudioSource as2 = GameObject.Find("Voiture").GetComponent<AudioSource>();
        as2.clip = clip2;
        as2.loop = false;
        as2.Play();
        carAnimator.SetTrigger("GoLeft");

        AudioClip clip1 = Resources.Load<AudioClip>("Sounds/alarm");
        AudioSource as1 = GameObject.Find("alarme").GetComponent<AudioSource>();
        as1.clip = clip1;
        as1.loop = false;
        as1.Play();

        animAlarmeAnimator.SetTrigger("On");

        potDeFleurAnimator.SetTrigger("Fall");
        veloAnimator.SetTrigger("GoAndDie");
		corgiAnimator.SetTrigger("GoAndDie");
		unluckyMenAnimator.SetTrigger("GoAndLive");


        yield return new WaitForSeconds(1);
    }

    IEnumerator Scenario6()
    {
        Debug.Log("Debut Scénario6");

        AudioClip clip2 = Resources.Load<AudioClip>("Sounds/car_rolling");
        AudioSource as2 = GameObject.Find("Voiture").GetComponent<AudioSource>();
        as2.clip = clip2;
        as2.loop = false;
        as2.Play();
        carAnimator.SetTrigger("GoForward");

       
        plaqueAnimator.SetTrigger("egout");
        veloAnimator.SetTrigger("GoAndLive");

        yield return new WaitForSeconds(1);
        unluckyMenAnimator.SetTrigger("GoAndDie");
        yield return new WaitForSeconds(1);
        potDeFleurAnimator.SetTrigger("Fall");
        corgiAnimator.SetTrigger("GoAndLive");

        yield return new WaitForSeconds(1);
    }

    IEnumerator Scenario7()
    {
        Debug.Log("Debut Scénario7");

        AudioClip clip2 = Resources.Load<AudioClip>("Sounds/car_rolling");
        AudioSource as2 = GameObject.Find("Voiture").GetComponent<AudioSource>();
        as2.clip = clip2;
        as2.loop = false;
        as2.Play();
        carAnimator.SetTrigger("GoLeft");

        AudioClip clip1 = Resources.Load<AudioClip>("Sounds/alarm");
        AudioSource as1 = GameObject.Find("alarme").GetComponent<AudioSource>();
        as1.clip = clip1;
        as1.loop = false;
        as1.Play();
        animAlarmeAnimator.SetTrigger("On");

        potDeFleurAnimator.SetTrigger("Fall");
        plaqueAnimator.SetTrigger("egout");
        unluckyMenAnimator.SetTrigger("GoAndLive");

        yield return new WaitForSeconds(0.15f);
        veloAnimator.SetTrigger("GoAndDie");
        yield return new WaitForSeconds(2);
        corgiAnimator.SetTrigger("GoAndLive");
		
		
        yield return new WaitForSeconds(1);
    }


}
