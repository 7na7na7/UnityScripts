using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
    public int age { get; set; }
}
public class null체크간편하게 : MonoBehaviour
{
    Person person = new Person();
    void Start()
    {
        //person.age = 3;
        print(person?.age.ToString() ?? "사람 이름이 없어요!");


        /*위의 1줄이 이거랑 같다...
        if (person != null)
        {
            if (person.age != 0)
                print(person.age.ToString());
            else
                print("사람 이름이 없어요!");
        }
        else
            print("사람 이름이 없어요!");
        */
    }
}
