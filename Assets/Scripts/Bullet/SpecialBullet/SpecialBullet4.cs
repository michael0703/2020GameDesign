using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet4 : BulletBase
{
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy" || other.gameObject.tag=="Wall")
        {
            rb.velocity = Vector3.zero;
            isReady = true;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();
            
        }
        
    }
}
