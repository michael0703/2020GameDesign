using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill5 : SkillBase
{   
    private GameObject player;
    public bool isTargetCombo = false;
    public GameObject skillManager;
    public GameObject spBullet5_prefab;
    public GameObject targetObject; 
    public Transform targetTransform;
    public GameObject smokeEffectPrefab;
    protected override void ActivateSkill()
    {   
        if (isTargetCombo){
            
            int hitTimePrev = bullets[0].GetComponent<SpecialBullet5>().hitTime;
            activateTargetCombo(hitTimePrev);
            DestroySkill();
        }
        else{
            player = GameObject.Find("/Player/MainCamera/Gun");

            for(int i = 0; i < bullets.Length; i++){
                GameObject reflectGoal = bullets[i].GetComponent<SpecialBullet5>().reflectObject;
                if (!reflectGoal){
                    reflectGoal = player;
                }
                Vector3 velocity = reflectGoal.transform.position - bullets[i].gameObject.transform.position;
                bullets[i].GetComponent<Rigidbody>().velocity = velocity * 3f;
                bullets[i].GetComponent<SpecialBullet5>().isWaitingToActivate = true;
                GameObject smoke = (GameObject)Instantiate(smokeEffectPrefab, bullets[i].gameObject.transform.position, Quaternion.identity);
                smoke.transform.parent = bullets[i].transform;
            }
        }
    }
    void activateTargetCombo(int hitTimePrev){
        skillManager = GameObject.Find("SkillManager");
        int cloneBulletNum = 10;
        for(int i=0; i<cloneBulletNum; i++){
            Vector3 initPos = targetTransform.position;
            initPos.y +=  targetTransform.localScale.y * 0.5f * 0.75f;
            float eulerRotationY = (360 / cloneBulletNum) * i;
            Vector3 tmp = Vector3.zero;
            tmp.x = Mathf.Cos(Mathf.Deg2Rad*eulerRotationY);
            tmp.z = Mathf.Sin(Mathf.Deg2Rad*eulerRotationY);
            tmp = tmp.normalized * targetTransform.localScale.y * 0.9f;
            initPos.x += tmp.x;
            initPos.z += tmp.z;
            Quaternion initRotate = Quaternion.Euler(0, eulerRotationY, 0);
            GameObject specialBullet = (GameObject)Instantiate(spBullet5_prefab, initPos, Quaternion.identity);
            specialBullet.transform.forward = new Vector3(tmp.x, 0, tmp.z);
            specialBullet.GetComponent<SpecialBullet5>().isCloneBullet = true;
            specialBullet.GetComponent<SpecialBullet5>().hitTime = hitTimePrev + 1;
            specialBullet.GetComponent<SpecialBullet5>().reflectObject = targetObject;
            bool isFull = skillManager.GetComponent<SkillManager>().RegistBullet(specialBullet);
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
            DestroySkill();
        }
    }
}
