using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamagePopUp : MonoBehaviour
{
    // Start is called before the first frame update
    float existTime = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        existTime += Time.deltaTime;
        if (existTime > 0.5f){
            Object.Destroy(gameObject);
        }
    }
}
