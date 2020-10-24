﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject ExplosionEffectPrefab;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode(5));

    }


    public IEnumerator Explode(int times)
    {
        for (int i = 0; i < times; i++)
        {
            Instantiate(ExplosionEffectPrefab, transform.position, transform.rotation);


            Collider[] colliders=Physics.OverlapSphere(transform.position, 5);
            foreach(Collider collider in colliders)
            {
                if (collider.tag == "enemy")
                {
                    Vector3 blownDirection = collider.transform.position -transform.position;
                    //if(collider.gameObject.GetComponent<EnemyState>().isMovable)
                        collider.gameObject.GetComponent<Rigidbody>().AddForce(blownDirection*100);
                    collider.gameObject.GetComponent<EnemyHealth>().GetHurt(100);


                };

            }


            yield return new WaitForSeconds(0.5f);
        }


    }
}
