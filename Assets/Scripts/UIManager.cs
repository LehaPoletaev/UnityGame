﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    private HealthManager healthManager;
    public Slider healthBar;
    public Text texthp;
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
    }
}
