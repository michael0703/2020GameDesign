using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingsEnemiesActivator : MonoBehaviour
{

    static private GameObject buildings;
    static private GameObject enemies;

    private void Start()
    {
        buildings = GameObject.Find("===Buildings===");
        enemies = GameObject.Find("===Enemys===");
        setEnvironment(0);

    }

    public static void setEnvironment(int index)
    {
        for(int i = 0; i < 4; i++)
        {
            if (i == index|| i == index + 1)
            {
                buildings.transform.GetChild(i).gameObject.SetActive(true);
                enemies.transform.GetChild(i).gameObject.SetActive(true);

            }
            else
            {
                buildings.transform.GetChild(i).gameObject.SetActive(false);
                enemies.transform.GetChild(i).gameObject.SetActive(false);
            }


        }


    }



}
