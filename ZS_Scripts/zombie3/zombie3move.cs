using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie3move : MonoBehaviour
{
    public float speedup = 3.0f;
    private Transform target; // 따라갈 물체의 방향
    public float speed = 1.0f;
    
    void Update()
    {
        Move1 player = GameObject.Find("player").GetComponent<Move1>();
        target = player.transform;
        Vector3 dir = target.position - transform.position; //사이의 거리를 구함
        transform.position +=
            new Vector3(Mathf.Clamp(dir.x, speed * -1, speed), Mathf.Clamp(dir.y, speed * -1, speed), dir.z) * speed *
            Time.deltaTime;
    }

}
