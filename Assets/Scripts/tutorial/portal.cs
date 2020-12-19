using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class portal : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other){
        if (other.tag == "Player"){
            
            
            //Debug.Log("Need to teleport");
            GameObject transportObj = transform.GetChild(0).gameObject;
            Vector3 newPos = transportObj.transform.position;
            other.transform.position = new Vector3(newPos.x, newPos.y, newPos.z);
        }
    }
}
