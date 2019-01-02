using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayers : MonoBehaviour {

    Player player;
    bool pressed;
    public int playerNum;
    public float speed;
    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("player" + playerNum).GetComponent<Player>();
    }

    // Update is called once per frame
    void Update () {
		if (pressed)
        {
            player.Move(speed);
        }
	}

    private void OnMouseDown()
    {
        pressed = true;
    }

    private void OnMouseExit()
    {
        pressed = false;
    }
    private void OnMouseUp()
    {
        pressed = false;
    }
}
