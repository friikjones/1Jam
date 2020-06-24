using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour {

    //Object references
    private Text scoreLabel;
    private GameObject livesImg;
    private WaveManagerScript waveManager;
    public GameObject ballPrefab;
    private GameObject gameCanvas;
    private PlayerController playerController;

    //Global variables
    public bool pauseFlag;
    public int lives;
    public int score;
    private AudioSource audioSource;

    //Running State
    public float ballSpeed;
    public int enemyValue;
    public Vector2 ballStartPosition;

    //State Control
    public GameState gameState = GameState.Waiting;

    //Wait State
    public int tick;
    private Text waitLabel;

    //Paused State
    private Text pauseLabel;
    private int pauseTick;

    void Start() {
        lives = 3;
        gameCanvas = GameObject.Find("GameCanvas");
        waveManager = GameObject.Find("GameCanvas/WaveManager").GetComponent<WaveManagerScript>();
        scoreLabel = GameObject.Find("GameCanvas/UI/ScoreLabel").GetComponent<Text>();
        livesImg = GameObject.Find("GameCanvas/UI/LivesImg");
        waitLabel = GameObject.Find("GameCanvas/UI/WaitLabel").GetComponent<Text>();
        pauseLabel = GameObject.Find("GameCanvas/UI/PauseLabel").GetComponent<Text>();
        audioSource = GetComponent<AudioSource>();
        playerController = GameObject.Find("GameCanvas/Paddle").GetComponent<PlayerController>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (gameState == GameState.Running || gameState == GameState.Paused) {
                pauseFlag = !pauseFlag;
                gameCanvas.GetComponent<AudioSource>().Play();
            }
        }
    }

    void FixedUpdate() {
        gameState = CheckGameState();
    }

    public void SpawnBall() {
        SpawnBall(ballStartPosition);
    }

    public void ResetPlayerPos() {
        playerController.ResetPos();
    }

    public void SpawnBall(Vector2 ballPosition) {
        GameObject tmp_ball = Instantiate(ballPrefab, ballPosition, Quaternion.identity);
        tmp_ball.transform.parent = gameCanvas.transform;
        tmp_ball.transform.localPosition = new Vector3(tmp_ball.transform.localPosition.x, tmp_ball.transform.localPosition.y, 0);
        tmp_ball.GetComponent<BallScript>().storedVelocity = new Vector2(0, -2);

    }
    private void UpdateLivesLabel() {
        // livesLabel.text = lives.ToString();
        foreach (Transform child in livesImg.transform) {
            if (child.GetSiblingIndex() > lives - 1) {
                child.GetComponent<SpriteRenderer>().enabled = false;
            } else {
                child.GetComponent<SpriteRenderer>().enabled = true;
            }
        }
    }

    void UpdateHighscore(int input) {
        int highScore = PlayerPrefs.GetInt("highscore", 0);
        if (highScore < input) {
            PlayerPrefs.SetInt("highscore", input);
        }
    }

    GameState CheckGameState() {
        GameState output = gameState;

        switch (output) {
            case GameState.Waiting:
                tick++;
                if (tick > 100) {
                    waitLabel.text = "Go!";
                }
                if (tick > 150) {
                    waitLabel.enabled = false;
                    output = GameState.Running;
                    waveManager.enabled = true;
                    SpawnBall();
                }
                break;
            //Running state
            case GameState.Running:
                scoreLabel.text = score.ToString();
                UpdateLivesLabel();
                //Transitions
                if (pauseFlag) {
                    output = GameState.Paused;
                    audioSource.volume = .25f;
                    audioSource.pitch = .6f;
                }
                if (lives < 1) {
                    output = GameState.Ended;
                }
                break;
            case GameState.Paused:
                pauseTick++;
                if (pauseTick % 50 < 35) {
                    pauseLabel.text = "Paused";
                } else {
                    pauseLabel.text = " ";
                }
                if (!pauseFlag) {
                    pauseLabel.text = " ";
                    output = GameState.Running;
                    pauseTick = 0;
                    audioSource.volume = 1;
                    audioSource.pitch = 1;
                }
                if (lives < 1) {
                    output = GameState.Ended;
                }
                break;
            case GameState.Ended:
                UpdateHighscore(score);
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
                break;
        }
        return output;
    }
}
