using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOBScript : MonoBehaviour
{

    private void Start() {
        
    }

    void OnTriggerExit2D(Collider2D other) {
        Debug.Log("OOB exit, "+other.transform.name);
        if(other.transform.tag == "Puck"){
            other.transform.position = Vector2.zero;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
