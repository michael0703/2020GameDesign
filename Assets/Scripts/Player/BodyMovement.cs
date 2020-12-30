using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyMovement : MonoBehaviour
{
    //This class move whole player
    public float speed = 5f;
    public bool isGrounded = true;
    public float jumpForce = 5f;
    public float dashSpeedFactor = 5f;
    public float dashTime = 0.2f;
    public float dashCooling = 2f;

    private Rigidbody rb;
    private bool isDash = false;
    private float dashCount;
    private float dashCoolCount;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = (transform.right * x + transform.forward * z).normalized;
        float limit = transform.GetChild(3).gameObject.GetComponent<DashDetect>().Dash(speed * Time.deltaTime, direction);

        if (limit < speed * Time.deltaTime)
        {
            rb.MovePosition(transform.position + direction *limit);

        }
        else
        {
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
        // Vector3 movement = (transform.right * x + transform.forward * z) * speed;      
        // movement.y = rb.velocity.y;
        // rb.velocity = movement;

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Vector3 jump = new Vector3(0, jumpForce, 0);
            rb.AddForce(jump, ForceMode.Impulse);
        }

        dashCoolCount -= Time.deltaTime;
        if(Input.GetKeyDown(KeyCode.LeftShift) && dashCoolCount<=0)
        {
            float length = transform.GetChild(3).gameObject.GetComponent<DashDetect>().Dash(speed*dashSpeedFactor*dashTime, direction);
            //rb.MovePosition(transform.position + direction * length);
            if(length!=0 && direction!=Vector3.zero)
            {
                isDash = true;
                dashCoolCount = dashCooling;
                dashCount = length/(speed*dashSpeedFactor);
                speed *= dashSpeedFactor;
            }
        }
        if(isDash)
        {
            dashCount -= Time.deltaTime;
            if(dashCount<=0)
            {
                isDash = false;
                speed /= dashSpeedFactor;
            }
        }
        

    }
    
	
}
