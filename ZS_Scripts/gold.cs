using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gold : MonoBehaviour
{
    private Transform target;
    private Move1 player;
    private bool ismagnet = false;
    private GameObject obj;
    private void Start()
    {
        player = FindObjectOfType<Move1>();
        obj = this.gameObject;
        Destroy(this.gameObject,25f);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GoldManager gold = FindObjectOfType<GoldManager>();
            gold.gold++;
            Destroy(obj);
        }
        if (other.CompareTag("magnet"))
        {
            ismagnet = true;
        }
    }

    private void Update()
    {
        if (ismagnet)
        {
            target = player.transform;
            Vector3 dir = target.position - transform.position; //사이의 거리를 구함
            //dir.Normalize();
            transform.position +=
                dir* player.goldspeed *
                Time.deltaTime;
        }
    }
}
