using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int currentHealth;

    public void  GetHurt(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Debug.Log("health 0, lose!");
        }
    }
    void Start()
    {
        currentHealth = health;
    }
    void Update()
    {
        
    }
}
