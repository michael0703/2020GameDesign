using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    // This class stores data of all bullet in the scene.
    
    private Queue<GameObject> [] bulletList; 
    private int numOfBullet;
    private int [] numOfMaxBullet;

    public GameObject [] GetBullets(int index, int num)
    {
        GameObject [] bullets = new GameObject [num];
        for(int i=0; i<num; i++)
        {
            bullets[i] = bulletList[index].Dequeue();
        }
        return bullets;
    }
    public void RegistBullet(int index, GameObject bullet)
    {
        bulletList[index].Enqueue(bullet);
        while(bulletList[index].Count > numOfMaxBullet[index])
        {
            bulletList[index].Dequeue();
        }
    }

    void Start()
    {
        numOfBullet = GameObject.Find("GlobalVar").GetComponent<GlobalVar>().numOfBullet;
        numOfMaxBullet = GameObject.Find("GlobalVar").GetComponent<GlobalVar>().numOfMaxBullet;

        bulletList = new Queue<GameObject>[numOfBullet];
        for(int i=0; i<numOfBullet; i++)
        {
            bulletList[i] = new Queue<GameObject>();
        }
    }
}
