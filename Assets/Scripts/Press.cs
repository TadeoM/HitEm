using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Press : MonoBehaviour {

    public bool isPressed;
    public bool wasChecked;

	// Use this for initialization
	void Start () {
        isPressed = false;
        wasChecked = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (wasChecked == true)
            wasChecked = false;
	}

    private void OnMouseDown()
    {
        //Debug.Log("Pressing");
        isPressed = true;
    }
}
