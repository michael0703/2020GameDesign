using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject ExplosionEffectPrefab;
    public int damage = 5;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Explode(5));

    }


    public IEnumerator Explode(int times)
    {
        for (int i = 0; i < times; i++)
        {
            GameObject explosionEffect=Instantiate(ExplosionEffectPrefab, transform.position, transform.rotation);
            Destroy(explosionEffect, 0.5f);


            Collider[] colliders=Physics.OverlapSphere(transform.position, 5);
            foreach(Collider collider in colliders)
            {
                if (collider.gameObject.tag == "Enemy")
                {

                    //Debug.Log("damage by explosion.");
                    collider.GetComponent<EnemyHealth>().GetHurt(damage);

                    if (collider.GetComponent<EnemyState>().isMovable)
                    {
                        //Debug.Log("move");
                        Vector3 blownDirection = collider.transform.position - transform.position;
                        collider.GetComponent<Rigidbody>().AddForce(blownDirection.normalized * 300);
                    }


                };

            }


            yield return new WaitForSeconds(0.5f);
        }
        Destroy(gameObject);


    }
}
