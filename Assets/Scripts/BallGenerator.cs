using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour {
    Manager scene;
    public GameObject player1;
    public GameObject player2;
    public GameObject ball;
    public List<GameObject> player1BallList;
    public List<GameObject> player2BallList;
    private void Start()
    {
        scene = FindObjectOfType<Manager>();
    }
    // Use this for initialization
    public void Startup() {
        player1BallList = new List<GameObject>();
        player2BallList = new List<GameObject>();
        player1 = GameObject.FindWithTag("player1");
        player2 = GameObject.FindWithTag("player2");
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        //Debug.Log(scene);   
        if(scene.gameState == GameState.Unpaused)
        {
            CheckForEmpty();
        }
    }

    public void SpawnBall(int player)
    {
        GameObject newBall;
        Vector3 newBallPos;
        switch (player)
        {
            case 1:
                newBallPos = new Vector3(player1.transform.position.x+0.7f, player1.transform.position.y);
                newBall = Instantiate(ball, newBallPos, Quaternion.identity);
                newBall.GetComponent<Ball>().InitializeSpeed(0.25f);
                player1BallList.Add(newBall);
                break;
            case 2:
                newBallPos = new Vector3(player2.transform.position.x-0.7f, player2.transform.position.y);
                newBall = Instantiate(ball, newBallPos, Quaternion.identity);
                newBall.GetComponent<Ball>().InitializeSpeed(-0.25f);
                player2BallList.Add(newBall);
                break;
                
            default:
                break;
        }
    }

    public void ChangeOwner(GameObject swappingBall)
    {
        if (player1BallList.Contains(swappingBall))
        {
            player2BallList.Add(swappingBall);
            player1BallList.Remove(swappingBall);
            //Debug.Log("Swapped player 2 ball to player 1 list");
        }
        else
        {
            player1BallList.Add(swappingBall);
            player2BallList.Remove(swappingBall);
            //Debug.Log("Swapped player 2 ball to player 1 list");
        }
    }

    public void CheckForEmpty()
    {
        if (player1BallList.Count != 0)
        {
            for (int i = 0; i < player1BallList.Count; i++)
            {
                if (player1BallList[i] == null)
                {
                    player1BallList.Remove(player1BallList[i]);
                }
            }
        }
        if(player2BallList.Count != 0)
        {
            for (int i = 0; i < player2BallList.Count; i++)
            {
                if (player2BallList[i] == null)
                {
                    player2BallList.Remove(player2BallList[i]);
                }
            }
        }
    }
}
