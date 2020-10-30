using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMEnuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        { 
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
        
    }

    private void Pause()
    {
        pauseMEnuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    private void Resume()
    {
        pauseMEnuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = true;
    }
}
