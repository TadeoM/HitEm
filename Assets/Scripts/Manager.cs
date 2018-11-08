﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public enum GameState {Paused, Unpaused, GameOver }
public class Manager : MonoBehaviour {
    public GameState gameState;
    public BrickGenerator brickGenerator;
    public BallGenerator ballGenerator;
    public Canvas canvas;
    public int playerOneScore;
    public int playerTwoScore;
    public float gameTimer;
    private bool gamePaused;
    private string timerText;
    public GameObject player1;
    Player player1Script;
    string playerOneText;
    public GameObject player2;
    Player player2Script;
    string playerTwoText;

    // Use this for initialization
    void Awake()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        gameTimer = 60;
        //Debug.Log("Hello");
        brickGenerator = gameObject.GetComponent<BrickGenerator>();
        ballGenerator = gameObject.GetComponent<BallGenerator>();
        brickGenerator.Generate();

        ballGenerator = gameObject.GetComponent<BallGenerator>();
        player1 = Instantiate(player1, new Vector3(-4.33f, 7.57f), Quaternion.identity);
        player1Script = player1.GetComponent<Player>();
        player2 = Instantiate(player2, new Vector3(25.62f, 7.57f), Quaternion.identity);
        player2Script = player2.GetComponent<Player>();
        ballGenerator.Startup();
        gameState = GameState.Unpaused;        
    }

    // Update is called once per frame
    void FixedUpdate ()
    {
        switch (gameState)
        {
            case GameState.Paused:
                if (Input.GetKeyDown(KeyCode.P))
                    PauseScene();
                break;
            case GameState.Unpaused:
                CheckTimer();
                UpdateText();
                if (Input.GetKeyDown(KeyCode.P))
                    PauseScene();
                if (gameTimer <= 0)
                {
                    gameState = GameState.GameOver;
                }
                gameTimer -= Time.deltaTime;
                break;
            case GameState.GameOver:
                EndGame();
                PauseScene();
                break;
            default:
                break;
        }
    }

    void CheckTimer()
    {
        if(ballGenerator.player1BallList.Count + ballGenerator.player2BallList.Count <= 14)
        {
            if (player1Script.ballTimer <= 0 && ballGenerator.player1BallList.Count < 8)
            {
                ballGenerator.SpawnBall(1);
                player1Script.ballTimer = 60;
            }
            else if (player2Script.ballTimer <= 0 && ballGenerator.player2BallList.Count < 8)
            {
                player2Script.ballTimer = 60;
                ballGenerator.SpawnBall(2);
            }
        }
        
    }

    /// <summary>
    /// update text to show each player's current score
    /// </summary>
    void UpdateText()
    {
        playerOneText = "Score: " + playerOneScore;
        playerTwoText = "Score: " + playerTwoScore;
        timerText = "Time Left: " + (int)gameTimer;
        canvas.transform.GetChild(0).GetComponent<Text>().text = playerOneText;
        canvas.transform.GetChild(1).GetComponent<Text>().text = playerTwoText;
        canvas.transform.GetChild(2).GetComponent<Text>().text = timerText;
    }

    void PauseScene()
    {
        switch (gameState)
        {
            case GameState.Paused:
                canvas.transform.GetChild(3).GetComponent<Text>().text = "";
                gameState = GameState.Unpaused;
                break;
            case GameState.Unpaused:
                timerText = "Game Paused";
                canvas.transform.GetChild(3).GetComponent<Text>().text = "Press P to Play";
                canvas.transform.GetChild(2).GetComponent<Text>().text = timerText;
                gameState = GameState.Paused;
                break;
            default:
                break;
        }
    }
    void EndGame()
    {
        if(playerOneScore > playerTwoScore)
            canvas.transform.GetChild(3).GetComponent<Text>().text = "PLAYER 1 WINS\nPress M to go to menu!";
        else if(playerTwoScore > playerOneScore)
            canvas.transform.GetChild(3).GetComponent<Text>().text = "PLAYER 2 WINS\nPress M to go to menu!";
        else
            canvas.transform.GetChild(3).GetComponent<Text>().text = "DRAW\nPress M to go to menu!";
        gameState = GameState.GameOver;
    }
}
