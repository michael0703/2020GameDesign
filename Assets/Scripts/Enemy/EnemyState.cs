using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    public bool isMovable = true;
    public float slowArgument = 0.5f;
    private float timeCount;
    private bool isSlow = false;

    public void SlowDown(float time)
    {
        if(isMovable)
            SlowDown(time);
    }
    private void GetSlowStart(float time)
    {
        isSlow = true;
        timeCount = time;
        gameObject.GetComponent<Rigidbody>().velocity *= slowArgument;
    }
    private void GetSlowEnd()
    {
        isSlow = false;
        gameObject.GetComponent<Rigidbody>().velocity /= slowArgument;
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
