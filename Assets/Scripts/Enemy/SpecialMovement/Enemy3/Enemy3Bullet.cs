using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Bullet : MonoBehaviour
{
    public int damage = 5;
    private float shootCountdown = 0.5f;
    private float startVelocity = 10f;
    private bool shoot = false;

    private void Start()
    {
    }

    private void Update()
    {
        shootCountdown -= Time.deltaTime;
        if (shootCountdown <= 0&&shoot==false)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(startVelocity * transform.forward, ForceMode.VelocityChange);
            shoot = true;
        }   

    }




    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().GetHurt(damage);
            Destroy(gameObject);
        }else if (other.tag == "Wall" || other.tag == "Floor")
        {

            Destroy(gameObject);
        }




    }



}
