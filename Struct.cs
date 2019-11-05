using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Item
{
    Weapon,
    Shield,
    Potion,
}
public struct minguStruct
{
    public int a; //값 대입 불가
    public int b;
    public int c;
    public int d;

    public minguStruct(int _a, int _b, int _c, int _d) //생성자, 선언과 동시에 초기화를 할 수 있게 해줌
    {
        a = _a;
        b = _b;
        c = _c;
        d = _d;
    }
}
public class Struct : MonoBehaviour
{
    private minguStruct mingu_struct=new minguStruct(1,2,3,4);//생성자로 a, b, c, d초기화
    //구조체는 선언과 동시에 자동으로 초기화됨

    private Item item; //열거형 선언
    void Start()
    {
        mingu_struct.a = 5;
        Debug.Log(mingu_struct.a);
        item = Item.Weapon;
        item = Item.Shield;
        Debug.Log(item); // Shield출력
    }
}
 