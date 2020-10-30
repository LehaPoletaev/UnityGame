using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    private HealthManager healthManager;
    public Slider healthBar;
    public Text texthp;

    public static bool gameIsPaused = false;
    public GameObject pauseMEnuUI;

    // Start is called before the first frame update
    void Start()
    {
        healthManager = FindObjectOfType<HealthManager>();    
    }

    // Update is called once per frame
    void Update()
    {
        healthBar.maxValue = healthManager.maxHealth;
        healthBar.value = healthManager.currentHealth;
        texthp.text = "Health: " + healthManager.currentHealth + "/" + healthManager.maxHealth;
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
}
