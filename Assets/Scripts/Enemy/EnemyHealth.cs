using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Health system of monster
    public int startHealth = 100;
    public int currentHealth;

    private GameObject player;
    private Rigidbody rb;
    bool isMovable;
    public void  GetHurt(int damage){

        if(!gameObject.GetComponent<EnemyMovement>().detectPlayer)
        {
            gameObject.GetComponent<EnemyMovement>().detectPlayer = true;
            gameObject.GetComponent<EnemySpecialMovementBase>().detectPlayer = true;
            gameObject.GetComponent<EnemySpecialMovementBase>().player = player;
            gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("isDetect", true);
        }
        if (isMovable){
            rb.AddForce(-1f * transform.forward * 100f);
        }
        gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().Play("hurt");
        currentHealth -= damage;
        Debug.Log("Enemy health: " + currentHealth);
        if(currentHealth <= 0)
        {   
            Destroy(gameObject);
        }
    }
    void Start()
    {   
        isMovable = gameObject.GetComponent<EnemyState>().isMovable;
        rb = gameObject.GetComponent<Rigidbody>();
        currentHealth = startHealth;
        player = GameObject.Find("Player");
    }


}
