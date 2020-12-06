using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int monsterLeft=0;
    public int levelState=0;

    private GameObject portal;

    private void Start()
    {
        portal = GameObject.Find("Portal");
    }
    public void EnemyDie()
    {
        monsterLeft--;
        if(monsterLeft==0)
        {
            portal.GetComponent<Portal>().isActive=true;
        }
    }
    public void Die()
    {
        if(levelState==0)
        {
            //TODO
            levelState=1;
            Debug.Log("lose!");
        } 
    }
    public void Win()
    {
        if(levelState==0)
        {
            //TODO
            levelState=2;
            Debug.Log("win!");
        }   
    }
}
