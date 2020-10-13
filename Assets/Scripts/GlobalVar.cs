﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalVar : MonoBehaviour
{
    public int numOfBullet = 6;
    public int [] numOfMaxBullet = {2,1,1,1,1,5};

    // 0: line of slow
    // 1: scarecrow
    // 2: keep exploring
    // 3: shield
    // 4: marking enemy -> AOE
    // 5: take-back
}
