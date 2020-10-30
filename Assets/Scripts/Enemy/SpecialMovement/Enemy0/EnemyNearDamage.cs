using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNearDamage : MonoBehaviour
{
    public int damage = 10;
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().GetHurt(damage);
        }
    }
}
