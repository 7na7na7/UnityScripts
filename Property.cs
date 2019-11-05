using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Property : MonoBehaviour
{
    private int mingu;
    private int bonus = 10;
    
    public int Mingu
    {
        //프로퍼티
        get { return mingu+bonus; } private set { if (value < 0) mingu = 10;else mingu = value; } 
        //반드시 value라고 써넣어 줘야 함
        //만약 value가 0보다 작다면 그냥 mingu를 10으로 함
        //private set으로 하여 get은 할 수 있지만, set은 함부로 할 수 없게 만듬 
    }

    public int Bonus { get; set; }
    //가장 단순한 프로퍼티, 이거 자체가 변수의 기능 가능

    void Start()
    {
        mingu = -5;
    }
}
