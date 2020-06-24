using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    public bool gameEnded;
    public int velScale;
    public int scoreRed;
    public int scoreBlue;
    private Text winRedLabel;
    private Text winBlueLabel;
    private Text scoreRedLabel;
    private Text scoreBlueLabel;
    
    private int tick;

    void Start()
    {
        scoreRedLabel = GameObject.Find("RedScoreLabel").GetComponent<Text>();
        scoreBlueLabel = GameObject.Find("BlueScoreLabel").GetComponent<Text>();
        winRedLabel = GameObject.Find("RedWinsLabel").GetComponent<Text>();
        winBlueLabel = GameObject.Find("BlueWinsLabel").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(scoreRed > 6){
            gameEnded = true;
            winRedLabel.enabled = true;
            tick++;
        }
        if(scoreBlue > 6){
            gameEnded = true;
            winBlueLabel.enabled = true;
            tick++;
        }

        scoreRedLabel.text = scoreRed.ToString();
        scoreBlueLabel.text = scoreBlue.ToString();

        if(tick > 180){
            SceneManager.LoadScene("LandingScene", LoadSceneMode.Single);
        }
        
    }
}
