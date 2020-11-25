using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareCrow : MonoBehaviour
{
    public float lastingTime = 6f;
    private float InstantiateTime;
    GameObject player;
    void Start()
    {
        InstantiateTime = 0;
        player = GameObject.Find("/Player");
        transform.forward = player.transform.position - transform.position;
    }

    void Update()
    {
        InstantiateTime += Time.deltaTime;
        if (InstantiateTime > lastingTime){
            Object.Destroy(gameObject);
        }
        
    }
}
