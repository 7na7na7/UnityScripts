using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YouDoTan : MonoBehaviour
{
    public Transform target;
    public float speed=3;
    void Update()
    {
        Vector3 dir = target.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //tan을 구하기 위해 y/x를 해주는 Atan2함수로 라디안각도를 구하고, 그냥각도로 변환시키면 원하는 오브젝트를 바라보는 회전값이 나온다.
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        
        //transform.Translate(Vector3.right*Time.deltaTime*speed);
    }
}
