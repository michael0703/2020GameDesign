using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialMovement4 : EnemySpecialMovementBase
{
    public float rotateSpeed = 3f;
    public float attackSpeed = 2f;
    public float attackDistance = 2f;
    public int damage = 5;
    public float noiseWalkLasting = 0.5f;
    private float attackCounting;
    private float noiseWalkCounting;
    private float noiseWalkPattern;
    private GameObject foot;
    private Animator animator;
    protected override void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        attackCounting = 0;
        noiseWalkCounting = 0;

        animator = transform.GetChild(0).gameObject.GetComponent<Animator>();

        foot = transform.GetChild(1).gameObject;
        foot.transform.localScale = new Vector3(1, Random.Range(0, 5f), 1);
    }
    protected override void specialMove(GameObject target)
    {
        lookAtPlayer(target);
        noiseWalkCounting -= Time.deltaTime;
        if(noiseWalkCounting<=0)
        {
            noiseWalkCounting = noiseWalkLasting;
            noiseWalkPattern = Random.Range(-1.0f, 1.0f);      
        }
        rb.velocity = speed * (transform.forward + 0.2f * noiseWalkPattern * transform.right);

        Vector3 difference=target.transform.position - transform.position;
        difference.y = 0;
        if (difference.magnitude < attackDistance)
        {
            rb.velocity = Vector3.zero;
            attackCounting -= Time.deltaTime;
            if(attackCounting<=0)
            {
                animator.Play("Attack");
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
