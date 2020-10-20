using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialMovementBase : MonoBehaviour
{
    //This class describe how enemy move after detecting player.
    public bool detectPlayer = false;
    protected GameObject player;
    protected Rigidbody rb;

    protected virtual void Start()
    {
        player = GameObject.Find("Player");
        rb = gameObject.GetComponent<Rigidbody>();
    }
    protected virtual void specialMove()
    {

    }
    void Update()
    {
        if(detectPlayer)
        {
            specialMove();
        }
    }
}
