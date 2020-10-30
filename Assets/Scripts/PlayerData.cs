using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData 
{
    public int maxHealth;
    public int currHelth;
    public float[] position;

    public PlayerData(HealthManager player)
    {
        maxHealth = player.maxHealth;
        currHelth = player.currentHealth;

        position = new float[2];
        position[0]=player.transform.position.x;
        position[1]=player.transform.position.y;
    }
}
