using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill0 : SkillBase
{
    public GameObject slowLinePrefab;
    protected override void ActivateSkill()
    {
        Vector3 bullet0Pos = bullets[0].transform.position;
        Vector3 bullet1Pos = bullets[1].transform.position;
        Vector3 goalPos = Vector3.Lerp(bullet0Pos, bullet1Pos, 0.5f);
 
        float length = (Vector3.Distance(bullet0Pos, bullet1Pos)/2)*1.05f;
        Vector3 goalScale = new Vector3(0.1f,length,0.1f);

        GameObject slowLine = (GameObject)Instantiate(slowLinePrefab, goalPos, Quaternion.identity);
        slowLine.transform.up = bullets[0].transform.position - bullets[1].transform.position;
        slowLine.transform.localScale = goalScale;

        DestroySkill();
    }
}
