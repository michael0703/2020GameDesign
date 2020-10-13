using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    private GameObject grandParent;
    void Start()
    {
        grandParent = transform.parent.gameObject.transform.parent.gameObject;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Wall")
        {
            grandParent.GetComponent<BodyMovement>().isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Wall")
        {
            grandParent.GetComponent<BodyMovement>().isGrounded = false;
        }
    }
}
