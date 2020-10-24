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
        if(other.gameObject.tag=="Scarecrow")
        {
            enemy.GetComponent<EnemyMovement>().detectScareCrow = true;
            enemy.GetComponent<EnemySpecialMovementBase>().detectScareCrow = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            enemy.GetComponent<EnemyMovement>().detectPlayer = false;
            enemy.GetComponent<EnemySpecialMovementBase>().detectPlayer = false;
            
        }
        if(other.gameObject.tag=="Scarecrow")
        {
            enemy.GetComponent<EnemyMovement>().detectScareCrow = false;
            enemy.GetComponent<EnemySpecialMovementBase>().detectScareCrow = false;
        }
    }
}
