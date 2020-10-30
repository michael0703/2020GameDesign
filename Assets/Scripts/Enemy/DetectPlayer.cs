using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    private GameObject enemy;

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
            enemy.GetComponent<EnemySpecialMovementBase>().player = other.gameObject;
            
        }
        if(other.gameObject.tag=="Scarecrow")
        {
            enemy.GetComponent<EnemyMovement>().detectScareCrow = true;
            enemy.GetComponent<EnemySpecialMovementBase>().detectScareCrow = true;
            enemy.GetComponent<EnemySpecialMovementBase>().scareCrow = other.gameObject;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Scarecrow")
        {
            enemy.GetComponent<EnemyMovement>().detectScareCrow = false;
            enemy.GetComponent<EnemySpecialMovementBase>().detectScareCrow = false;
            enemy.GetComponent<EnemySpecialMovementBase>().scareCrow = null;
        }
    }
}
