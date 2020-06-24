using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickVelocityCalc : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 lastPos;
    public float scale;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        scale = GameObject.Find("GameArea").GetComponent<GameManagerScript>().velScale;
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = (this.transform.position - lastPos)*Time.deltaTime*scale;
    }

    void LateUpdate(){
        lastPos = this.transform.position;
    }
}
