using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMove : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isAttacking = false;
    public bool isReadyToDie = false;
    float speed = 10f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isAttacking){
            transform.position += transform.up * speed * Time.deltaTime;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            Debug.Log("Hit Player");
            speed = 0f;
            isReadyToDie = true;
            GameObject player = GameObject.Find("/Player");
            player.GetComponent<PlayerHealth>().GetHurt(50);
            
        }
        if(other.gameObject.tag=="Wall" || other.gameObject.tag=="Floor")
        {
            Debug.Log("Hit Wall (Floor)");
            speed = 0f;
            isReadyToDie = true;
        }
    }
}
