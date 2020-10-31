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

    protected override void specialMove(GameObject target)
    {
        lookAtPlayer(target);
        rb.velocity = transform.forward * speed;

        enemyAttackAction();

    }
    void enemyAttackAction(){

        if(!InitSwordRound){
            Vector3 position = gameObject.transform.Find("InnerCollider").transform.position;
            position.y += 1f;
            swordRound = (GameObject)Instantiate(swordRoundPrefab, position, Quaternion.identity);
            swordRound.transform.parent = gameObject.transform;
            // swordRound.name = "SwordRound";
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
