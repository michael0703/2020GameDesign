using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScareCrow : MonoBehaviour
{
    // Start is called before the first frame update
    public float InstantiateTime;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        InstantiateTime += Time.deltaTime;
        if (InstantiateTime > 3){
            Object.Destroy(this.gameObject);
        }
        
    }
}
