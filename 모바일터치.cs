using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 모바일터치 : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Debug.Log("터치 시작! : " + touch.position);
            }
            if (touch.phase == TouchPhase.Moved)
            {
                Debug.Log("터치 중! : " + touch.position);
            }
            if (touch.phase == TouchPhase.Ended)
            {
                Debug.Log("터치 끝! : " + touch.position);
            }
        }
    }
}
