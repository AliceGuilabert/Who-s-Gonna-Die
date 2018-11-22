using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level1_Animation : MonoBehaviour {

    public GameObject dog;
    public GameObject foule;
    public GameObject light;

    public GameObject car;
    private Animator dogAnimator;
    private Animator fouleAnimator1;
    private Animator fouleAnimator2;
    private Animator fouleAnimator3;
    private Animator feuAnimator;

    private Animator carAnimator;

    bool[] summary = new bool[3];

	// Use this for initialization
	void Start () {

        ChoicesHandler.OnAnimation += Init;

        dogAnimator = dog.GetComponent<Animator>();
        fouleAnimator1 = foule.transform.GetChild(0).GetComponent<Animator>();
        fouleAnimator2 = foule.transform.GetChild(1).GetComponent<Animator>();
        fouleAnimator3 = foule.transform.GetChild(2).GetComponent<Animator>();
        carAnimator = car.GetComponent<Animator>();
        feuAnimator = light.GetComponent<Animator>();
    }

    private void OnDestroy()
    {
        ChoicesHandler.OnAnimation -= Init;
    }


    public void Init(Dictionary<string, bool> choices)
    {
        summary[0] = choices["dog"];
        summary[1] = choices["foule"];
        summary[2] = choices["light"];

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

            GetComponent<LevelManager>().NumberOfDeath = 1;
            StartCoroutine(Scenario0());
        } else if (ArrayCompare3(summary, new bool[] { false, true, false }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 3;
            StartCoroutine(Scenario1());
        }
        else if (ArrayCompare3(summary, new bool[] { false, false, true }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 2;
            StartCoroutine(Scenario2());
        }
        else if (ArrayCompare3(summary, new bool[] { true, false, false }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 1;
            StartCoroutine(Scenario3());
        }
        else if (ArrayCompare3(summary, new bool[] { false, true, true }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 3;
            StartCoroutine(Scenario4());
        } 
        else if (ArrayCompare3(summary, new bool[] { true, false, true }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 0;
            StartCoroutine(Scenario5());
        }
        else if (ArrayCompare3(summary, new bool[] { true, true, false }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 4;
            StartCoroutine(Scenario6());
        }
        else if (ArrayCompare3(summary, new bool[] {true, true, true }))
        {
            GetComponent<LevelManager>().NumberOfDeath = 2;
            StartCoroutine(Scenario7());
        }
        
    }

    IEnumerator TestAnim()
    {
        
        yield return new WaitForSeconds(1);
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
        dogAnimator.SetTrigger("Route");
        carAnimator.SetTrigger("Up");

        AudioClip clip1 = Resources.Load<AudioClip>("Sounds/car_rolling");
        AudioClip clip2 = Resources.Load<AudioClip>("Sounds/bark_03");
        AudioSource as1 = GameObject.Find("Voiture").GetComponent<AudioSource>();
        AudioSource as2;
        as1.clip = clip1;
        as1.loop = false;
        as1.Play();

        yield return new WaitForSeconds(0.5f);

        as2 = GameObject.Find("Corgi").GetComponent<AudioSource>();
        as2.clip = clip2;
        as2.loop = false;
        as2.Play();

        yield return new WaitForSeconds(0.2f);

        playDeathSound();

        yield return new WaitForSeconds(0.3f);

        as1.Stop();
    }

    IEnumerator Scenario1()
    {
        Debug.Log("Debut Scénario1");

        carAnimator.SetTrigger("Up");
        dogAnimator.SetTrigger("Fuite");
        fouleAnimator3.SetTrigger("Traverse");
        yield return new WaitForSeconds(0.1f);
        fouleAnimator2.SetTrigger("Traverse");
        yield return new WaitForSeconds(0.1f);
        fouleAnimator1.SetTrigger("Route");
       

        yield return new WaitForSeconds(0.4f);
        
        AudioClip clip1 = Resources.Load<AudioClip>("Sounds/scream_male_01");
        AudioClip clip2 = Resources.Load<AudioClip>("Sounds/bark_02");
        AudioClip clip3 = Resources.Load<AudioClip>("Sounds/car_rolling");
        AudioSource as3 = GameObject.Find("Voiture").GetComponent<AudioSource>();
        as3.clip = clip3;
        as3.loop = false;
        as3.Play();

        AudioSource as1 = GameObject.Find("Corgi").GetComponent<AudioSource>();
        as1.clip = clip2;
        as1.loop = true;
        as1.Play();

        AudioSource as2 = GameObject.Find("Foule").GetComponent<AudioSource>();
        for (int i = 0; i < 3; ++i) {
            yield return new WaitForSeconds(0.3f);
            as2.clip = clip1;
            as2.loop = false;
            as2.Play();
        }

        for (int i = 0; i < 3; ++i) {
            yield return new WaitForSeconds(0.2f);
            playDeathSound();
        }

        as1.Stop();
        as3.Stop();
    }

    IEnumerator Scenario2()
    {
        Debug.Log("Debut Scénario2");

        feuAnimator.SetTrigger("Change");
        dogAnimator.SetTrigger("Attack");
        carAnimator.SetTrigger("Stop");
        fouleAnimator1.SetTrigger("Survive");

        AudioClip clip1 = Resources.Load<AudioClip>("Sounds/hostile_dog");
        AudioClip clip3 = Resources.Load<AudioClip>("Sounds/car_rolling");
        AudioSource as3 = GameObject.Find("Voiture").GetComponent<AudioSource>();
        AudioSource as2 = GameObject.Find("Corgi").GetComponent<AudioSource>();
        as2.clip = clip1;
        as2.loop = false;
        as2.Play();

        as3.clip = clip3;
        as3.loop = false;
        as3.Play();

        as3.Stop();

        yield return new WaitForSeconds(1.1f);
        fouleAnimator2.SetTrigger("Chien");
        fouleAnimator3.SetTrigger("Chien");
        AudioClip clip2 = Resources.Load<AudioClip>("Sounds/scream_male_01");
        AudioSource as1 = GameObject.Find("Foule").GetComponent<AudioSource>();
        for (int i = 0; i < 2; ++i) {
            yield return new WaitForSeconds(0.3f);
            as1.clip = clip2;
            as1.loop = false;
            as1.Play();
        }

        //yield return new WaitForSeconds(1);

        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < 2; ++i) {
            yield return new WaitForSeconds(0.2f);
            playDeathSound();
        }
    }

    IEnumerator Scenario3()
    {
        Debug.Log("Debut Scénario3");
        carAnimator.SetTrigger("Up");

        yield return new WaitForSeconds(0.09f);
        dogAnimator.SetTrigger("Route");
        

        yield return new WaitForSeconds(1);

        AudioClip clip1 = Resources.Load<AudioClip>("Sounds/bark_03");
        AudioSource as1 = GameObject.Find("Corgi").GetComponent<AudioSource>();
        as1.clip = clip1;
        as1.loop = false;
        as1.Play();

        yield return new WaitForSeconds(0.2f);

        playDeathSound();
    }

    IEnumerator Scenario4()
    {
        Debug.Log("Debut Scénario4");
        feuAnimator.SetTrigger("Change");
        dogAnimator.SetTrigger("Attack");
        fouleAnimator1.SetTrigger("Panique");
        
        fouleAnimator3.SetTrigger("Panique");
        carAnimator.SetTrigger("Stop");

        AudioClip clip1 = Resources.Load<AudioClip>("Sounds/hostile_dog");
        AudioClip clip2 = Resources.Load<AudioClip>("Sounds/scream_group_01");
        AudioSource as1 = GameObject.Find("Corgi").GetComponent<AudioSource>();
        as1.clip = clip1;
        as1.loop = false;
        as1.Play();

        yield return new WaitForSeconds(1f);
        fouleAnimator2.SetTrigger("Chien");

        yield return new WaitForSeconds(1);

        yield return new WaitForSeconds(0.2f);

        as1 = GameObject.Find("Foule").GetComponent<AudioSource>();
        as1.clip = clip2;
        as1.loop = false;
        as1.Play();

        for (int i = 0; i < 3; ++i) {
            yield return new WaitForSeconds(0.2f);
            playDeathSound();
        }
    }

    IEnumerator Scenario5()
    {
        Debug.Log("Debut Scénario5");
        feuAnimator.SetTrigger("Change");
        dogAnimator.SetTrigger("Traverse");
        carAnimator.SetTrigger("Stop");

        yield return new WaitForSeconds(1);
    }

    IEnumerator Scenario6()
    {
        Debug.Log("Debut Scénario6");

        carAnimator.SetTrigger("Up");
        dogAnimator.SetTrigger("Route");
        fouleAnimator1.SetTrigger("Panique");
        fouleAnimator2.SetTrigger("Traverse");
        fouleAnimator3.SetTrigger("Traverse");

        yield return new WaitForSeconds(0.5f);

        AudioClip clip1 = Resources.Load<AudioClip>("Sounds/bark_03");
        AudioClip clip2 = Resources.Load<AudioClip>("Sounds/scream_male_01");
        AudioClip clip3 = Resources.Load<AudioClip>("Sounds/car_rolling");
        AudioSource as1 = GameObject.Find("Corgi").GetComponent<AudioSource>();
        as1.clip = clip1;
        as1.loop = false;
        as1.Play();
        
        as1 = GameObject.Find("Foule").GetComponent<AudioSource>();

        for (int i = 0; i < 3; ++i) {
            yield return new WaitForSeconds(0.3f);
            as1.clip = clip2;
            as1.loop = false;
            as1.Play();
        }

        for (int i = 0; i < 3; ++i) {
            yield return new WaitForSeconds(0.3f);
            playDeathSound();
        }
    }

    IEnumerator Scenario7()
    {
        Debug.Log("Debut Scénario7");
        feuAnimator.SetTrigger("Change");
        dogAnimator.SetTrigger("Traverse");
        fouleAnimator1.SetTrigger("Panique");
        fouleAnimator2.SetTrigger("Panique");
        fouleAnimator3.SetTrigger("Panique");
        carAnimator.SetTrigger("Stop");
        yield return new WaitForSeconds(1);

        AudioClip clip1 = Resources.Load<AudioClip>("Sounds/scream_male_01");
        AudioClip clip2 = Resources.Load<AudioClip>("Sounds/scream_group_01");
        AudioSource as1 = GameObject.Find("Foule").GetComponent<AudioSource>();
        for (int i = 0; i < 2; ++i) {
            yield return new WaitForSeconds(0.5f);
            as1.clip = clip1;
            as1.loop = false;
            as1.Play();
        }
        
        /*yield return new WaitForSeconds(0.5f);
        as1.clip = clip2;
        as1.loop = false;
        as1.Play();*/

        for (int i = 0; i < 2; ++i) {
            yield return new WaitForSeconds(0.5f);
            playDeathSound();
        }
    }


}
