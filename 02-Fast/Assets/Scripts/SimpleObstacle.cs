using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleObstacle : MonoBehaviour
{
    public float speed;

    void Update()
    {
        transform.position = transform.position - new Vector3(speed * Time.deltaTime,0,0);
    }

    
}
