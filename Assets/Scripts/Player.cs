using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    Manager scene;
    // attributes
    public int player;
    public float speed;
    public int ballTimer;
    public Vector3 currentPos;
    public bool acceptInput;
	// Use this for initialization
	void Awake() {
        scene = FindObjectOfType<Manager>();
        acceptInput = true;
        speed = 0.2f;
        ballTimer = 30;
        currentPos = transform.position;
        currentPos.y = 7.8f;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (scene.gameState == GameState.Unpaused)
        {
            InputCheck();
            CheckBounds();

            ballTimer--;
            if (ballTimer <= 0)
            {
                //ballTimer = 0;
            }
            gameObject.transform.position = currentPos;
        }
    }

    /// <summary>
    /// check key inputs and perform corresponding commands
    /// </summary>
    void InputCheck()
    {
        // USE THIS TO MAKE A POWERUP WHERE THE ENEMY PLAYER CAN'T MOVE
        if (acceptInput)
        {
            // check if player 1 or 2
            switch (player)
            {
                // if player 1, check for W & S keys
                case 1:
                    if (Input.GetKey(KeyCode.W))
                    {
                        Debug.Log("Moving");
                        Move(speed);
                    }
                    if (Input.GetKey(KeyCode.S))
                    {
                        Move(-speed);
                    }
                    break;
                // if player 2, check for Up & Down Arrow keys
                case 2:
                    if (Input.GetKey(KeyCode.UpArrow))
                    {
                        Move(speed);
                    }
                    if (Input.GetKey(KeyCode.DownArrow))
                    {
                        Move(-speed);
                    }
                    break;
                default:
                    break;
            }
        }
    }

    void Move(float y)
    {
        currentPos.y += y;
    }
    
    /// <summary>
    /// check if above or below the playfield
    /// </summary>
    void CheckBounds()
    {
        if(currentPos.y >= 12.9f)
        {
            currentPos.y = 12.9f;
        }
        else if (currentPos.y <= 1f)
        {
            currentPos.y = 1f;
        }
    }
}
