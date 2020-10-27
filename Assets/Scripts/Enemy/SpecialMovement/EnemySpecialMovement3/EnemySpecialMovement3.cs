using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialMovement3 : EnemySpecialMovementBase
{
    private float rotateSpeed = 90f;
    public GameObject enemy3bulletPrefab;
    private float shootCountDown=2f;

    protected override void specialMove()
    {
        Vector3 difference = player.transform.position - transform.position;
        difference.y = 0;
        Quaternion lookRotation = Quaternion.LookRotation(difference.normalized, Vector3.up);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);
        if (Quaternion.Angle(transform.rotation, lookRotation) < 3f)
        {
            shootCountDown -= Time.deltaTime;
            if (shootCountDown <= 0)
            {
                GameObject bullet =Instantiate(enemy3bulletPrefab, transform.GetChild(2).position, transform.GetChild(2).rotation);
                bullet.GetComponent<Enemy3Bullet>().setPlayer(player);
                shootCountDown = 2f;
            }
        }
        else
        {
            shootCountDown = 2f;
        }
    }
}
