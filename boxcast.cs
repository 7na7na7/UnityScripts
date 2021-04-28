using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxcast : MonoBehaviour
{
    void OnDrawGizmos() {

        float maxDistance = 10;
        RaycastHit hit;
        // Physics.BoxCast (레이저를 발사할 위치, 사각형의 각 좌표의 절반 크기, 발사 방향, 충돌 결과, 회전 각도, 최대 거리)
        bool isHit = Physics.BoxCast (transform.position, transform.lossyScale / 2, transform.right, out hit, transform.rotation, maxDistance);

        Gizmos.color = Color.red;
        if (isHit) {
            Gizmos.DrawRay (transform.position, transform.right * hit.distance);
            Gizmos.DrawWireCube (transform.position + transform.right * hit.distance, transform.lossyScale );
        } else {
            Gizmos.DrawRay (transform.position, transform.right * maxDistance);
        }
    }
}
