using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Func : MonoBehaviour
{
    delegate string MyDelegate<T1,T2>(T1 a, T2 b); 
    delegate void _MyDelegate<T1,T2>(T1 a, T2 b);
    private MyDelegate<int, int> myDelegate;
    
    //반환값 없으면 Action, 있으면 Func 사용
    
    private Action<int, int> myDelegate_2; //이게 string이랑 같고

    private Func<int, int, string> myDelegate_3; //이게 void꺼랑 같
        
   void Start()
   {
       //람다식
       myDelegate_3 = (int a, int b) =>
       { int sum = a + b; return sum + "이 리턴되었습니다."; };

       print(myDelegate_3(3, 5));
   }
}
