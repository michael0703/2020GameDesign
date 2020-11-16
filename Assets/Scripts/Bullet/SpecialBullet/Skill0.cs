using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill0 : SkillBase
{
    public float y = 0.1f;
    public float z = 0.1f;
    public GameObject slowLinePrefab;
    protected override void ActivateSkill()
    {
        Vector3 bullet0Pos = bullets[0].transform.position;
        Vector3 bullet1Pos = bullets[1].transform.position;
        Vector3 goalPos = Vector3.Lerp(bullet0Pos, bullet1Pos, 0.5f);
 
        float length = Vector3.Distance(bullet0Pos, bullet1Pos)*1.05f;
        Vector3 goalScale = new Vector3(length, y, z);

        GameObject slowLine = (GameObject)Instantiate(slowLinePrefab, goalPos, Quaternion.identity);
        slowLine.transform.right = bullets[0].transform.position - bullets[1].transform.position;
        //slowLine.transform.up = new Vector3(0,1,0);
        slowLine.transform.localScale = goalScale;

        DestroySkill();
    }
}
