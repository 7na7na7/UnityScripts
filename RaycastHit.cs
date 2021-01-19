using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastHit : MonoBehaviour
{
    private Vector2 first, second;
    void Start()
    {
        // Physics.BoxCast (레이저를 발사할 위치, 사각형의 각 좌표의 절판 크기, 발사 방향, 충돌 결과, 회전 각도, 최대 거리)
        RaycastHit2D[] hit = Physics2D.BoxCastAll(transform.position,new Vector2(5,5), 0,Vector2.down,0);
        first = transform.position;
        second = new Vector2(5,5);
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(first,second);
    }
}
