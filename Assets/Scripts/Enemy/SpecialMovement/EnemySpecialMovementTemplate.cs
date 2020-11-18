using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialMovementTemplate : EnemySpecialMovementBase
{   
    float rotateSpeed = 3f;
    float speed = 2f;
    float cooldown_countdown = 0f;
    public float attack_range = 2f;
    Animator animator;
    protected override void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }
    protected override void specialMove(GameObject target)
    {   
        animator.SetBool("detectObject", true);
        lookAtPlayer(target);

        float dist = Vector3.Distance(target.transform.position, transform.position);
        if (dist > attack_range){
            cooldown_countdown = 0f;
            animator.SetBool("object_outofrange", true);
            rb.velocity = transform.forward * speed;
        }
        else{
            animator.SetBool("object_outofrange", false);
            rb.velocity = Vector3.zero;
            attack(target);
        }
    }

    void lookAtPlayer(GameObject player)
    {
        Vector3 delta = player.transform.position - transform.position;
        delta.y = 0;
        Quaternion rotation = Quaternion.LookRotation(delta);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
    }

    void attack(GameObject target){
        if (cooldown_countdown <= 0){
            animator.Play("Attack01");
            cooldown_countdown = 5f;
        }
        else{
            cooldown_countdown -= Time.deltaTime;
        }
    }

}
