using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    // Health system of monster
    public int startHealth = 100;
    public int currentHealth;
    public AnimationClip deadAnim;

    private GameObject player;
    private Rigidbody rb;
    private bool isMovable;
    private Animator anim;

    public void  GetHurt(int damage){

        if(!gameObject.GetComponent<EnemyMovement>().detectPlayer)
        {
            gameObject.GetComponent<EnemyMovement>().detectPlayer = true;
            gameObject.GetComponent<EnemySpecialMovementBase>().detectPlayer = true;
            gameObject.GetComponent<EnemySpecialMovementBase>().player = player;
            anim.SetBool("isDetect", true);
        }
        // if (isMovable){
        //     rb.AddForce(-1f * transform.forward * 100f);
        // }
        
        currentHealth -= damage;
        Debug.Log("Enemy health: " + currentHealth);
        if(currentHealth <= 0)
        {   
            gameObject.GetComponent<EnemyMovement>().isDead = true;
            gameObject.GetComponent<EnemySpecialMovementBase>().isDead = true;
            gameObject.tag = "Untagged";
            anim.Play("dead");
            Destroy(gameObject, deadAnim.length);
        }
        else
        {
            anim.Play("hurt");
        }
    }
    void Start()
    {   
        isMovable = gameObject.GetComponent<EnemyState>().isMovable;
        rb = gameObject.GetComponent<Rigidbody>();
        currentHealth = startHealth;
        player = GameObject.Find("Player");
        anim = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }


}
