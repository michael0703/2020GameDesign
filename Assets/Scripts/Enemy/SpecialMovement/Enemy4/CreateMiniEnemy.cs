using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMiniEnemy : MonoBehaviour
{
    public int numOfMini = 5;
    public GameObject miniEnemyPrefab;

    private GameObject [] miniEnemyList;
    void Start()
    {
        miniEnemyList = new GameObject[numOfMini];
        for(int i=0; i<numOfMini; i++)
        {
            Vector3 v = new Vector3(Random.Range(-1.5f, 1.5f), Random.Range(0f, 3f), Random.Range(-1.5f, 1.5f));
            v += gameObject.transform.position;
            miniEnemyList[i] = (GameObject)Instantiate(miniEnemyPrefab, v, Quaternion.identity);
            miniEnemyList[i].transform.parent = gameObject.transform;
        }
    }

    public void CountLeft()
    {
        int count=0;
        for(int i=0; i<numOfMini; i++)
        {
            if(miniEnemyList[i]!=null) count++;
        }
        if(count==1)
            Destroy(gameObject);
    }
}
