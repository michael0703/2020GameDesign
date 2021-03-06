﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareCrowArea : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            other.gameObject.GetComponent<EnemyMovement>().detectScareCrow = true;
            other.gameObject.GetComponent<EnemySpecialMovementBase>().detectScareCrow = true;
            other.gameObject.GetComponent<EnemySpecialMovementBase>().scareCrow = transform.parent.gameObject;
            other.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("isDetect", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            other.gameObject.GetComponent<EnemyMovement>().detectScareCrow = false;
            other.gameObject.GetComponent<EnemySpecialMovementBase>().detectScareCrow = false;
            other.gameObject.GetComponent<EnemySpecialMovementBase>().scareCrow = null;
            other.gameObject.transform.GetChild(0).gameObject.GetComponent<Animator>().SetBool("isDetect", false);
        }
    }
}
