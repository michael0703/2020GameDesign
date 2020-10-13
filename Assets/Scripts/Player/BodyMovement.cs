using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    //This class describe how player move
    public float speed = 5f;
    public bool isGrounded = true;
    public float jumpForce = 5f;
    public float jumpDetect = 0.1f;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        float x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        float z = Input.GetAxis("Vertical") * speed * Time.deltaTime;

        Vector3 movement = (transform.right * x + transform.forward * z) ;
        rb.MovePosition(transform.position + movement);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector3 jump = new Vector3(0, jumpForce, 0);
            rb.AddForce(jump, ForceMode.Impulse);
        }
    }
    
	
}
