using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialMovement2 : EnemySpecialMovementBase
{
    public int damage = 5;
    private float rotateSpeed=90f;
    private float attackCountDown = 3f;

    protected override void specialMove(GameObject target)
    {
        
        Vector3 difference=target.transform.position - transform.position;
        difference.y = 0;
        Quaternion lookRotation=Quaternion.LookRotation(difference.normalized,Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation,lookRotation,rotateSpeed*Time.deltaTime);
        if (Quaternion.Angle(transform.rotation, lookRotation) < 3f)
        {
            if (difference.magnitude > 3)
            {
                transform.Translate(difference.normalized * speed * Time.deltaTime, Space.World);
                attackCountDown = 3f;
            }
            else
            {
                attackCountDown -= Time.deltaTime;
                if (attackCountDown < 0)
                {
                    target.GetComponent<PlayerHealth>().GetHurt(damage);
                    attackCountDown = 3f;
                    //Debug.Log("enemy2 damage");
                }
            }

        }
        else
        {
            attackCountDown = 3f;
        }
    }
}
