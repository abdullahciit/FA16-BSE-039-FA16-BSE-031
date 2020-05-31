using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateArrow : MonoBehaviour
    {
        private void Update() {
            gameObject.transform.Rotate(Vector3.right, 180 * Time.deltaTime);
        }
}
