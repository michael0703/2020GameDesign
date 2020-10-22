using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowLine : MonoBehaviour
{
    public float lastingTime = 5f;
    public float effectTime = 10f;
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
            //other.gameObject.GetComponent<EnemySpecialMovementBase>().SlowDown(effectTime);
        }
    }
}
