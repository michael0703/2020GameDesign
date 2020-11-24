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
            other.gameObject.GetComponent<Renderer>().material = freezeMaterial;
            NormalBullet sc = other.gameObject.GetComponent<NormalBullet>();
            sc.isFreezed = true;
            sc.effectTime = effectTime;
            sc.slowArgument = slowArgument;
        }
        if(other.gameObject.tag=="SkillBullet" && other.gameObject.GetComponent<BulletBase>().skillType==5)
        {
            other.gameObject.GetComponent<Renderer>().material = freezeMaterial;
            SpecialBullet5 sb = other.gameObject.GetComponent<SpecialBullet5>();
            sb.isFreezed = true;
            sb.effectTime = effectTime;
            sb.slowArgument = slowArgument;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            other.gameObject.GetComponent<EnemyState>().SlowDown(effectTime,slowArgument);
        }
    }

}
