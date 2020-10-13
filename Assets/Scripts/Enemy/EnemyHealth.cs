using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //This class describe the health system of monsters.
    public int health = 100;
    private int currentHealth;

    public void  GetHurt(int damage){
        currentHealth -= damage;
        if(currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        currentHealth = health;
    }


}
