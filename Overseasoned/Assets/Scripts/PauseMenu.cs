using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;

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

    void resume()
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
}
