using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public bool isActive = false;
    private GameObject levelManager;

    private void Start()
    {
        levelManager = GameObject.Find("LevelManager");
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player" && isActive)
        {
            levelManager.GetComponent<LevelManager>().Win();
        }
    }
}
