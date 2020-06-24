using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBehaviourScript : MonoBehaviour {

    private int tick;
    private int sideTick;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private GameManagerScript gameManagerScript;

    public GameObject explosionParticles;

    [HideInInspector] public int stepSideCounter;
    [HideInInspector] public int stepDownCounter;
    [HideInInspector] public int stepSideAmount;
    [HideInInspector] public bool stepLeft;
    [HideInInspector] public float moveSpeed;

    void Start() {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Random.ColorHSV(0f, 1f, 1f, 1f, 1f, 1f);
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    void FixedUpdate() {
        if (gameManagerScript.gameState == GameState.Running) {
            tick++;
            if (tick % stepSideCounter == 0) {
                sideTick++;
                if (sideTick % stepSideAmount == 0) {
                    stepLeft = !stepLeft;
                }
                MoveSide(stepLeft);
            }
            if (tick % stepDownCounter == 0) {
                MoveDown();
            }
        }
    }

    void MoveDown() {
        rb.transform.Translate(Vector3.down * moveSpeed);
    }

    void MoveSide(bool left) {
        if (left) {
            rb.transform.Translate(Vector3.left * moveSpeed);
        } else {
            rb.transform.Translate(Vector3.right * moveSpeed);
        }
    }

    private void OnCollisionExit2D(Collision2D other) {
        if (other.transform.tag == "Ball") {
            gameManagerScript.score += gameManagerScript.enemyValue;
            gameManagerScript.enemyValue += 10;
            gameManagerScript.ballSpeed += 0.05f;
            Instantiate(explosionParticles, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }

}
