using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public float speed_forward = 5f;
    public float speed_upward = 0f;
    public float force_forward = 0f;
    public float force_upward = 0f;
    public int damage = 5;
    public int index = -1;
    public int id;

    protected Rigidbody rb;
    protected GameObject bulletManager;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = speed_forward * transform.forward + speed_upward * transform.up;
        rb.AddForce(force_forward * transform.forward + force_upward * transform.up);
        bulletManager = GameObject.Find("BulletManager");
    }

    protected GameObject [] GetBullets(int num)
    {
        return bulletManager.GetComponent<BulletManager>().GetBullets(index, num);
    }
}
