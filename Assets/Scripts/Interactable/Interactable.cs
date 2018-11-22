using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Interactable : MonoBehaviour {
    public string nameObject;
    public bool isActive;
    public int indexDialogue;

    public GameObject canvas;
    public GameObject hlObj;

    public bool isHL;

    private void Start()
    {
        isHL = false;
    }

    void OnMouseDown()
    {
        ToggleButton();

        /*RaycastHit hit = new RaycastHit();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit)) {
            if (hit.collider.gameObject == this.gameObject) {
                Debug.Log("Click!!!");
                //ToggleButton();
            } else {
                Debug.Log("Click outside");

            }
        } else {
            Debug.Log("Click outside of any object");
        }*/
    }

    private void OnMouseOver()
    {
        if (isHL || canvas.activeSelf || FindObjectOfType<Pause>().onBreak || GameObject.Find("LevelManager").GetComponent<LevelManager>().endOfLevel)
            return;
        hlObj.SetActive(true);
        isHL = true;
    }

    private void OnMouseExit()
    {
        if (isHL && !canvas.activeSelf && !FindObjectOfType<Pause>().onBreak) {
            hlObj.SetActive(false);
            isHL = false;
        }
    }

    public void ToggleButton()
    {
        if (!canvas.activeSelf && !FindObjectOfType<Pause>().onBreak && !GameObject.Find("LevelManager").GetComponent<LevelManager>().endOfLevel) {
            canvas.SetActive(true);
            GameObject.Find("LevelManager").GetComponent<DialogueDisplay>().RunDialogue(indexDialogue);
            GameObject op1 = canvas.transform.Find("activer").gameObject;
            GameObject op2 = canvas.transform.Find("desactiver").gameObject;
            if (isActive) {
                op1.GetComponent<Text>().color = Color.red;
                op2.GetComponent<Text>().color = Color.black;
            } else {
                op1.GetComponent<Text>().color = Color.black;
                op2.GetComponent<Text>().color = Color.red;
            }
            AudioSource audioSource = GetComponent<AudioSource>();
            AudioClip clip = Resources.Load<AudioClip>("Sounds/good_click_02");
            audioSource.clip = clip;
            audioSource.Play();
        } else {
            canvas.SetActive(false);
        }
    }
}
