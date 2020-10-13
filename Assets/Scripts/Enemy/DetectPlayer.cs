using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    GameObject parent;

    private void Start()
    {
        parent = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            parent.GetComponent<EnemyMovement>().detectPlayer = true;
            parent.GetComponent<EnemySpecialMovement>().detectPlayer = true;
        }
    }
}
