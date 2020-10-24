using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : SkillBase
{

    public GameObject shieldPrefab;

    protected override void ActivateSkill()
    {

        Instantiate(shieldPrefab, bullets[0].transform.position, bullets[0].transform.rotation);
        Destroy(bullets[0]);
        Destroy(gameObject);


    }
}
