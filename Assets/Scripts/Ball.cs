using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    Manager scene;
    public int ballOwner;
    public GameObject[] playersObj;
    public bool isPaused;
    public Vector3 velocity;
    private int timer = 0;
    public AudioClip[] sounds; // 0 = brickHit1, 1 = brickHit2, 2 = brickBreak1, 3 = brickBreak2, 4 = score1, 5 = score2
    public AudioSource source;
    public GameObject sourceObject;

	// Use this for initialization
	void Awake () {
        playersObj = new GameObject[2];
        playersObj[0] = GameObject.FindWithTag("player1");
        playersObj[1] = GameObject.FindWithTag("player2");
        sourceObject = GameObject.FindGameObjectWithTag("controller");
        source = sourceObject.GetComponent<AudioSource>();
        scene = FindObjectOfType<Manager>();
        isPaused = false;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (scene.gameState == GameState.Unpaused)
        {
            gameObject.transform.position += velocity;
            Debug.DrawLine(transform.position, transform.position + Vector3.up);
            RemoveOnceOutOfBounds();
            CheckBounds();
            if (timer != 0)
            {
                timer--;
            }
        }
	}

    public void CheckBounds()
    {
        if((transform.position.y > 13.4) || (transform.position.y < 0.4))
        {
            velocity.y = -velocity.y;
        }
    }

    public void InitializeSpeed(float xSpeed)
    {
        velocity = new Vector3(xSpeed, Random.Range(-0.005f, 0.005f), 0);
        if(xSpeed > 0)
        {
            ballOwner = 1;
        }
        else
        {
            ballOwner = 2;
        }
    }

    /// <summary>
    /// checks collision with other objects
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Transform collisionTransform = collision.gameObject.GetComponent<Transform>();
        float ySpeed = velocity.y;
        if (timer == 0)
        {
            if (collision.gameObject.tag == "player1" || collision.gameObject.tag == "player2")
            {
                // audioPlayer.
                ySpeed = Vector3.Dot(collision.gameObject.transform.position - transform.position, Vector3.up);
                float aboveOrBelow = Vector3.Dot(collision.gameObject.transform.position - transform.position, Vector3.right);
                ySpeed = -ySpeed;
                velocity.y = ySpeed / 5;
                switch (collision.gameObject.tag)
                {
                    case "player1":
                        ballOwner = 1;
                        break;
                    case "player2":
                        ballOwner = 2;
                        break;
                    default:
                        break;
                }
                velocity.x = -velocity.x;
                timer = 2;

            }
            else if (collision.gameObject.tag == "brick" )
            {
                Manager manager = FindObjectOfType<Manager>();
                switch (ballOwner)
                {
                    case 1:
                        if (collision.gameObject.GetComponent<Brick>().lifePoints <= 0)
                        {
                            source.clip = sounds[3];
                        }
                        else
                        {
                            source.clip = sounds[1];
                        }
                        source.Play();
                        manager.playerOneScore++;
                        break;
                    case 2:
                        if (collision.gameObject.GetComponent<Brick>().lifePoints <= 0)
                        {
                            source.clip = sounds[4];
                        }
                        else
                        {
                            source.clip = sounds[2];
                        }
                        source.Play();
                        manager.playerTwoScore++;
                        break;
                    default:
                        break;
                }

                // dot product to check how far above or below the brick the ball is, if it both the right and up dot products are greater than 
                //(insert value here) value, then the ball is above the brick and you need to change the Y direction
                /// NOT DONE
                if (Vector3.Dot(transform.position - collision.transform.position, transform.up) >= 1.22
                    || Vector3.Dot(transform.position - collision.transform.position, transform.up) <= -1.22)
                {
                    velocity.y = -velocity.y;
                    if (velocity.y > 0.02 || velocity.y < -0.02)
                    {
                        velocity.x = -velocity.x;
                    }

                }
                velocity.x = -velocity.x;
                timer = 2;
            }
            else if (collision.gameObject.tag == "powerup")
            {
                Manager manager = FindObjectOfType<Manager>();
                PowerUp powerupScript = collision.gameObject.GetComponent<PowerUp>();
                source.clip = sounds[ballOwner + 2];
                source.Play();
                powerupScript.DeleteThis(playersObj[ballOwner - 1]);
                timer = 2;
            }
        }
    }

    void RemoveOnceOutOfBounds()
    {
        if (transform.position.x > 27f)
        {
            source.clip = sounds[4];
            source.Play();
            Manager managerScript = GameObject.FindGameObjectWithTag("controller").GetComponent<Manager>();
            managerScript.playerOneScore += 5;
            Destroy(gameObject);
        }
        if(transform.position.x < -5.5f)
        {
            source.clip = sounds[5];
            source.Play();
            Manager managerScript = GameObject.FindGameObjectWithTag("controller").GetComponent<Manager>();
            managerScript.playerTwoScore += 5;
            Destroy(gameObject);
        }
        
    }
}
