using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyActivator : MonoBehaviour
{
    private GameObject enemiesObject;
    // Start is called before the first frame update
    void Start()
    {
        enemiesObject = gameObject.transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("out");
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("in");
            enemiesObject.SetActive(true);
        }
    }
}
