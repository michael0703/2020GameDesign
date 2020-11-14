using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashDetect : MonoBehaviour
{
    public float Dash(float dashMax, Vector3 direction){
        int layerMask = 1 << 8;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direction, out hit, dashMax, layerMask))
        {
            return hit.distance;
        }
        else
        {
            return dashMax;
        }

    }
}
