using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public GameObject saveMenu;

    private void OnTriggerEnter(Collider other) {
        Time.timeScale = 0;
        saveMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
