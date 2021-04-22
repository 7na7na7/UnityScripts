using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 특정방향바라보기_선형보간 : MonoBehaviour
{
    private void Update()
    {
        Turn();
    }

    void Turn()
    {
        Vector3 relativePos = (transform.position + Vector3.right) - transform.position;
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime*10);
        
        //transform.LookAt(transform.position + Vector3.right); 을 선형보간으로 구현했다!
    }
}
