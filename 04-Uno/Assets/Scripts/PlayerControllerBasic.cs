using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBasic : MonoBehaviour
{
    private Rigidbody rb;
    public float movementSpeed;
    public GameObject bullet;
    public bool shotFired;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = Movement();

        //Shooting
        if(Input.GetKeyDown(KeyCode.Space) && !shotFired){
            Vector3 position = this.transform.position + new Vector3(0,1,1);
            GameObject tb = Instantiate(bullet,position,Quaternion.AngleAxis(90,Vector3.right));
            shotFired = true;
        }
    }

    Vector3 Movement(){
        Vector3 velocityResult = Vector3.zero;

        if(Input.GetKey(KeyCode.W)){
            velocityResult += Vector3.forward;
        }
        if(Input.GetKey(KeyCode.S)){
            velocityResult += Vector3.back;
        }
        if(Input.GetKey(KeyCode.A)){
            velocityResult += Vector3.left;
        }
        if(Input.GetKey(KeyCode.D)){
            velocityResult += Vector3.right;
        }
        velocityResult *= movementSpeed;

        return velocityResult;
    }
}
