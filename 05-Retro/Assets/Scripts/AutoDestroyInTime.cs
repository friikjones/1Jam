using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyInTime : MonoBehaviour {
    private int tick;
    public int seconds;

    void FixedUpdate() {
        tick++;
        if ((tick / 50) > seconds) {
            Destroy(this.gameObject);
        }
    }
}
