using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashingDetect : MonoBehaviour
{
    GameObject enemy;

    private void Start()
    {
        enemy = transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player" || other.gameObject.tag=="Scarecrow")
        {
            enemy.GetComponent<EnemySpecialMovement0>().playerInSight = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Player" || other.gameObject.tag=="Scarecrow")
        {
            enemy.GetComponent<EnemySpecialMovement0>().playerInSight = false;
        }
    }
}
