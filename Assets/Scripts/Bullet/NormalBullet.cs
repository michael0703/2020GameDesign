using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : BulletBase
{
    public bool isFreezed = false;
    public float effectTime = 0;
    public float slowArgument = 1f;

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().GetHurt(damage);
            if(isFreezed)
            {
                other.gameObject.GetComponent<EnemyState>().SlowDown(effectTime,slowArgument);
            }
            Destroy(gameObject);
        }
        if(other.gameObject.tag=="Wall" || other.gameObject.tag=="Floor")
        {
            Destroy(gameObject);
        }
    
        
    }
}
