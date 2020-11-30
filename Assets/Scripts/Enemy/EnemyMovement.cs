using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    //This class describe how enemy move before detecting player.
    //random walk
    public float speed = 1f;
    public bool detectPlayer = false;
    public bool detectScareCrow = false;
    public bool isDead = false;

    private Rigidbody rb;
    private float timeCount = 0;
    private Vector3 movePattern;
    private float rotateSpeed = 0.8f;
    private Quaternion qTo;
    
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        qTo = Quaternion.Euler(new Vector3(0f,Random.Range(-180f, 180f), 0f));
    }
    void Update()
    {
        if(!detectPlayer && !detectScareCrow && !isDead)
        {
            timeCount -= Time.deltaTime;
            if(timeCount <= 0)
            {
                timeCount = 2f;
                movePattern = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
                qTo = Quaternion.Euler(new Vector3(0f,Random.Range(-180f, 180f), 0f));
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, qTo, Time.deltaTime * rotateSpeed);
            rb.MovePosition(transform.position + movePattern * speed * Time.deltaTime);
        }
        
    }
}
