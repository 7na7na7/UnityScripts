using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Student : Human
{
    private string schoolName;
    void Start()
    {
        schoolName = "대마고";
        humanName = "민구";
        humanAge = 17;
        Info(); //"나는 인간입니다" 출력
    }

    protected override void Info()
    {
        base.Info(); //base는 부모 클래스, Human을 가리킴. 즉, Human.Info(); 인 셈이다.
        Debug.Log("나는 학생입니다.");
        //"나는 인간입니다", "나는 학생입니다" 두 가지가 모두 출력됨
    }

    protected override void Name() //추상 함수를 안만들면 오류가 나므로 반드시 만들어야 함
    {
        Debug.Log(humanName);
    }
}
