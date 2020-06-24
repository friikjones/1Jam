using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Rigidbody2D rb;
    public float speed;
    public GameManagerScript gmScript;
    public Vector3 initialPos;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        gmScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
        initialPos = this.transform.position;
    }

    void Update() {
        if (gmScript.gameState == GameState.Running) {
            rb.velocity = CheckForInputs() * speed;
        }
    }

    public void ResetPos() {
        this.transform.position = initialPos;
    }

    Vector2 CheckForInputs() {
        Vector2 output = Vector2.zero;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            output += Vector2.left;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            output += Vector2.right;
        }

        return output;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        // if (other.transform.tag == "Ball") {
        //     other.gameObject.GetComponent<Rigidbody2D>().velocity += rb.velocity / 2;
        // }
    }
}
