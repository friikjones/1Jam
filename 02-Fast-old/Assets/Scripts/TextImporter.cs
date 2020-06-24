using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TextImporter : MonoBehaviour
{
    public string fileToLoad;
    string outputText;
    Text textLabel;
    int counter;
    // Start is called before the first frame update
    void Start()
    {
        outputText = ReadString(fileToLoad);
        textLabel = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        textLabel.text += outputText[counter];
        counter++;
    }

    string ReadString(string fileName)
    {
        string path = $"Assets/Fake Code/{fileName}.txt";
        string output = "";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path); 
        output = reader.ReadToEnd();
        reader.Close();
        return output;
    }
}
