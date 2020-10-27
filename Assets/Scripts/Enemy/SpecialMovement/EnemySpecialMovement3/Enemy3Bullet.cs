using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy3Bullet : MonoBehaviour
{
    private GameObject player;
    private float rotateSpeed = 90f;
    private float moveSpeed = 2f;

    public void setPlayer(GameObject player)
    {

        this.player = player;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 difference = player.transform.position - transform.position;
        difference.y = 0;

        if (difference.magnitude < moveSpeed * Time.deltaTime)
        {
            Debug.Log("enemy3 demage");
            player.GetComponent<PlayerHealth>().GetHurt(5);
            Destroy(gameObject);
        }
        else
        {
            Quaternion lookRotation = Quaternion.LookRotation(difference.normalized, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, rotateSpeed * Time.deltaTime);
            transform.Translate(difference.normalized * moveSpeed * Time.deltaTime, Space.World);
        }
    }
}
