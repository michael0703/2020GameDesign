using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    // Health system of player
    public int startHealth = 100;
    private int currentHealth;

    public void  GetHurt(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0)
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
