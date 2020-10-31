using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseMEnuUI;
    public GameObject gameoverMEnuUI;
    public static bool gameIsOver = false;
    private HealthManager healthManager;
    // Update is called once per frame

    void Awake()
    {
        healthManager = FindObjectOfType<HealthManager>();
    }
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
        if (healthManager.currentHealth <= 0)
        {
            Gameover();
        }

    }

    public void Pause()
    {
        pauseMEnuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIsPaused = true;
    }

    public void Resume()
    {
        pauseMEnuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIsPaused = false;
    }
    public void Gameover()
    {
        gameoverMEnuUI.SetActive(true);
        Time.timeScale = 0f;
    }
    public void Quit()
    {   
        Application.Quit();
    }
    
    public void Menu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
