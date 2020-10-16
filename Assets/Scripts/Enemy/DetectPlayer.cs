using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    GameObject enemy;

    private void Start()
    {
        enemy = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            enemy.GetComponent<EnemyMovement>().detectPlayer = true;
            enemy.GetComponent<EnemySpecialMovementBase>().detectPlayer = true;
        }
    }
}
