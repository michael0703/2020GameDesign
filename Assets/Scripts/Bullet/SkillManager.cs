using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    // This class create skills and put bullets in them.
    public GameObject [] skillPrefabs;
    private int [] numOfBulletInSkill;
    private GameObject [] skillList; 
    private int numOfSkillType;

    void Start()
    {
        GameObject globalVar = GameObject.Find("GlobalVar");
        numOfSkillType = globalVar.GetComponent<GlobalVar>().numOfSkillType;
        numOfBulletInSkill = globalVar.GetComponent<GlobalVar>().numOfBulletInSkill;
        skillList = new GameObject[numOfSkillType];
        for(int i=0; i<numOfSkillType; i++)
        {
            skillList[i] = (GameObject)Instantiate(skillPrefabs[i],transform);
            skillList[i].GetComponent<SkillBase>().ResetSkill(numOfBulletInSkill[i]);
        }
    }
    public void RegistBullet(GameObject bullet)
    {
        int type = bullet.GetComponent<BulletBase>().skillType;
        if(skillList[type].GetComponent<SkillBase>().AddBullet(bullet))
        {
            skillList[type] = (GameObject)Instantiate(skillPrefabs[type],transform);
            skillList[type].GetComponent<SkillBase>().ResetSkill(numOfBulletInSkill[type]);
        }
    }
}
