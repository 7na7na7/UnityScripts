using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deleScript : MonoBehaviour
{
    public delegate void ChainFunction(int value); //델리게이트 함수 생성됨
    //private ChainFunction chain; //이벤트로 선언했으므로 필요없음

    public static event ChainFunction OnStart; //델리게이트 ChainFunction의 이벤트 객체 OnStart 선언
    
    private int power;
    private int defense;

    public void SetPower(int value)
    {
        power += value;
        print("power의 값이 "+value+"만큼 증가했습니다. 총 power의 값: "+power);
    }

    public void SetDefense(int value)
    {
        defense += value;
        print("defense의 값이 "+value+"만큼 증가했습니다. 총 defense의 값: "+defense);
    }
    void Start()
    {
        OnStart += SetPower; //델리게이트 함수 객체 chain에 SetPower함수를 넣음
        OnStart += SetDefense; //이 함수도 넣음

        //Onstart -= SetPower; //델리게이트에서 SetPower를 뺌
    }

    private void OnDisable() //게임이 꺼지거나 객체가 비활성화되면 실행되는 함수
    {
        if(OnStart!=null) 
            OnStart(5); //SetPower, SetDefence, 그리고 eventScript의 Abc함수가 모두 5의 매개변수로 실행됨
    }
}
