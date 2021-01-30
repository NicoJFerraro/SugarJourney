using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public GameObject pUI;
    public int RLoad;
    public static bool isPaused;
    public Scene scene;

    // Use this for initialization



    void Start()
    {
        pUI.SetActive(false);
        isPaused = false;
        scene = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update() {
        
        PauseMode();

        if (isPaused == true && Input.GetKeyDown(KeyCode.P))
        {
            isPaused = false;
        }
        else if ( isPaused == false &&Input.GetKeyDown(KeyCode.P))
        {
            isPaused = true;
        }
    }
   
    public void Resume()
    {
        pUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        pUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(scene.name);
    }
    public void MainMenu()
    {
        pUI.SetActive(false);
        isPaused = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void PauseMode()
    {
        if (isPaused)
        {
            pUI.SetActive(true);
            Time.timeScale = 0f;
        }
        else if (isPaused == false)
        {
            pUI.SetActive(false);
            Time.timeScale = 1f;
        }
    }


}
