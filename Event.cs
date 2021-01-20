using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; //필요
    
public class Event : MonoBehaviour
{
    public UnityEvent startEvent; //이벤트
    void Start()
    {
        startEvent.Invoke(); //startEvent실행, 차례대로 함수들이 실행됨
    }
}
