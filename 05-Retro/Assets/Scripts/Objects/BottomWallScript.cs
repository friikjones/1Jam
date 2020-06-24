using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomWallScript : MonoBehaviour {

    private GameManagerScript gmScript;
    private WaveManagerScript wmScript;

    public AudioClip[] audioClips;
    private AudioSource audioSource;

    private void Start() {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        wmScript = GameObject.Find("GameCanvas/WaveManager").GetComponent<WaveManagerScript>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log(other.transform.tag);
        if (other.transform.tag == "Ball") {
            Destroy(other.gameObject);
            gmScript.lives--;
            wmScript.CleanScreen();
            if (gmScript.lives > 0) {
                if (gmScript.lives > 1) {
                    audioSource.clip = audioClips[0];
                } else {
                    audioSource.clip = audioClips[1];
                }
                gmScript.ResetPlayerPos();
                gmScript.SpawnBall();
            } else {
                audioSource.clip = audioClips[2];
            }
        }
        if (other.transform.tag == "Alien") {
            // Debug.Log("Found alien");
            Destroy(other.gameObject);
            gmScript.lives = 0;
            audioSource.clip = audioClips[2];
        }
        audioSource.Play();
    }
}
