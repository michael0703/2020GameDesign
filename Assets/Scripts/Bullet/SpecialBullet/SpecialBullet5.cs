using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet5 : BulletBase
{   
    private GameObject player;
    public bool isWaitingToActivate = false;
    public bool isReadyToDie = false;
    public bool isCloneBullet = false;
    public int hitTime = 0;
    public GameObject reflectObject = null;

    //for slow
    public bool isFreezed = false;
    public float effectTime = 0;
    public float slowArgument = 1f;

    protected override void OnTriggerEnter(Collider other)
    {   
        if(other.gameObject.GetComponent<Target>() && hitTime < 2){
            // this means hit target, but there are 2 situations
            // if player hits, then trigger special skill
            if (!isReady){
                isReady = true;
                skill.GetComponent<Skill5>().isTargetCombo = true;
                skill.GetComponent<Skill5>().targetObject = other.gameObject;
                skill.GetComponent<Skill5>().targetTransform = other.gameObject.transform;
                skill.GetComponent<SkillBase>().CheckBulletAreReady();
            }
            // if this is bouncing bullet, then destroy
            else if (isReady){
                rb.velocity = Vector3.zero;
                isReadyToDie = true;
            }

        }
        if(other.gameObject.tag=="Enemy")
        {   
            if(!isWaitingToActivate){
                //Debug.Log("This is Skill 5 Hit Enemy, will do no damage");
            }
            else{
                Instantiate(hitEffectPrefab, transform.position, Quaternion.identity);
                if(isFreezed)
                {
                    other.gameObject.GetComponent<EnemyState>().SlowDown(effectTime,slowArgument);
                }
                other.gameObject.GetComponent<EnemyHealth>().GetHurt(damage * 4);
            }
        }
        if(hitTime >= 2 && other.gameObject.tag=="Wall"){
            //Debug.Log("Bullet Bounce too many times, destroy");
            isReadyToDie = true;
            rb.velocity = Vector3.zero;
        }
        if(other.gameObject.tag=="Wall" || other.gameObject.tag=="Floor" )
        {

            isReady = true;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();
            if(!isWaitingToActivate){
                rb.velocity = Vector3.zero;
            }
            player = GameObject.Find("/Player/MainCamera/Gun");
            
            
        }
        if(other.gameObject.tag=="Player"){
            //Debug.Log("Hit User, Bullet5 Destroy");
            rb.velocity = Vector3.zero;
            isReadyToDie = true;
        }
    }
    public void Update(){
        if (!isReady){
            rb.velocity -= rb.transform.forward * 0.25f;
        }
        float angle = Vector3.Angle(rb.velocity, rb.transform.forward);
        if (Mathf.Abs(angle - 180f) < 1f){
            isReady = true;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();
        }
    }
}
