using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpecialMovementBase : MonoBehaviour
{
    //This class describe how enemy move after detecting player.
    public bool detectPlayer = false;

    protected virtual void specialMove()
    {

    }
    private void Update()
    {
        if(detectPlayer)
        {
            specialMove();
        }
    }
}
