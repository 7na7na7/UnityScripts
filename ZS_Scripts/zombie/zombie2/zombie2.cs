using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class zombie2 : zombieclass
{
    private GameObject parent;

    private void Start()
    {
        parent = transform.parent.gameObject;
        if(level.currentzombie>level.zombiecount[level.i])
            Destroy(parent);
        else
            level.currentzombie++;
    }

    private void LateUpdate()
    {
        if (hp.transform.localScale.x <= 0)
        {
            Destroy(parent);
        }
    }
}
