using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet1 : BulletBase
{   
    public int collideObjectTag;
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            //Debug.Log("This is Skill 1 Hit Enemy, will do no damage");
        }
        if(other.gameObject.tag=="Wall" || other.gameObject.tag=="Floor" )
        {   
            if (other.gameObject.tag=="Wall") collideObjectTag = 2;
            if (other.gameObject.tag=="Floor") collideObjectTag = 1;
            isReady = true;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();
            rb.velocity = Vector3.zero;
        }
        
    }
}
