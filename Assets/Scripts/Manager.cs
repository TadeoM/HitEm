using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public enum GameState {Paused, Unpaused, GameOver }
public class Manager : MonoBehaviour {
    public GameState gameState;
    public BrickGenerator brickGenerator;
    public BallGenerator ballGenerator;
    public GameObject player1;
    public GameObject player2;
    public Canvas canvas;
    public float gameTimer;
    public int playerOneScore;
    public int playerTwoScore;

    private string timerText;
    private Player player1Script;
    private string playerOneText;
    private Player player2Script;
    private string playerTwoText;

    // Use this for initialization
    void Awake()
    {
        playerOneScore = 0;
        playerTwoScore = 0;
        gameTimer = 60;
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
    void Update ()
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
                if (Input.GetKeyDown(KeyCode.M))
                {
                    SceneManager.LoadScene(0);
                }
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
        canvas.transform.GetChild(1).GetComponent<TMP_Text>().text = playerOneText;
        canvas.transform.GetChild(2).GetComponent<TMP_Text>().text = playerTwoText;
        canvas.transform.GetChild(3).GetComponent<TMP_Text>().text = timerText;
    }

    void PauseScene()
    {
        switch (gameState)
        {
            case GameState.Paused:
                canvas.transform.GetChild(3).GetComponent<TMP_Text>().text = "";
                gameState = GameState.Unpaused;
                break;
            case GameState.Unpaused:
                timerText = "Game Paused";
                canvas.transform.GetChild(3).GetComponent<TMP_Text>().text = "Press P to Play";
                canvas.transform.GetChild(2).GetComponent<TMP_Text>().text = timerText;
                gameState = GameState.Paused;
                break;
            default:
                break;
        }
    }
    void EndGame()
    {
        if(playerOneScore > playerTwoScore)
            canvas.transform.GetChild(3).GetComponent<TMP_Text>().text = "PLAYER 1 WINS\nPress M to go to menu!";
        else if(playerTwoScore > playerOneScore)
            canvas.transform.GetChild(3).GetComponent<TMP_Text>().text = "PLAYER 2 WINS\nPress M to go to menu!";
        else
            canvas.transform.GetChild(3).GetComponent<TMP_Text>().text = "DRAW\nPress M to go to menu!";
        gameState = GameState.GameOver;
    }
}

