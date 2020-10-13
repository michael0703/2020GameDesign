using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //This class describe how a bullet is created.
    public float shootingTime = 0.1f;
    public float shootingTimeSp = 0.1f;
    public GameObject normalBulletPrefab;
    public GameObject [] specialBulletPrefab;
    public int index = 0;

    private int [] ids;
    private float timeCounting;
    private float timeCountingSp;
    private GameObject bulletManager;
    private GameObject myGrandParent;
    void Start()
    {
        int numOfBullet = GameObject.Find("GlobalVar").GetComponent<GlobalVar>().numOfBullet;
        ids = new int [numOfBullet]; 
        for(int i=0; i<numOfBullet; i++)
            ids[i]=0;
        timeCounting = 0;
        timeCountingSp = 0;
        bulletManager = GameObject.Find("BulletManager");
        //gameObject:Gun
        GameObject myParent = transform.parent.gameObject;
        //gameObject:MainCamera
        myGrandParent = myParent.transform.parent.gameObject;
    }
    void Update()
    {
        timeCounting -= Time.deltaTime;
        timeCountingSp -= Time.deltaTime;
        
        // special bullet
        if(Input.GetMouseButtonDown(1) && timeCountingSp<=0)
        {
            GameObject specialBullet = (GameObject)Instantiate(specialBulletPrefab[index],transform.position,myGrandParent.transform.rotation);
            specialBullet.GetComponent<BulletBase>().index = index;
            specialBullet.GetComponent<BulletBase>().id = ids[index];
            ids[index]++;
            bulletManager.GetComponent<BulletManager>().RegistBullet(index,specialBullet);
            timeCountingSp = shootingTimeSp;
        }

        // normal bullet
        if(Input.GetMouseButtonDown(0) && timeCounting<=0)
        {
            Instantiate(normalBulletPrefab,transform.position,myGrandParent.transform.rotation);
            timeCounting = shootingTime;
        }

        // change special bullet
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            index = 0;
        }
        if(Input.GetKeyDown(KeyCode.Alpha2))
        {
            index = 1;
        }
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            index = 2;
        }
        if(Input.GetKeyDown(KeyCode.Alpha4))
        {
            index = 3;
        }
        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            index = 4;
        }
        if(Input.GetKeyDown(KeyCode.Alpha6))
        {
            index = 5;
        }
        
    }
}
