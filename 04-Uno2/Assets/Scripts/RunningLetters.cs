using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using System.IO;
using System;

public class RunningLetters : MonoBehaviour
{
    private static List<string> wordList = new List<string>();
    private static List<int> wordTargets = new List<int>();
    private static int listSizeIntern;
    private int tick = 0;
    private int counter = 0;
    private int timer = 0;
    private Text letterLabel;
    private Text inputText;
    private Text winLabel;
    private Text timeLabel;

    public AudioSource winChime;

    public int wins;
    public int thresh;
    public int listSize;
    public bool endGame;
    
    // Start is called before the first frame update
    void Start()
    {
        listSizeIntern = listSize;
        letterLabel = transform.GetChild(0).GetComponent<Text>();
        inputText = GameObject.Find("Input/Text").GetComponent<Text>();
        winLabel = GameObject.Find("WinLabel").GetComponent<Text>();
        timeLabel = GameObject.Find("TimeLabel").GetComponent<Text>();
        ProcessString();
    }

    // Update is called once per frame
    void Update()
    {
        RollLetters(wordList[wins]);

        if(inputText.text == wordList[wins]){
            wins++;
            winChime.Play();
            inputText.GetComponentInParent<InputField>().text = "";
        }

        if(Input.GetKey(KeyCode.Escape)){
            timer = 180*60;
        }
    }

    void FixedUpdate() {
        timer++;
        int auxTimer = 179 - timer/60;
        winLabel.text = "Acertos: " + wins.ToString();
        timeLabel.text = (auxTimer/60) + "m" + ((auxTimer%60 >9)? "":"0") + (auxTimer%60) + "s";
        if(auxTimer < 60){
            timeLabel.color = Color.red; 
        }
        //Endgame
        if(auxTimer < 1){
            endGame = true;
            int highScore = PlayerPrefs.GetInt("highscore", 0);
            if (highScore < wins){
                PlayerPrefs.SetInt("highscore", wins);
            }
            SceneManager.LoadScene("StartScene",LoadSceneMode.Single);
        }
    }

    void RollLetters(string input){
        if(tick > thresh){
            counter++;
            tick=0;
            letterLabel.text = " ";
        }else{
            int aux = counter % input.Length;
            letterLabel.text = input[aux].ToString();
        }
        tick++;
    }

    // [MenuItem("Tools/Read Lists")]
    static void ReadLists(){
        Debug.Log("Numbers: "+wordTargets.Count);
        foreach(int i in wordTargets){
            Debug.Log(i);
        }
        Debug.Log("Words: "+wordList.Count);
        foreach(string s in wordList){
            Debug.Log(s);
        }
    }

    static void ProcessString()
    {
        string path = "Assets/Resources/words.txt";
        StreamReader reader = new StreamReader(path); 
        
        UnityEngine.Random.InitState(System.DateTime.Now.Second);

        for(int j=0;j<listSizeIntern;j++){
            wordTargets.Add(UnityEngine.Random.Range(0,134512));
        }
        wordTargets.Sort();

        int i=0;
        int counter=0;
        
        while(!reader.EndOfStream){
            if(i==listSizeIntern){
                break;
            }
            if(counter==wordTargets[i]){
                wordList.Add(reader.ReadLine());
                i++;
            }else{
                reader.ReadLine();
            }
            counter++;
        }
        reader.Close();

        RandomizeList();
    }

    static void RandomizeList(){        
         for (int i = 0; i < wordList.Count; i++) {
             string temp = wordList[i];
             int randomIndex = UnityEngine.Random.Range(i, wordList.Count);
             wordList[i] = wordList[randomIndex];
             wordList[randomIndex] = temp;
         }
    }
}
