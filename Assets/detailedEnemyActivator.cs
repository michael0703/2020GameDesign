using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detailedEnemyActivator : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
