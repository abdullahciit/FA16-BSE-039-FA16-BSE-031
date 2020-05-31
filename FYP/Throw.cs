using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    Vector3 playerDir;
    public GameObject rockObj;
    float rateTime;
    public Transform muzzle;
    
    private void Start() {
        rateTime = 0f;    
    }

    private void OnTriggerStay(Collider other) {
        if (other.gameObject.tag == "Player") {
            playerDir = other.transform.position - transform.position;

            if (Time.time >= rateTime) {
                rateTime += 4f; 
                Instantiate(rockObj, muzzle.transform.position, transform.rotation);
            }
        }
    }
}
