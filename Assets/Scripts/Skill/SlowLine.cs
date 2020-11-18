using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowLine : MonoBehaviour
{
    public float lastingTime = 5f;
    public float effectTime = 10f;
    public float slowArgument = 0.5f;

    public Material freezeMaterial;

    private float counting;
    void Start()
    {
        counting = lastingTime;
    }
    void Update()
    {
        counting -= Time.deltaTime;
        if(counting<=0)
        {
            counting = lastingTime;
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            other.gameObject.GetComponent<EnemyState>().SlowDown(effectTime,slowArgument);
        }
        if(other.gameObject.tag=="NormalBullet")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = freezeMaterial;
            NormalBullet sc = other.gameObject.GetComponent<NormalBullet>();
            sc.isFreezed = true;
            sc.effectTime = effectTime;
            sc.slowArgument = slowArgument;
        }
    }
}
