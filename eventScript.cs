using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eventScript : MonoBehaviour
{ 
    void Start()
    {
        deleScript.OnStart += Abc; 
        //deleScript의 이벤트 객체 Onstart에 Abc함수를 넣음, 서로 다른 클래스지만 이렇게 묶을 수 있음
   }

    public void Abc(int value)
    {
        print(value + "값이 증가했습니다.");
    }
}
