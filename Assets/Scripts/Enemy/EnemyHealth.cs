using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Health system of monster
    public int startHealth = 100;
    private int currentHealth;

    public void  GetHurt(int damage){
        currentHealth -= damage;
        Debug.Log("Enemy health: " + currentHealth);
        if(currentHealth <= 0)
        {   
            Destroy(gameObject);
        }
    }
    void Start()
    {
        currentHealth = startHealth;
    }


}
