using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBulletTest : BulletBase
{
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag=="Wall")
        {
            GameObject [] bl = GetBullets(1);
            Debug.Log(bl[0].GetComponent<BulletBase>().id);
            Destroy(gameObject);
        }
    }
}
