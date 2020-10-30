using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public bool isMovable = true;
    private float slowArgument;
    private float timeCount;
    
    private bool isSlow = false;

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
        isSlow = true;
        timeCount = time;
        gameObject.GetComponent<EnemySpecialMovementBase>().speed *= slowArgument;
        EnemyMovement moveObj = gameObject.GetComponent<EnemyMovement>();
        if(moveObj!=null)
            moveObj.speed *= slowArgument;
    }
    private void GetSlowEnd()
    {
        isSlow = false;
        gameObject.GetComponent<EnemySpecialMovementBase>().speed /= slowArgument;
        EnemyMovement moveObj = gameObject.GetComponent<EnemyMovement>();
        if(moveObj!=null)
            moveObj.speed /= slowArgument;
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
