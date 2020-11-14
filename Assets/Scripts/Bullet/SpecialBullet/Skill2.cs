using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2 : SkillBase
{
    public enum explosiontype
    {
        superExplosion,
        explosion,
    }
    private explosiontype type;
    public GameObject superExplosionPrefab;
    public GameObject explosionPrefab;
    protected override void ActivateSkill()
    {
        if (type == explosiontype.explosion)
        {
            Instantiate(explosionPrefab, bullets[0].transform.position, bullets[0].transform.rotation);
        }else if(type == explosiontype.superExplosion)
        {
            Instantiate(superExplosionPrefab, bullets[0].transform.position, bullets[0].transform.rotation);
        }
        DestroySkill();
    }
    public void setType(explosiontype type)
    {

        this.type = type;

    }

}
