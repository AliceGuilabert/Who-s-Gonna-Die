using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabObject : MonoBehaviour {
    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;

    private bool grab = true;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!grab)
            return;

        float moveLR = Input.GetAxis("Mouse X") * mouseSensitivityX * Time.deltaTime;
        float moveUD = Input.GetAxis("Mouse Y") * mouseSensitivityY * Time.deltaTime;

        Vector3 mouse = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        transform.position = new Vector3(mouse.x, mouse.y, transform.position.z);
        Debug.Log("1");
    }

    /*public void toggleGrab()
    {
        if (grab)
            grab = false;
        else
            grab = true;
    }*/
}
