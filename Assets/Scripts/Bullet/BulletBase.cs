using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBase : MonoBehaviour
{
    public float speedForward = 5f;
    public float speedUpward = 0f;
    public float forceForward = 0f;
    public float forceUpward = 0f;
    public int damage = 5;
    public int skillType = -1;
    public bool isReady = false;
    protected GameObject skill;
    protected Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = speedForward * transform.forward + speedUpward * transform.up;
        rb.AddForce(forceForward * transform.forward + forceUpward * transform.up);
    }

    public void AttachToSkill(GameObject _skill)
    {
        skill = _skill;
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Wall")
        {
            isReady = true;
            skill.GetComponent<SkillBase>().CheckBulletAreReady();
            rb.velocity = Vector3.zero;
        }
    }
}
