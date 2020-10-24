using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BulletBase
{
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            other.gameObject.transform.parent.gameObject.GetComponent<EnemyHealth>().GetHurt(damage);
            Destroy(gameObject);
        }
        else if(other.gameObject.tag=="Wall" || other.gameObject.tag=="Floor")
        {
            Destroy(gameObject);
        }
        
    }
}
