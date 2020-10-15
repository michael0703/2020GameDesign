﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet2 : BulletBase
{
    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().GetHurt(damage);
        }
        if(other.gameObject.tag=="Wall")
        {
            isReady = true;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();
            rb.velocity = Vector3.zero;
        }
        
    }
}
