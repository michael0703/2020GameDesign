using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialMovementBase : MonoBehaviour
{
    //This class describe how enemy move after detecting player.
    public bool detectPlayer = false;
    public bool detectScareCrow = false;
    public GameObject player;
    public GameObject scareCrow;
    public float speed = 1f;
    protected Rigidbody rb;

    protected virtual void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }
    protected virtual void specialMove(GameObject target)
    {

    }
    void Update()
    {   
        if(detectScareCrow==true && scareCrow==null)
        {
            detectScareCrow=false;
            gameObject.GetComponent<EnemyMovement>().detectScareCrow = false;
            scareCrow = null;
            gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("isDetect", false);
            detectPlayer = false;
            player = null;
        }
        if(detectScareCrow)
        {
            specialMove(scareCrow);
        }
        else if(detectPlayer)
        {
            specialMove(player);
        }
    }
}
