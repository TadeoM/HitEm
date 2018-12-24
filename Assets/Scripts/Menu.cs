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
		/*if (start.GetComponent<Press>().isPressed)
        {
            start.GetComponent<Press>().isPressed = false;
            
        }
        else if (instructions.GetComponent<Press>().isPressed)
        {
            Debug.Log("Interupt");
            instructions.GetComponent<Press>().isPressed = false;
            
        }
        else if (quit.GetComponent<Press>().isPressed)

        {
            quit.GetComponent<Press>().isPressed = false;
            
        }
        else if(returnBut.GetComponent<Press>().isPressed)
        {
            Debug.Log("Pressing");
            returnBut.GetComponent<Press>().isPressed = false;
            
        }*/
    }

    public void StartPressed()
    {
        SceneManager.LoadScene("main", LoadSceneMode.Single);
    }
    public void InstructionsPressed()
    {
        start.SetActive(false);
        instructions.SetActive(false);
        quit.SetActive(false);
        rulesBox.SetActive(true);
        returnBut.SetActive(true);
    }
    public void QuitPressed()
    {
        Application.Quit();
    }
    public void ReturnPressed()
    {
        start.SetActive(true);
        instructions.SetActive(true);
        quit.SetActive(true);
        rulesBox.SetActive(false);
        returnBut.SetActive(false);
    }
}
