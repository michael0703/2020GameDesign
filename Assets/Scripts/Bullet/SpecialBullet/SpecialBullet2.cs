using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet2 : BulletBase
{

    protected void OnColliderEnter(Collider other)
    {




        if(other.gameObject.tag=="Floor")
        {
            isReady = true;
            rb.velocity = Vector3.zero;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();
            
        }
        
    }
}
