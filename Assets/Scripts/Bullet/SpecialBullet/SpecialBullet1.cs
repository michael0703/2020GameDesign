using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet1 : BulletBase
{
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            Debug.Log("This is Skill 1 Hit Enemy, will do no damage");
        }
        if(other.gameObject.tag=="Wall")
        {
            isReady = true;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();
            rb.velocity = Vector3.zero;
        }
        
    }
}
