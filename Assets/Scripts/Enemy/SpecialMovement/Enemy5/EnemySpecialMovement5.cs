using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialMovement5 : EnemySpecialMovementBase
{   
    float rotateSpeed = 3f;
    public GameObject swordRoundPrefab;
    GameObject swordRound;
    bool InitSwordRound = false;
    public bool DestroySwordRound = false;
    public GameObject detectTarget;
    Animator animator;
    protected override void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        animator = gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>();
    }

    protected override void specialMove(GameObject target)
    {   
        
        
        animator.SetBool("isDetect", true);
        lookAtPlayer(target);

        GameObject maxAttackRangeSphere = gameObject.transform.GetChild(3).gameObject;
        float dist = Vector3.Distance(rb.position, target.transform.position);
        if (dist >= maxAttackRangeSphere.transform.lossyScale.x){
            rb.velocity = transform.forward * speed;    
            animator.SetBool("idle", false);
        }
        else{
            rb.velocity = Vector3.zero;
            animator.SetBool("idle", true);  
        }
        
        detectTarget = target;
        enemyAttackAction(target);
        

    }
    public void assignTarget(){

        swordRound.transform.GetChild(0).GetComponent<SwordRound>().target = detectTarget;

    }

    void enemyAttackAction(GameObject target){

        if(!InitSwordRound){
            Vector3 position = transform.position;
            position.y += 1.5f;
            swordRound = (GameObject)Instantiate(swordRoundPrefab, position, Quaternion.identity);
            swordRound.transform.parent = gameObject.transform;
            InitSwordRound = true;
        }
        if(DestroySwordRound){
            Destroy(swordRound);
            InitSwordRound = false;
            DestroySwordRound = false;
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
