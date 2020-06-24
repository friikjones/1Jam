using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SweatScript : MonoBehaviour
{
    public PlayerController controlScript;
    public GameObject sweat;

    void Start()
    {
        controlScript = GetComponent<PlayerController>();
        sweat = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(controlScript.effort){
            sweat.SetActive(true);
        }else{
            sweat.SetActive(false);
        }
    }
}
