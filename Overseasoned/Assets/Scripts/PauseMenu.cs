using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    public static bool gameIsPaused = false;

    [SerializeField]
    public GameObject pauseUI;

    // Update is called once per frame
    void Update()
    {
        if ( Input.GetKeyDown(KeyCode.Escape) )
        {
            if ( gameIsPaused )
            {
                resume();
            }
            else
            {
                pause();
            }
        }
    }

    public void resume()
    {
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }

    void pause()
    {
        pauseUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void restartGame()
    {
        //Restarts the game by reloading the scene
        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

        GameObject LevelManager = GameObject.Find("LevelManager");

        Destroy(LevelManager);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        


    }

    public void quitGame()
    {
        //Goes back to main menu

        pauseUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;

        GameObject LevelManager = GameObject.Find("LevelManager");

        Destroy(LevelManager);

        SceneManager.LoadScene("Main Menu");

        

    }
}
