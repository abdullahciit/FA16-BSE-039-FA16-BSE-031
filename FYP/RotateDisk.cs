using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDisk : MonoBehaviour {

    public int speed;

    private void Update() {
        gameObject.transform.Rotate(Vector3.forward, speed * Time.deltaTime);
    }
}
