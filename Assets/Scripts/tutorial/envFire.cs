using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class envFire : MonoBehaviour
{
    // Start is called before the first frame update
    float firestay = 0f;
    float flameTimer = 3f;
    float restTimer = 5f;
    public float flameTime;
    public float restTime;
    Collider collider;
    int state = 1;
    // state = 1 means fire, 0 means rest;
    void Start()
    {
        flameTimer = flameTime;
        restTimer = restTime;
        collider = gameObject.GetComponent<CapsuleCollider>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (state == 1){
            flameTimer -= Time.deltaTime;
            if (flameTimer <= 0){
                state = 0;
                ParticleSystem ps = gameObject.transform.parent.gameObject.GetComponent<ParticleSystem>();
                ps.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
                var m = ps.main;
                m.duration = flameTime;
                collider.enabled = !collider.enabled;
                restTimer = restTime;
                flameTimer = flameTime;
            }
        }
        else{
            restTimer -= Time.deltaTime;
            if (restTimer <= 0){
                state = 1;
                var ps = gameObject.transform.parent.gameObject.GetComponent<ParticleSystem>();
                ps.Play();
                collider.enabled = !collider.enabled;
                restTimer = restTime;
                flameTimer = flameTime;   
            }
        }
        
    }
    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            
            other.gameObject.GetComponent<PlayerHealth>().GetHurt(5);
        }
    }
    void OnTriggerStay(Collider other){
        if (other.tag == "Player"){
            firestay += Time.deltaTime;
            if (firestay >= 1f){
                firestay = 0f;
                other.gameObject.GetComponent<PlayerHealth>().GetHurt(5);
            }
        }
    }

}
