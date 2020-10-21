using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBullet5 : BulletBase
{   
    public GameObject trackingRayPrefab;
    private GameObject trackingRay;
    private LineRenderer lineRenderer;
    private GameObject player;
    public bool isWaitingToActivate = false;
    public bool isReadyToDie = false;

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {   
            if(!isWaitingToActivate){
                Debug.Log("This is Skill 5 Hit Enemy, will do no damage");
            }
            else{
                other.gameObject.transform.parent.GetComponent<EnemyHealth>().GetHurt(damage * 4);
            }
        }
        if(other.gameObject.tag=="Wall")
        {

            isReady = true;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();
            if(!isWaitingToActivate){
                rb.velocity = Vector3.zero;
            }
            trackingRay = (GameObject)Instantiate(trackingRayPrefab);
            player = GameObject.Find("/Player/MainCamera/Gun");
            lineRenderer = trackingRay.GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, this.gameObject.transform.position);
            lineRenderer.SetPosition(1, player.transform.position);
            
        }
        if(other.gameObject.tag=="Player"){
            rb.velocity = Vector3.zero;
            Object.Destroy(trackingRay);
            isReadyToDie = true;
        }
    }
    public void Update(){
        if (trackingRay){
            lineRenderer.SetPosition(1, player.transform.position);
        }
    }
    void OnDestroy()
    {
        Object.Destroy(trackingRay);
    }
}
