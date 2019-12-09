using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 타겟따라가기 : MonoBehaviour
{
    public Transform tar;
    private Vector3 dir;
    public float speed = 5;
    
    void Update()
    {
        dir = tar.position - this.transform.position;
        dir.Normalize();
        transform.Translate(dir*speed*Time.deltaTime);
    }
}
