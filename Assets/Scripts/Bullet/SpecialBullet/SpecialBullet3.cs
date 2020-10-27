using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet3 : BulletBase
{
    private float activateCountDown = 0.5f;
    private void Update()
    {

        activateCountDown -= Time.deltaTime;
        if (activateCountDown<=0)
        {
            isReady = true;
            rb.velocity = Vector3.zero;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();
        }
    }


    protected override void OnTriggerEnter(Collider other)
    {
        //override to do nothing.
    }
}
