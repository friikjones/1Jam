using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShake : MonoBehaviour
{
    public float shakeMagnitude = 0.7f;
    public float dampingSpeed = 1.0f;
    
    void Update()
    {
        transform.localPosition = Vector3.zero + Random.insideUnitSphere * shakeMagnitude;
    }
}
