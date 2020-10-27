using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet2 : BulletBase
{
    protected override void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag=="Wall")
        {

            isReady = true;
            rb.velocity = Vector3.zero;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();

        }


    }

}
