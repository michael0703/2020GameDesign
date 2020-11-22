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
    private GameObject rend;

    void Start()
    {
        rend = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        ori = rend.GetComponent<Renderer>().material;
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
        rend.GetComponent<Renderer>().material = freezeMaterial;
        isSlow = true;
        timeCount = time;
        gameObject.GetComponent<EnemySpecialMovementBase>().speed *= slowArgument;
        gameObject.GetComponent<EnemyMovement>().speed *= slowArgument;
        // EnemyMovement moveObj = gameObject.GetComponent<EnemyMovement>();
        // if(moveObj!=null)
        //     moveObj.speed *= slowArgument;
    }
    private void GetSlowEnd()
    {
        GameObject rend = gameObject.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject;
        rend.GetComponent<Renderer>().material = ori;
        isSlow = false;
        gameObject.GetComponent<EnemySpecialMovementBase>().speed /= slowArgument;
        gameObject.GetComponent<EnemyMovement>().speed /= slowArgument;
        // EnemyMovement moveObj = gameObject.GetComponent<EnemyMovement>();
        // if(moveObj!=null)
        //     moveObj.speed /= slowArgument;
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
