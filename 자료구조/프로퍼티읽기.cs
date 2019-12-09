using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 프로퍼티읽기 : MonoBehaviour
{
  Property myprop=new Property();
    void Start()
    {
        //myprop.Mingu = 10; //프로퍼티 때문에 값 변경 불가능
        print(myprop.Mingu); //읽을 수는 있음!
    }
}
