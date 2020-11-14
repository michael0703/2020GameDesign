using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3 : SkillBase
{

    public GameObject shieldPrefab;

    protected override void ActivateSkill()
    {
        Vector3 shootXZDirection = bullets[0].transform.forward;
        shootXZDirection.y = 0;

        GameObject shield= Instantiate(shieldPrefab, bullets[0].transform.position, Quaternion.LookRotation(shootXZDirection));
        Destroy(shield, 5f);
        DestroySkill();


    }
}
