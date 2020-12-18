using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet4 : BulletBase
{
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy" || other.gameObject.tag=="Wall" || other.gameObject.tag=="Floor"|| other.gameObject.tag == "Scarecrow")
        {
            rb.velocity = Vector3.zero;
            if(other.gameObject.tag == "Enemy")
                skill.GetComponent<Skill4>().followEnemy = other.gameObject;
            isReady = true;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();
            
        }
        
    }
}
