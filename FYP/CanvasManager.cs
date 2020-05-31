using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour {

    public GameObject pausePanel;
    public Text levelText;
    public GameObject savePanel;

    private void Update() {
        int temp = PlayerPrefs.GetInt("Level") + 1;
        levelText.text = "Level: " + temp;
    }

    public void LevelEndButton() {
        SceneManager.LoadScene(1);
    }

    public void PauseGame() {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void BackToMenu() {
        SceneManager.LoadScene(0);
    }

    public void SaveGameYes() {
        PlayerPrefs.SetInt("Save", 1);
        savePanel.SetActive(false);
        Time.timeScale = 1;
    }

    public void SaveGameNo() {
        savePanel.SetActive(false);
        Time.timeScale = 1;
    }
}