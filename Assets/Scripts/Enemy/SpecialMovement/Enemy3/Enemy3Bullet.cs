﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Bullet : MonoBehaviour
{
    public int damage = 5;
    private float startVelocity = 10f;

    private void Start()
    {
        gameObject.GetComponent<Rigidbody>().AddForce(startVelocity * transform.forward, ForceMode.VelocityChange);

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().GetHurt(damage);
            Destroy(gameObject);
        }
        if(other.tag=="Wall" || other.tag=="Floor" || other.tag=="Scarecrow")
        {
            Destroy(gameObject);
        }
    }

}
