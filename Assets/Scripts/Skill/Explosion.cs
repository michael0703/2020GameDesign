using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject ExplosionEffectPrefab;
    public int damage = 5;
    public int radius = 5;

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


            Collider[] colliders=Physics.OverlapSphere(transform.position, radius);
            foreach(Collider collider in colliders)
            {
                if (collider.gameObject.tag == "Enemy")
                {

                    Vector3 direction=(collider.transform.position - transform.position);


                    int layerMask = 1 << 8;
                    RaycastHit hit;
                    if (Physics.Raycast(transform.position-direction.normalized*0.5f, direction, out hit, direction.magnitude, layerMask))
                    {
                        //blocked by wall.
                    }
                    else
                    {
                        Debug.Log("hit");
                        //Debug.Log("damage by explosion.");
                        collider.GetComponent<EnemyHealth>().GetHurt(damage);

                        if (collider.GetComponent<EnemyState>().isMovable)
                        {
                            //Debug.Log("move");
                            collider.GetComponent<Rigidbody>().AddForce(direction.normalized * 900);
                        }
                    }


                };

            }


            yield return new WaitForSeconds(0.5f);
        }
        Destroy(gameObject);


    }
}
