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
            enemy.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("isDetect", true); 
        }

    }

}
