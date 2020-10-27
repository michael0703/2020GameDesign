using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterMove : MonoBehaviour
{
    public int damage = 3;
    public float speed = 1f;

    private float timeCount = 0;
    private Vector3 movePattern;

    void Update()
    {
        timeCount -= Time.deltaTime;
        if(timeCount<=0)
        {
            timeCount = 1f;
            movePattern = new Vector3(Random.Range(-0.5f, 0.5f), 0, Random.Range(-0.5f, 0.5f)); 
        }
        transform.position += movePattern * speed * Time.deltaTime;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().GetHurt(damage);
        }
    }
    private void OnDestroy()
    {
        gameObject.transform.parent.GetComponent<CreateMiniEnemy>().CountLeft();
    }
}
