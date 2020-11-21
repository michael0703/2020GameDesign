using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Health system of player
    public int startHealth = 100;
    public int currentHealth;

    public void GetHurt(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player health: " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("health 0, lose!");
        }
    }
    void Start()
    {
        currentHealth = startHealth;
    }
    void Update()
    {

    }
}
