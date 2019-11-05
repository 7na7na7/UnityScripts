using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abc<T,S> //어떤 자료형을 받을지 모를 클래스, 2개를 넘겨줄 수도 있다.
{
    public T var;
    public S[] array;
}

public class Parameter_T : MonoBehaviour
{
    void Print<T>(T value) where T : struct //where T : 형 을 사용하면 해당 형이 아니면 쓸 수 없다.
    {
        print(value);
    }

    private Abc<string,int> a; //Abc클래스에 string자료형을 넘겨줌
    //private Abc<float, double> b; //이렇게 자료형이 다른 클래스를 만들어 줄 수도 있다.
    void Start()
    {
        //Print<string>("abc"); //string형으로 abc매개변수를 넘겨줌
        //string은 struct형이 아니므로 못씀
        
        Print<float>(3.5f); //float형으로 3.5f매개변수를 넘겨줌
        //float은 struct형이므로 쓸수있음

        a.var = "abc"; //string
        a.array = new int[3]; //int[]
    }
}
