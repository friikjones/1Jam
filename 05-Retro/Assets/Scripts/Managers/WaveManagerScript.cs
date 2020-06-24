using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class WaveManagerScript : MonoBehaviour {

    //Instantiate Values
    public GameObject[] aliens;
    private Vector3 defaultDist = Vector3.right * .8f;
    public Vector3 initialDefaultPosition;
    public int tick;

    //Game Manager
    public GameManagerScript gameManagerScript;

    //Alien Values
    public int stepSideCounter;
    public int stepDownCounter;
    public int stepSideAmount;
    public float moveSpeed;
    public float alienQuant = 1;

    void Start() {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        RandomAlienInstance(1, initialDefaultPosition - defaultDist * 2, defaultDist);
    }

    void FixedUpdate() {
        if (gameManagerScript.gameState == GameState.Running) {
            tick++;
            UpdateAllAliens();
        }
        if (tick > (stepDownCounter * 1 / moveSpeed)) {
            tick = 0;
            RandomAlienInstance(Mathf.RoundToInt(alienQuant), initialDefaultPosition - defaultDist * 2, defaultDist);
            moveSpeed += .005f;
            if (alienQuant < 5) {
                alienQuant += .15f;
            }
        }
    }

    GameObject SingleAlienInstance(int alienIndex, Vector3 position) {
        GameObject tmp_alien = Instantiate(aliens[alienIndex], position, Quaternion.identity);
        tmp_alien.transform.parent = this.transform;
        return tmp_alien;
    }

    GameObject[] RandomAlienInstance(int alienNumber, Vector3 initialPosition, Vector3 distBetween) {
        GameObject[] tmp_aliens = new GameObject[5];
        List<bool> positions = new List<bool>();
        for (int i = 0; i < 5; i++) {
            if (i < alienNumber) {
                positions.Add(true);
            } else {
                positions.Add(false);
            }
        }
        positions = Shuffle(positions);
        for (int i = 0; i < 5; i++) {
            if (positions[i]) {
                tmp_aliens[i] = Instantiate(aliens[UnityEngine.Random.Range(0, aliens.Length)], initialPosition + distBetween * i, Quaternion.identity);
                tmp_aliens[i].transform.parent = this.transform;
            }
        }
        return tmp_aliens;
    }

    void UpdateAllAliens() {
        foreach (Transform child in transform) {
            if (child.tag == "Alien") {
                AlienBehaviourScript alienScript = child.GetComponent<AlienBehaviourScript>();
                alienScript.stepSideCounter = stepSideCounter;
                alienScript.stepDownCounter = stepDownCounter;
                alienScript.stepSideAmount = stepSideAmount;
                alienScript.moveSpeed = moveSpeed;
            }
        }
    }

    public static List<bool> Shuffle(List<bool> aList) {
        System.Random _random = new System.Random();
        bool myGO;
        int n = aList.Count;
        for (int i = 0; i < n; i++) {
            int r = i + (int)(_random.NextDouble() * (n - i));
            myGO = aList[r];
            aList[r] = aList[i];
            aList[i] = myGO;
        }
        return aList;
    }

    public void CleanScreen() {
        foreach (Transform child in transform) {
            Destroy(child.gameObject);
        }
    }

}
