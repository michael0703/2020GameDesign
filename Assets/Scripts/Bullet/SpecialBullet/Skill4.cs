using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : SkillBase
{
    public GameObject targetPrefab;
    protected override void ActivateSkill()
    {
        Instantiate(targetPrefab, bullets[0].transform.position, Quaternion.identity);
        DestroySkill();  
    }
}
