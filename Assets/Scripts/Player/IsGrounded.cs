using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGrounded : MonoBehaviour
{
    // This class detect ground
    private GameObject player;
    void Start()
    {
        player = transform.parent.gameObject;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag=="Floor")
        {
            player.GetComponent<BodyMovement>().isGrounded = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag=="Floor")
        {
            player.GetComponent<BodyMovement>().isGrounded = false;
        }
    }
}
