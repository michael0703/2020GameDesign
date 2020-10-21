using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill5 : SkillBase
{   
    private GameObject player;
    protected override void ActivateSkill()
    {   
        player = GameObject.Find("/Player/MainCamera/Gun");
        Debug.Log(bullets.Length);
        for(int i = 0; i < bullets.Length; i++){
            Vector3 velocity = player.transform.position - bullets[i].gameObject.transform.position;
            bullets[i].GetComponent<Rigidbody>().velocity = velocity;
        }
    }
}
