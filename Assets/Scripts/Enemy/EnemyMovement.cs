using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //This class describe how enemy move before detecting player.
    //random walk
    public float speed = 1f;
    public bool detectPlayer = false;

    private Rigidbody rb;
    private float timeCount = 0;
    private Vector3 movePattern;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(!detectPlayer)
        {
            timeCount -= Time.deltaTime;
            if(timeCount <= 0)
            {
                timeCount = Random.Range(0, 2f);
                movePattern = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            }
            rb.MovePosition(transform.position + movePattern * speed * Time.deltaTime);
        }
        
    }
}
