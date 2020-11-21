using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject hitEffectPrefab;
    void Start()
    {
        
    }
    void OnTriggerEnter(Collider other){

        // only let bullet0 and bullet5 pass through
        bool bulletPassThrough = canBulletPassThrough(other.gameObject);
        bool isBullet = isObjectBullet(other.gameObject);
        if(isBullet){
            Debug.Log(other.gameObject.tag + " " + bulletPassThrough + " ");
        }
        if(!bulletPassThrough && isBullet){
            Debug.Log("Bullet hit");
            Vector3 initPos = transform.position;
            Vector3 FinalPos = new Vector3(initPos.x +0.2f+ Random.Range(-0.10f, 0.10f) , initPos.y + Random.Range(-0.10f, 0.10f), initPos.z + 0.6f);

            GameObject hitEffect = (GameObject)Instantiate(hitEffectPrefab, FinalPos, Quaternion.identity);
            GameObject.Destroy(other.gameObject);
        }



    }
    bool isObjectBullet(GameObject collideObject){
        if (collideObject.tag == "NormalBullet" || collideObject.tag == "SkillBullet"){
            return true;
        }
        else return false;
    }
    bool canBulletPassThrough(GameObject bullet){

        if (bullet.gameObject.GetComponent<SpecialBullet5>() || bullet.gameObject.GetComponent<SpecialBullet0>()){
            return true;
        }
        return false;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
