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

    protected override void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            Debug.Log("This is Skill 5 Hit Enemy, will do no damage");
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
            Debug.Log("Destroy");
            rb.velocity = Vector3.zero;
            Object.Destroy(this.gameObject);
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
