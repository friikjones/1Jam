using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuScript : MonoBehaviour {

    public int tick;
    public Text menuLabel;
    public Text highscoreLabel;

    void Start() {
        menuLabel = GameObject.Find("GameCanvas/UI/MenuLabel").GetComponent<Text>();
        highscoreLabel = GameObject.Find("GameCanvas/UI/HighscoreLabel").GetComponent<Text>();
        highscoreLabel.text = PlayerPrefs.GetInt("highscore").ToString();
    }

    void FixedUpdate() {
        tick++;
        if (tick % 100 < 70) {
            menuLabel.enabled = true;
        } else {
            menuLabel.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            SceneManager.LoadScene("FirstLevel", LoadSceneMode.Single);
        }
    }
}
