using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummyzombie : zombieclass
{
    private GameObject obj;
    private Transform target;

    private void Start()
    {
        obj = this.gameObject;
    }

    void Update()
    {
        target = player.transform;
        Vector3 dir = target.position - transform.position; //사이의 거리를 구함
        dir.Normalize();
        transform.position +=
            dir* speed *
            Time.deltaTime;
        if (hp.transform.localScale.x <=0)
        {
            Destroy(obj);
        }
    }

}
