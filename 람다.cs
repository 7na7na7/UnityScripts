using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyClass
{
    public int classIndex;
    public string className;
}
public class 람다 : MonoBehaviour
{
  
    private List<MyClass> myClasses=new List<MyClass>();
    private bool boooool = false;
    //Let's study lambda!
    void Start()
    {
        MyClass m1=new MyClass();
        m1.classIndex = 1;
        m1.className = "첫번째";
        MyClass m2=new MyClass();
        m1.classIndex = 2;
        m1.className = "두번째";
        myClasses.Add(m1);
        myClasses.Add(m2);
        
        MyClass mc = myClasses.Find((delegate(MyClass m) { return m.classIndex == 2; })); //리스트에서 인덱스가 2인 친구 반환
        print(mc.className); //두번째 출력!
    }

    IEnumerator wait()
    {
        yield return new WaitUntil(func); //boooool이 true가 될때까지 기다림
        yield return new WaitUntil(()=>boooool); //위에거랑 같음! 람다식이 더 편함
    }

    bool func()
    {
        return boooool;
    }
}
