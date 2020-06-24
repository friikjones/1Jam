using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class InitialScript : MonoBehaviour
{
    private Text scoreLabel;
    private Text titleLabel;
    public int tick = 0;

    public char[] displayText;
    public string titleText;

    // Start is called before the first frame update
    void Start()
    {
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
        scoreLabel.text = "Melhor pontuação: " + PlayerPrefs.GetInt("highscore",0).ToString();

        titleLabel = GameObject.Find("TitleLabel").GetComponent<Text>();
        displayText = new char[titleText.Length];
    }

    // Update is called once per frame
    void Update()
    {
        for (int i=0;i<titleText.Length;i++){
            if (i == (tick/20)%titleText.Length){
                displayText[i] = titleText[i];
            }else{
                displayText[i] = ' ';
            }
        }
        titleLabel.text = new string(displayText);
    }

    void FixedUpdate() {
        tick++;    
    }

    public void StartGame() {
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
    }

    public void QuitGame() {
        Application.Quit();
    }
}
