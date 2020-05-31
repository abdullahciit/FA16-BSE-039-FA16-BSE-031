using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LevelComplete : MonoBehaviour
{
    public GameObject map;
    public GameObject cave;
    public GameObject levelEndPanel;
    public Text levelNumberComplete;
    public Text nextLevelTask;
    public static bool gameEnd;

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.tag == "Player") {

            levelEndPanel.SetActive(true);

            switch (PlayerPrefs.GetInt("Level")) {
                case 0:
                    map.SetActive(true);
                    cave.SetActive(false);
                    nextLevelTask.text = "Next Target: Find the treasure which is guarded by the monster!";
                    break;

                case 1:
                    nextLevelTask.text = "Next Target: Find the key which is hidden in thickest part of the forest!";
                    break;

                case 2:
                    nextLevelTask.text = "Next Target: Go back and now unlock the treasure box!";
                    break;

                case 3:
                    gameObject.GetComponent<Animator>().SetTrigger("OpenBox");
                    nextLevelTask.text = "Next Target: Kill the final boss who owns this treasure!";
                    break;
            }

            PlayerPrefs.SetInt("Save", 0);

            int tempText = PlayerPrefs.GetInt("Level") + 1;
            levelNumberComplete.text = "Level " + tempText + " Complete!";

            int temp = PlayerPrefs.GetInt("Level");
            PlayerPrefs.SetInt("Level", temp + 1);

            if (PlayerPrefs.GetInt("Level") > PlayerPrefs.GetInt("LevelUnlocked")) {
                PlayerPrefs.SetInt("LevelUnlocked", PlayerPrefs.GetInt("Level"));
            }


            StartCoroutine("StopGame");
        }
    }

    IEnumerator StopGame() {
        yield return new WaitForSeconds(2);

        if (PlayerPrefs.GetInt("Level") == 0 || PlayerPrefs.GetInt("Level") == 2) {
            Time.timeScale = 0;
            gameObject.SetActive(false);
        } else
            Time.timeScale = 0;
    }
}