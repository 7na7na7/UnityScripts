using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Human : MonoBehaviour //abstract를 사용하기 위해서 추상 클래스로 변환시킴
{ 
    //인간 클래스의 이름과 나이를 선언함
    protected string humanName; //protected를 사용하면 상속받은 자식 클래스만 사용할 수 있게 됨
    protected int humanAge;

    protected virtual void Info() //virtual을 이용하여 가상 함수로 만듬
    //가상 함수를 사용하면 override를 사용하여 재정의할 수 있게 된다.
    {
        Debug.Log("나는 인간입니다.");
    }

    abstract protected void Name(); //abstract를 이용하여 추상 함수로 만듬
    //추상 함수를 사용하면 일단 함수를 정의해 놓고, 자식 클래스가 함수를 만들도록 함.
    //Name 함수를 만들지 않을 경우, 오류가 발생함
}
