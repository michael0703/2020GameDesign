using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill5 : SkillBase
{   
    private GameObject player;
    protected override void ActivateSkill()
    {   
        player = GameObject.Find("/Player/MainCamera/Gun");
        for(int i = 0; i < bullets.Length; i++){
            Vector3 velocity = player.transform.position - bullets[i].gameObject.transform.position;
            bullets[i].GetComponent<Rigidbody>().velocity = velocity * 3f;
            bullets[i].GetComponent<SpecialBullet5>().isWaitingToActivate = true;
        }
    }
    void Update(){
        bool flag = true;
        for(int i=0 ;i<bullets.Length; i++){
            if (bullets[i] == null || !bullets[i].GetComponent<SpecialBullet5>().isReadyToDie){
                flag = false;
            }
        }
        if(flag){
            for(int i=0; i<bullets.Length; i++){
                Object.Destroy(bullets[i].GetComponent<SpecialBullet5>().trackingRay);
            }
            DestroySkill();
        }
    }
}
