using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuckMove : MonoBehaviour
{
    public Rigidbody2D rb;
    public int counter;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log(col.transform.tag);
        if(col.transform.tag == "Wall"){
            if(transform.position.y > 600 || transform.position.y < -600){
                rb.velocity = new Vector2(rb.velocity.x,-rb.velocity.y);
            }
            if(transform.position.x > 300 || transform.position.x < -300){
                rb.velocity = new Vector2(-rb.velocity.x,rb.velocity.y);
            }
        }
    }
}
