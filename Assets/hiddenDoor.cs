using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hiddenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Vector3 hiddenRoom=new Vector3(12f,1f,-17f);
            other.transform.position = hiddenRoom;
        }
    }
}
