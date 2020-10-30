using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{

    public int currentHealth;
    public int maxHealth;
    // Start is called before the first frame update
    
    public void SavePlayer()
    {

        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
            PlayerData data = SaveSystem.LoadPlayer();
            currentHealth = data.currHelth;
            maxHealth = data.maxHealth;

            Vector2 position;
            position.x = data.position[0];
            position.y = data.position[1];
            transform.position = position;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void hurtPlayer(int damage_received)
    {
        currentHealth -= damage_received;
    }
}
