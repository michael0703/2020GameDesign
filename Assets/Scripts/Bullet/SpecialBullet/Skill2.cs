using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : SkillBase
{


    public GameObject ExplosionPrefab;
    protected override void ActivateSkill()
    {
        Instantiate(ExplosionPrefab, bullets[0].transform.position, bullets[0].transform.rotation);
        Destroy(bullets[0]);
        Destroy(gameObject);
    }

}
