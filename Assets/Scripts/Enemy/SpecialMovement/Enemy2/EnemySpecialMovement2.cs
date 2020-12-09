using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialMovement2 : EnemySpecialMovementBase
{
    public int damage = 5;
    private float rotateSpeed=90f;

    public float attackRadius = 3f;
    private int attackTime = -1;


    protected override void specialMove(GameObject target)
    {

        Vector3 difference = target.transform.position - transform.position;
        difference.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(difference.normalized, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);

        if (transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer.SpecialMovement.Attack02"))
        {
            attackTime = -1;
        }

        if (difference.magnitude < attackRadius)
        {
            transform.GetChild(0).GetComponent<Animator>().SetBool("withinRange", true);
            /*
            shootCountDown -= Time.deltaTime;
            if (shootCountDown <= 0)
            {
                //transform.GetChild(0).GetComponent<Animator>().SetBool("isDetect", false);
                GameObject bullet =Instantiate(enemy3bulletPrefab, transform.GetChild(1).position, Quaternion.LookRotation(target.transform.position - transform.GetChild(1).position));

                shootCountDown = 2f;
            }*/

            if (transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).fullPathHash == Animator.StringToHash("Base Layer.SpecialMovement.Attack02") && transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime > attackTime && transform.GetChild(0).GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).normalizedTime - attackTime - 1 > 0.45)
            {
                attackTime += 1;
                target.GetComponent<PlayerHealth>().GetHurt(damage);

            };

        }
        else
        {
            transform.GetChild(0).GetComponent<Animator>().SetBool("withinRange", false);
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }

    }
}
