using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombArea : MonoBehaviour
{
    public int damage = 5;
    private bool if_ = false;
    private float et = 0;
    private float sa = 1f;

    public void Activate(bool isFreeze, float effectTime, float slowArgument)
    {
        //GetComponent<MeshRenderer>().enabled = true
        GetComponent<SphereCollider>().enabled = true;
        if_ = isFreeze;
        et = effectTime;
        sa = slowArgument;
    }
    public void Deactivate()
    {
        //GetComponent<MeshRenderer>().enabled = false;
        GetComponent<SphereCollider>().enabled = false;
        if_ = false;
        et = 0;
        sa = 1;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().GetHurt(damage);
            if(if_)
            {
                other.gameObject.GetComponent<EnemyState>().SlowDown(et,sa);
            }
        }
    }
}
