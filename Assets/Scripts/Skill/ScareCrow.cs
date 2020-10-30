using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareCrow : MonoBehaviour
{
    public float lastingTime = 3f;
    private float InstantiateTime;
    void Start()
    {
        InstantiateTime = 0;
    }

    void Update()
    {
        InstantiateTime += Time.deltaTime;
        if (InstantiateTime > lastingTime){
            Object.Destroy(this.gameObject);
        }
        
    }
}
