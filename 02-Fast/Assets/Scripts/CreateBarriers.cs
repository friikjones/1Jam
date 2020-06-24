using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBarriers : MonoBehaviour
{
    public GameObject[] barriers;
    public Vector3 initialPosition;
    public int tickCounter;
    public int tickThreshold;

    public float currentTime;

    void Update()
    {
        tickCounter++;
        currentTime += Time.deltaTime;

        if(tickCounter > tickThreshold){


            if(currentTime > 15)
                tickThreshold = 110;
            if(currentTime > 45)
                tickThreshold = 90;
            if(currentTime > 75)
                tickThreshold = Random.Range(70,100);

            tickCounter = 0;
            Debug.Log("Spawn here");
            int number = Random.Range(0,barriers.Length);
            GameObject temp = Instantiate(barriers[number],Vector3.zero,Quaternion.identity);
            switch(number){
                case 0: temp.transform.position = new Vector3(14f, -1.00f,0); break; //Aerosol
                case 1: temp.transform.position = new Vector3(14f, -1.24f,0); break; //Can
                case 2: temp.transform.position = new Vector3(14f, -1.86f,0); break; //Controller
                case 3: temp.transform.position = new Vector3(14f, -1.77f,0); break; //Mouse
                case 4: temp.transform.position = new Vector3(14f, -1.75f,0); break; //Mouse
                default: break;
            }
        }
        
    }


    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log(other.name);
        Destroy(other.gameObject);
    }
}
