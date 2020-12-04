using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootHint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 tmp = transform.position;
        tmp.y = 0f;
        transform.position = tmp;

        transform.rotation = Quaternion.identity;
    }
}
