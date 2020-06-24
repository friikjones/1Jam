using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timer;
    public int countdown;
    public int countTextSec;
    public int countTextMin;

    public Text timerText;

    public bool gameWon;
    public bool gameLost;
    public GameObject gameOverOverlay;
    
    void Update()
    {
        if (!gameWon && !gameLost)
        {
            timer += Time.deltaTime;
            countdown = Mathf.RoundToInt(90 - timer);
            countTextMin = Mathf.RoundToInt(countdown/60);
            countTextSec = countdown - countTextMin*60;
            gameOverOverlay.SetActive(false);
        }
        if (countdown == 0 && !gameLost)
        {
            gameWon = true;
            gameOverOverlay.SetActive(true);
            gameOverOverlay.transform.GetChild(0).gameObject.SetActive(false);
            gameOverOverlay.transform.GetChild(1).gameObject.SetActive(true);
        }
        if (gameLost){
            gameOverOverlay.SetActive(true);
            gameOverOverlay.transform.GetChild(0).gameObject.SetActive(true);
            gameOverOverlay.transform.GetChild(1).gameObject.SetActive(false);
        }
        timerText.text = countTextMin.ToString()+"\' "+countTextSec.ToString()+"\"";
    }
}
