using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterMove : EnemySpecialMovementBase
{
    private float timeCount = 0;
    private Vector3 movePattern;

    protected override void Start()
    {

    }
    protected override void specialMove(GameObject target)
    {
        timeCount -= Time.deltaTime;
        if(timeCount<=0)
        {
            timeCount = 1f;
            movePattern = new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f)); 
        }
        transform.position += movePattern * speed * Time.deltaTime;
    }

    private void OnDestroy()
    {
        gameObject.transform.parent.GetComponent<CreateMiniEnemy>().CountLeft();
    }
}
