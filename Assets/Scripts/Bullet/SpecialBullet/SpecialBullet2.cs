using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet2 : BulletBase
{
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Floor")
        {

            isReady = true;
            rb.velocity = Vector3.zero;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();

        }


    }

}
