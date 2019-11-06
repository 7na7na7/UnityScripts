using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exception : MonoBehaviour
{
    private int a = 5;
    private int b = 0;
    private int c;
    void Start()
    {
        try
        {
            c = a / b; //0으로 나누려고 하면 오류가 발생함
        }
        catch (System.Exception e) //오류 잡아줌, 여기서는 DivideByZeroException
        {
            print(e); //오류 출력
            b = 1; //나눌 값을 1로 해 주고,
            c = a / b; //다시 나눠 줌
        }
        finally //코드에 오류가 나든 나지 않든 마지막에 무조건 실행되는 코드
        {
            print(c); //무조건 출력됨
        }
        
        throw new System.Exception("일부러 오류를 발생시킴!"); //오류 발생시킴
    }
}
