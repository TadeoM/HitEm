using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    bool onMenu;
    public GameObject start;
    public GameObject instructions;
    public GameObject quit;
    public GameObject rulesBox;
    public GameObject returnBut;

	// Use this for initialization
	void Start () {
		onMenu = true;
    }
	
	// Update is called once per frame
	void Update () {
		if (start.GetComponent<Press>().isPressed)
        {
            start.GetComponent<Press>().isPressed = false;
            SceneManager.LoadScene("main", LoadSceneMode.Single);
        }
        else if (instructions.GetComponent<Press>().isPressed)
        {
            Debug.Log("Interupt");
            instructions.GetComponent<Press>().isPressed = false;
            start.SetActive(false);
            instructions.SetActive(false);
            quit.SetActive(false);
            rulesBox.SetActive(true);
            returnBut.SetActive(true);
        }
        else if (quit.GetComponent<Press>().isPressed)

        {
            quit.GetComponent<Press>().isPressed = false;
            Application.Quit();
        }
        else if(returnBut.GetComponent<Press>().isPressed)
        {
            Debug.Log("Pressing");
            returnBut.GetComponent<Press>().isPressed = false;
            start.SetActive(true);
            instructions.SetActive(true);
            quit.SetActive(true);
            rulesBox.SetActive(false);
            returnBut.SetActive(false);
        }
    }
}
