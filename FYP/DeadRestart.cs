using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeadRestart : MonoBehaviour
{
    private void Start() {
        StartCoroutine("Restart");
    }

    IEnumerator Restart() {
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(1);
    }
}
