using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    private Rigidbody rb;
    public float speed;
    public int destroyRange;

    private GameManagerScript gameManagerScript;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = new Vector3(0,0,speed);
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManagerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.magnitude > destroyRange){
            gameManagerScript.shotMissed = true;
            Destroy(this.gameObject);
        }
    }
}
