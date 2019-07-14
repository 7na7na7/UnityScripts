using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 유도탄 : MonoBehaviour
{
    public Transform target; //총알이 따라갈 물체의 방향
    public float speed = 1.0f; //총알의 속도
    void Update()
    {
        Vector3 dir = target.position - transform.position; //사이의 거리를 구함
        
        // 타겟 방향으로 다가감
        transform.position += dir * speed * Time.deltaTime; //구한 거리를 더하여 해당 물체까지 이동
        
        // 타겟 방향으로 회전함
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}
