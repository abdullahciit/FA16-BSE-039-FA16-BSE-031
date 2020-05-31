using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class resumemenu : MonoBehaviour
{
    public GameObject resmenu;
    public static bool gamepaused = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gamepaused)
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }
    void resume()
    {
        resmenu.SetActive(false);
        Time.timeScale = 1;
        gamepaused = false;
    }

    void pause()
    {
        resmenu.SetActive(true);
        Time.timeScale = 0;
        gamepaused = true;
    }
    public void exit()
    {
        SceneManager.LoadScene("Menu_Scene");
    }
    public void resumebtn()
    {
        resmenu.SetActive(false);
        Time.timeScale = 1;
        gamepaused = false;
    }
}

  