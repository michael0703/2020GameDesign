using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillBase : MonoBehaviour
{
    public GameObject [] bullets;
    public int skillType = -1;
    private int numOfBulletInSkill;
    private int currentNumOfBullet = 0;

    public void ResetSkill(int num)
    {
        numOfBulletInSkill = num;
        bullets = new GameObject[numOfBulletInSkill];
    }

    public bool AddBullet(GameObject bullet)
    {
        bullets[currentNumOfBullet] = bullet;
        bullets[currentNumOfBullet].GetComponent<BulletBase>().AttachToSkill(gameObject);
        currentNumOfBullet++;
        if(currentNumOfBullet==numOfBulletInSkill)
        {
            return true;
        }
        return false;
    }

    public void DestroySkill()
    {
        for(int i=0; i<numOfBulletInSkill; i++)
        {
            Destroy(bullets[i]);
        }
        Destroy(gameObject);
    }
    public void CheckBulletAreReady()
    {
        bool flag = true;
        for(int i=0; i<numOfBulletInSkill; i++)
        {
            if(bullets[i]==null || !bullets[i].GetComponent<BulletBase>().isReady)
            {
                flag = false;
                break;
            }
        }
        if(flag)
        {
            ActivateSkill();
            // DestroySkill();
        }
    }
    protected virtual void ActivateSkill()
    {
        Debug.Log("No Skill!");   
    }
}
