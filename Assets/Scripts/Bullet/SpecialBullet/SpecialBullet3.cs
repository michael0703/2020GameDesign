using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet3 : BulletBase
{
    private float hitCountDown=10f;
    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag=="Floor")
        {
            isReady = true;
            rb.velocity = Vector3.zero;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();
        }
    }
    private void Update()
    {
        hitCountDown -= Time.deltaTime;
        if (hitCountDown <= 0)
        {
            Destroy(gameObject);
        }
    }
}
