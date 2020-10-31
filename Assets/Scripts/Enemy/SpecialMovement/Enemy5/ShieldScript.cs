using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other){

        // only consider if bullet hits
        string tag = other.gameObject.tag;
        if(tag == "NormalBullet" || tag == "SkillBullet"){
            Debug.Log("Bullet Type" + other.gameObject.GetComponent<BulletBase>().skillType);
            other.gameObject.GetComponent<BulletBase>().speedForward = 0f;

        }



    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
