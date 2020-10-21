using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : SkillBase
{   
    public GameObject scareCrowPrefab;
    protected override void ActivateSkill()
    {
           Debug.Log("Activate");
           GameObject scareCrow = (GameObject)Instantiate(scareCrowPrefab);
           scareCrow.transform.position = bullets[0].transform.position;

    }
}
