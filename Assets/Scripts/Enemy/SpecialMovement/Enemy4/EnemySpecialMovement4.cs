using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialMovement4 : EnemySpecialMovementBase
{
    public float rotateSpeed = 3f;
    public float attackSpeed = 2f;
    public float attackDistance = 2f;
    public int damage = 5;
    private float attackCounting;
    protected override void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        attackCounting = 0;
    }
    protected override void specialMove(GameObject target)
    {
        lookAtPlayer(target);
        rb.velocity = speed * transform.forward;

        Vector3 difference=target.transform.position - transform.position;
        difference.y = 0;
        if (difference.magnitude < attackDistance)
        {
            attackCounting -= Time.deltaTime;
            if(attackCounting<=0)
            {
                target.GetComponent<PlayerHealth>().GetHurt(damage);
                attackCounting = attackSpeed;
            }
        }
        
    }
    void lookAtPlayer(GameObject player)
    {
        Vector3 delta = player.transform.position - transform.position;
        delta.y = 0;
        // delta.x = 0;
        Quaternion rotation = Quaternion.LookRotation(delta);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
    }
    
    
}
