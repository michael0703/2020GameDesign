using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordRound : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 rotateSpeed = new Vector3(0, 100, 0);
    GameObject [] swords = new GameObject[3];
    public GameObject target;
    float timer = 4f;
    int currentSword = 0;
    bool isAttacking = false;
    void Start()
    {
        for(int i=0; i<3; i++){
            swords[i] = gameObject.transform.GetChild(i).gameObject;
            Renderer rend = swords[i].GetComponent<MeshRenderer>();
            rend.enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        if (!isAttacking){
            // let the sword rotate
            for(int i=0 ;i<3; i++){
                swords[i].transform.Rotate(rotateSpeed * Time.deltaTime * 3f);
            }
            timer -= Time.deltaTime;
            transform.Rotate(rotateSpeed * Time.deltaTime);
            if (timer <= 0 && currentSword < 3){
                Renderer rend = swords[currentSword].GetComponent<MeshRenderer>();
                rend.enabled = true;
                currentSword += 1;
                timer = 2f;
            }
            if (currentSword >= 3){
                transform.parent.parent.gameObject.GetComponent<EnemySpecialMovement5>().assignTarget();
                if (target != null){
                    Debug.Log("Attack!!!");
                    isAttacking = true;
                    attack();
                }
                // else if (target == null){
                //     for(int i=0; i<3; i++){
                //         swords[i].GetComponent<SwordMove>().isReadyToDie = true;
                //     }
                // }
            }
        }
        else{

            // check when to destroy itself;
            bool flag = true;
            for(int i=0; i<3; i++){
                if (!swords[i].GetComponent<SwordMove>().isReadyToDie){
                    flag = false;
                }
            }
            // need to modify code, tell enemy parent to destroy, and recreate one instance
            if (flag)  transform.parent.parent.GetComponent<EnemySpecialMovement5>().DestroySwordRound = true;
        }
    }

    public void attack(){
        for(int i=0; i<3; i++){
            Vector3 direction = swords[i].transform.position - target.transform.position;
            
            swords[i].transform.up = -1f * direction;
            swords[i].GetComponent<SwordMove>().isAttacking = true;

        }
        
    }

}
