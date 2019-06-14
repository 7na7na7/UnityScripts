using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BGmove : MonoBehaviour
{
    public float speed = 1.0f;
    public float startposition;
    public float endPosition;
    void Update()
    {
        // x포지션을 조금씩 이동
        transform.Translate(speed * Time.deltaTime, 0, 0);

        // 목표 지점에 도달했다면
        if(speed<0)
        {
            if (transform.position.x <= endPosition)
                transform.position = new Vector2(startposition, transform.position.y);///
        }
        else
        {
            if (transform.position.x >= endPosition)
                transform.position = new Vector2(startposition, transform.position.y);///
        }
        
    }
}
