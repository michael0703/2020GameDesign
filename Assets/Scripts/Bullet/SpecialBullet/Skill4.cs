using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : SkillBase
{
    public GameObject targetPrefab;
    public GameObject followEnemy;
    protected override void ActivateSkill()
    {
        GameObject target = (GameObject)Instantiate(targetPrefab, bullets[0].transform.position, Quaternion.identity);
        if(followEnemy != null)
            target.transform.parent = followEnemy.transform;
        DestroySkill();  
    }
}
