using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Health system of player
    public int startHealth = 100;
    public int currentHealth;

    private GameObject levelManager;

    public void GetHurt(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            levelManager.GetComponent<LevelManager>().Die();
        }
    }
    void Start()
    {
        currentHealth = startHealth;
        levelManager = GameObject.Find("LevelManager");
    }
 
}
