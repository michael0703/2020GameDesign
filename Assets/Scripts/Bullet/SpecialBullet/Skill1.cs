using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : SkillBase
{   
    public GameObject scareCrowPrefab;
    protected override void ActivateSkill()
    {       
           if (bullets[0].GetComponent<SpecialBullet1>().collideObjectTag == 1){
               Debug.Log("Activate");
               GameObject scareCrow = (GameObject)Instantiate(scareCrowPrefab);
               scareCrow.transform.position = bullets[0].transform.position;
           }
           else{
                Debug.Log("Hit Wall, Nothing Happenend");
           }
           DestroySkill();
    }
}
