using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallsScript : MonoBehaviour {

    private Collider2D thisCollider;
    private Collider2D paddleCollider;

    private void Start() {
        thisCollider = GetComponent<Collider2D>();
        paddleCollider = GameObject.Find("Paddle").GetComponent<Collider2D>();
        Physics2D.IgnoreCollision(thisCollider, paddleCollider);
    }
}
