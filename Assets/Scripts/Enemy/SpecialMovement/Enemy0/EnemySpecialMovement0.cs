using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialMovement0 : EnemySpecialMovementBase
{
    public float dashFactor = 15f;
    public float rotateSpeed = 10f;
    public float chargingTime = 2f;
    public float dashingTime = 0.5f;
    public float coolingTime = 3f;
    public int state = 0;

    public bool playerInSight = false;
    private float chargingTimeCounting = 0;
    private float dashingTimeCounting = 0;
    private float coolingTimeCounting = 0;
    private Vector3 playerOldPos;
    protected override void specialMove(GameObject target)
    {
        if(state==0) // aproaching player
        {
            lookAtPlayer(target);
            rb.velocity = speed * transform.forward;
            if(playerInSight) 
            {
                state = 1;
                rb.velocity = new Vector3(0,0,0);
                turnOnWarning();
                playerOldPos = target.transform.position;
            }

        }
        else if(state==1) // charging
        {
            lookAtOldPlayer(playerOldPos);
            chargingTimeCounting += Time.deltaTime;
            if(chargingTimeCounting>=chargingTime)
            {
                chargingTimeCounting = 0;
                state = 2;
                rb.velocity = dashFactor * speed * transform.forward;
            }

        }
        else if(state==2) // dashing
        {
            dashingTimeCounting+= Time.deltaTime;
            if(dashingTimeCounting>=dashingTime)
            {
                dashingTimeCounting = 0;
                state = 3;
                turnOffWarning();
                rb.velocity = new Vector3(0,0,0);
            }
        }
        else if(state==3) // cooling
        {
            coolingTimeCounting += Time.deltaTime;
            if(coolingTimeCounting>=coolingTime)
            {
                coolingTimeCounting = 0;
                state = 0;
            }
        }
    }

    void lookAtPlayer(GameObject player)
    {
        Vector3 delta = player.transform.position - transform.position;
        delta.y = 0;
        // delta.x = 0;
        Quaternion rotation = Quaternion.LookRotation(delta);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
    }
    void lookAtOldPlayer(Vector3 oldPos)
    {
        Vector3 delta = oldPos - transform.position;
        delta.y = 0;
        // delta.x = 0;
        Quaternion rotation = Quaternion.LookRotation(delta);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotateSpeed);
    }

    void turnOnWarning()
    {
        GameObject warn = gameObject.transform.Find("Enemy0Warning").gameObject;
        warn.GetComponent<MeshRenderer>().enabled = true;
    }
    void turnOffWarning()
    {
        GameObject warn = gameObject.transform.Find("Enemy0Warning").gameObject;
        warn.GetComponent<MeshRenderer>().enabled = false;
    }

}
