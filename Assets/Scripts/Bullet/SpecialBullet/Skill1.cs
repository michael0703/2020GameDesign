using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : SkillBase
{
    protected override void ActivateSkill()
    {
        Debug.Log("I have " + bullets.Length.ToString() + " bullets!");   
    }
}
