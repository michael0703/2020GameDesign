using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet1 : BulletBase
{   
    public float bouncingFactor = 0.8f;
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Wall")
        {
            rb.velocity = new Vector3 (rb.velocity.x * -1 * bouncingFactor, rb.velocity.y, rb.velocity.z * bouncingFactor);
        }
        if(other.gameObject.tag=="Floor" )
        {   
            isReady = true;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();
            rb.velocity = Vector3.zero;
        }
        
    }

}
