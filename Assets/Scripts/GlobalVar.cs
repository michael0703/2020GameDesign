using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVar : MonoBehaviour
{
    // This class storing gloval var
    public int numOfSkillType = 6;
    public int [] numOfBulletInSkill = {2,1,1,1,1,5};
    public float [] coolOfSkill = {5f,5f,5f,5f,5f,5f};

    // 0: line of slow
    // 1: scarecrow
    // 2: keep exploring
    // 3: shield
    // 4: marking enemy -> AOE
    // 5: take-back
}
