using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet2 : BulletBase
{
    private bool hit = false;
    protected override void OnTriggerEnter(Collider collision)
    {
        if (hit == false)
        {
            if (collision.gameObject.GetComponent<Target>())
            {

                skill.GetComponent<Skill2>().setType(Skill2.explosiontype.superExplosion);
                isReady = true;
                rb.velocity = Vector3.zero;
                skill.GetComponent<SkillBase>().CheckBulletAreReady();
                hit = true;


            }
            else if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Wall")
            {
                skill.GetComponent<Skill2>().setType(Skill2.explosiontype.explosion);
                isReady = true;
                rb.velocity = Vector3.zero;
                skill.GetComponent<SkillBase>().CheckBulletAreReady();
                hit = true;


            }

        }
    }

}
