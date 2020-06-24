using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalScript : MonoBehaviour
{

    public GameManagerScript managerScript;

    private void Start() {
        managerScript = transform.parent.GetComponent<GameManagerScript>();
    }

    void OnTriggerEnter2D(Collider2D other) {
        Debug.Log("Goal enter, "+other.transform.name);
        if(other.transform.tag == "Puck"){
            if (other.transform.localPosition.y > 0){
                managerScript.scoreRed++;
            }else{
                managerScript.scoreBlue++;
            }
            other.transform.position = Vector2.zero;
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            
        }
    }
}
