using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lambda : MonoBehaviour
{
    
    private int a = 5;
    private int b = 5;

    private int sum;

    void Add()
    {
        sum = a + b;
    }

    void Back()
    {
        sum = 0;
    }
/*
    delegate void MyDelegate();

    private MyDelegate myDelegate; //델리게이트 생성
    void Start()
    {
        myDelegate = Add;
        //무명 메소드
        //myDelegate += delegate() { print(sum); }; //델리게이트에 print(sum)이라는 메소드를 바로 넣어버림
        //람다식
        myDelegate += () => print(sum); //위의 코드와 같은 기능의 코드이다. 람다식 최고!
        
        myDelegate += Back;

        myDelegate(); //Add, Back실행
    }
    */

    delegate void MyDelegate<T>(T a, T b);

    private MyDelegate<int> myDel;
    
    private void Start()
    {
        myDel+=(int a, int b)=>print(a+b); //람다식
        myDel += (int b, int c) => print(a - b);
        myDel(3,5); //8과 2가 잘 출력됨
    }
}
