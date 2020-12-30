using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondBoss : MonoBehaviour
{
    public GameObject secondWave;
    private bool born = false;

    // Update is called once per frame
    void Update()
    {
        if (!born&& gameObject.GetComponent<EnemyHealth>().currentHealth < 100)
        {
            secondWave.SetActive(true);
            born = true;
        }
    }
}
