using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float lastingTime = 5f;
    public GameObject explosionPrefab;
    public Material freezeMaterial;

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
            NormalBullet sc = other.gameObject.GetComponent<NormalBullet>();
            ActivateArea(sc.isFreezed, sc.effectTime, sc.slowArgument);
            Destroy(other.gameObject);
        }
    }
    private void ActivateArea(bool isFreeze, float effectTime, float slowArgument)
    {
        bombArea.GetComponent<BombArea>().Activate(isFreeze, effectTime, slowArgument);
        isActive = true;

        GameObject explosion = (GameObject)Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        if(isFreeze)
        {
            ParticleSystem.MainModule settings = explosion.GetComponent<ParticleSystem>().main;
            settings.startColor = freezeMaterial.color;
        }   
        explosion.transform.parent = transform;

    }
    private void DeactivateArea()
    {
        bombArea.GetComponent<BombArea>().Deactivate();
        isActive = false;
    }
}
