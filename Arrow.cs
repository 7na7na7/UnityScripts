using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    //화살에 들어가는 스크립트
    private void Start()
    {
        Destroy(gameObject,10.0f);
    }

    void Update()
    {
        transform.right = GetComponent<Rigidbody2D>().velocity; 
        //속도와 방향을 모두 가지고 있는 velocity를 transform.right에 넣어 주어 각도도 변하게 함
    }
}
