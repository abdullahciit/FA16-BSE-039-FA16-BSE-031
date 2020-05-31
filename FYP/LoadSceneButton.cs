using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadSceneButton : MonoBehaviour
{
    public Button[] levelButton;
    public GameObject[] levelLock;

    private void Start() {

        switch (PlayerPrefs.GetInt("LevelUnlocked")) {
            case 0:
                levelButton[0].interactable = true;
                levelButton[1].interactable = false;
                levelButton[2].interactable = false;
                levelButton[3].interactable = false;
                levelButton[4].interactable = false;

                levelLock[0].SetActive(false);
                break;

            case 1:
                levelButton[0].interactable = true;
                levelButton[1].interactable = true;
                levelButton[2].interactable = false;
                levelButton[3].interactable = false;
                levelButton[4].interactable = false;

                levelLock[0].SetActive(false);
                levelLock[1].SetActive(false);

                break;

            case 2:
                levelButton[0].interactable = true;
                levelButton[1].interactable = true;
                levelButton[2].interactable = true;
                levelButton[3].interactable = false;
                levelButton[4].interactable = false;

                levelLock[0].SetActive(false);
                levelLock[1].SetActive(false);
                levelLock[2].SetActive(false);
                break;

            case 3:
                levelButton[0].interactable = true;
                levelButton[1].interactable = true;
                levelButton[2].interactable = true;
                levelButton[3].interactable = true;
                levelButton[4].interactable = false;

                levelLock[0].SetActive(false);
                levelLock[1].SetActive(false);
                levelLock[2].SetActive(false);
                levelLock[3].SetActive(false);
                break;

            case 4:
                levelButton[0].interactable = true;
                levelButton[1].interactable = true;
                levelButton[2].interactable = true;
                levelButton[3].interactable = true;
                levelButton[4].interactable = true;

                levelLock[0].SetActive(false);
                levelLock[1].SetActive(false);
                levelLock[2].SetActive(false);
                levelLock[3].SetActive(false);
                levelLock[4].SetActive(false);
                break;
        }

    }

    public void LoadSceneContinue()
	{
		gameObject.SetActive(false);
		FindObjectOfType<ProgressSceneLoader>().LoadScene("Jungle");
	}
    
	public void LoadSceneNew()
	{
		gameObject.SetActive(false);
        PlayerPrefs.SetInt("Level", 0);
        PlayerPrefs.SetInt("Save", 0);
		FindObjectOfType<ProgressSceneLoader>().LoadScene("Jungle");
	}
    
	public void LoadSceneLoad()
	{
		gameObject.SetActive(false);
		FindObjectOfType<ProgressSceneLoader>().LoadScene("Jungle");
	}

    public void Level1() {
        PlayerPrefs.SetInt("Level", 0);
        SceneManager.LoadScene(1);
    }

    public void Level2() {
        PlayerPrefs.SetInt("Level", 1);
        SceneManager.LoadScene(1);
    }

    public void Level3() {
        PlayerPrefs.SetInt("Level", 2);
        SceneManager.LoadScene(1);
    }

    public void Level4() {
        PlayerPrefs.SetInt("Level", 3);
        SceneManager.LoadScene(1);
    }

    public void Level5() {
        PlayerPrefs.SetInt("Level", 4);
        SceneManager.LoadScene(1);
    }
}