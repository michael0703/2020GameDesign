using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lastingTime = 5f;

    private GameObject bombArea;
    private float counting;

    private float effectTime = 0.1f;
    private float countingeffect;
    private bool isActive = false;
    void Start()
    {
        bombArea = transform.GetChild(0).gameObject;
        counting = lastingTime;
        countingeffect = effectTime;
    }
    void Update()
    {
        counting -= Time.deltaTime;
        if(counting<=0)
        {
            counting = lastingTime;
            Destroy(gameObject);
        }
        if(isActive)
        {
            countingeffect -= Time.deltaTime;
            if(countingeffect<=0)
            {
                countingeffect = effectTime;
                isActive = false;
                DeactivateArea();
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="NormalBullet")
        {
            ActivateArea();
        }
    }
    private void ActivateArea()
    {
        bombArea.GetComponent<MeshRenderer>().enabled = true;
        bombArea.GetComponent<SphereCollider>().enabled = true;
        isActive = true;
    }
    private void DeactivateArea()
    {
        bombArea.GetComponent<MeshRenderer>().enabled = false;
        bombArea.GetComponent<SphereCollider>().enabled = false;
        isActive = false;
    }
}
