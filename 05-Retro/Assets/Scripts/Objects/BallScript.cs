using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour {
    private GameManagerScript gmScript;
    private Rigidbody2D rb;
    public Vector2 storedVelocity;

    public AudioClip[] audioClips;
    public AudioSource audioSource;

    private GameState lastState;

    void Start() {
        gmScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate() {
        if (lastState == GameState.Running && gmScript.gameState != GameState.Running) {
            storedVelocity = rb.velocity;
            rb.velocity = Vector2.zero;
            rb.gravityScale = 0;
        }
        if (gmScript.gameState == GameState.Running && lastState != GameState.Running) {
            rb.velocity = storedVelocity;
            rb.gravityScale = 0.01f;
        }
        lastState = gmScript.gameState;
    }

    void OnCollisionEnter2D(Collision2D other) {
        //Audio
        if (other.transform.tag == "Player") {
            audioSource.clip = audioClips[1];
            audioSource.Play();
        }
        if (other.transform.tag == "Wall") {
            audioSource.clip = audioClips[0];
            audioSource.Play();
        }

        //Movement
        if (Mathf.Abs(rb.velocity.x) < 0.1f) {
            rb.velocity += new Vector2(Random.Range(-.5f, .5f), 0);
        }
        if (Mathf.Abs(rb.velocity.y) < 0.5f && other.transform.tag == "Player") {
            rb.velocity += new Vector2(0, 0.5f);
        }
        rb.velocity = rb.velocity.normalized * gmScript.ballSpeed;
    }
}
