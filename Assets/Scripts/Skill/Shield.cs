using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{

    private float timeRemaining = 3f;
    void Update()
    {
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "EnemyBullet")
        {
            //collision.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            //makeshift collision result before we know all enemy bullet type.
            Destroy(other.gameObject);
        }
    }
}
