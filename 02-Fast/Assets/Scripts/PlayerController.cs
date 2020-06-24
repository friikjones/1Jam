using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    public float jumpSpeed;
    public bool grounded;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    public bool effort;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grounded)
        {
            if (Input.touchCount > 0)
            {
                rb.velocity = Vector2.up * jumpSpeed;
                grounded = false;
            }
        }
        else
        {
            if(Input.touchCount > 0) 
                effort = true;

            if (rb.velocity.y < 0) 
                rb.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            
            else if (rb.velocity.y > 0 && Input.touchCount == 0)
                rb.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            
            if(Mathf.Abs(rb.velocity.y) < 0.01){
                grounded = true;
                effort = false;
            }
        }
    }

    void OnDestroy(){
        GameObject.Find("GameManager").GetComponent<GameManager>().gameLost = true;
    }
}
