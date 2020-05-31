using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    public int level;
    public GameObject[] levelPanel;
    public GameObject arrow;
    public GameObject[] arrowTarget;
    public GameObject[] levelObj;
    public GameObject miniMap;
    public GameObject bridgeDoor;
    [SerializeField] List<GameObject> players = new List<GameObject>();
    public Transform spawnPoint;
    public Transform saveSpawnPoint;
    public GameObject enemySpawner;
    public GameObject lobbyCam;
    public GameObject lobbyUI;
    public GameObject inGameUI;
    public Text statusText;
    public bool levelEnd;
    public GameObject cutSceneCamera;
    public GameObject bossCut, bossMain;
    public GameObject cutsceneZombie;
    public GameObject startUp;

    public List<GameObject> Players {
        get {
            return players;
        }
    }

    private void Start() {
        Time.timeScale = 1;
        lobbyCam.SetActive(false);
        lobbyUI.SetActive(false);

        if (PlayerPrefs.GetInt("Save") == 0) {
            GameObject playerObj = Instantiate(player, spawnPoint.position, spawnPoint.rotation);
            enemySpawner.SetActive(true);
            enemySpawner.GetComponent<EnemySpawner>().target = playerObj;
        } else if(PlayerPrefs.GetInt("Save") == 1) {
            GameObject playerObj = Instantiate(player, saveSpawnPoint.position, saveSpawnPoint.rotation);
            enemySpawner.SetActive(true);
            enemySpawner.GetComponent<EnemySpawner>().target = playerObj;
        }

        inGameUI.SetActive(true);
        
        level = PlayerPrefs.GetInt("Level");



        if(level == 0) {
            StartCoroutine("DelaySpawnL1");
        }

        if(level == 4) {
            StartCoroutine("DelaySpawn");
        }

        StartCoroutine("LevelStart");
        arrow = GameObject.FindGameObjectWithTag("Arrow");
        levelObj[level].SetActive(true);

        if(level == 0) {
            miniMap.SetActive(false);
        }

        if(level > 0) {
            miniMap.SetActive(true);
            bridgeDoor.SetActive(false);
            startUp.SetActive(true);
        }

        levelEnd = false;
    }


    IEnumerator LevelStart() {
        if (PlayerPrefs.GetInt("Level") > 0) {
            levelPanel[level].SetActive(true);
            yield return new WaitForSeconds(5);
            levelPanel[level].SetActive(false);
        }
        else if (PlayerPrefs.GetInt("Level") == 0) {
            yield return new WaitForSeconds(10);
            levelPanel[level].SetActive(true);
            yield return new WaitForSeconds(5);
            levelPanel[level].SetActive(false);
        }
    }

    IEnumerator DelaySpawn() {
        bossCut.SetActive(false);
        yield return new WaitForSeconds(5);
        bossCut.SetActive(true);
        bossMain.SetActive(false);
        cutSceneCamera.SetActive(true);
        yield return new WaitForSeconds(5);
        cutSceneCamera.SetActive(false);
        bossCut.SetActive(false);
        bossMain.SetActive(true);
    }

    IEnumerator DelaySpawnL1() {
        yield return new WaitForSeconds(0);
        inGameUI.SetActive(false);
        startUp.SetActive(false);
        cutsceneZombie.SetActive(true);
        yield return new WaitForSeconds(10);
        cutsceneZombie.SetActive(false);
        inGameUI.SetActive(true);
        startUp.SetActive(true);
    }
}
