using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialMovement5 : EnemySpecialMovementBase
{   
    float rotateSpeed = 3f;
    protected override void specialMove()
    {
        lookAtPlayer(player);
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
