using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public bool isMovable = true;
    public Material freezeMaterial;
    private float slowArgument;
    private float timeCount;
    
    private bool isSlow = false;
    private Material ori;
    private Renderer rend;

    void Start()
    {
        GameObject tmp = gameObject.transform.GetChild(0).gameObject;
        foreach(Transform item in tmp.transform)
        {
            Renderer tmpp=item.GetComponent<Renderer>();
            if(tmpp!=null)
            {
                rend = tmpp;
                ori = tmpp.material;
            }
        }
    }

    public void SlowDown(float time, float arg)
    {
        slowArgument = arg;
        if(isMovable && isSlow)
        {
            timeCount = time;
        }
        else if(isMovable)
        {
            GetSlowStart(time);
        }
            
    }
    private void GetSlowStart(float time)
    {
        rend.material = freezeMaterial;
        isSlow = true;
        timeCount = time;
        gameObject.GetComponent<EnemySpecialMovementBase>().speed *= slowArgument;
        gameObject.GetComponent<EnemyMovement>().speed *= slowArgument;
    }
    private void GetSlowEnd()
    {
        rend.material = ori;
        isSlow = false;
        gameObject.GetComponent<EnemySpecialMovementBase>().speed /= slowArgument;
        gameObject.GetComponent<EnemyMovement>().speed /= slowArgument;
    }

    private void Update()
    {
        if(isSlow)
        {
            timeCount -= Time.deltaTime;
            if(timeCount<=0)
            {
                GetSlowEnd();
            }
        }
    }
}
