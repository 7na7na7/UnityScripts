using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person
{
    public int age { get; set; }
}
public class nullüũ�����ϰ� : MonoBehaviour
{
    Person person = new Person();
    void Start()
    {
        //person.age = 3;
        print(person?.age.ToString() ?? "��� �̸��� �����!");


        /*���� 1���� �̰Ŷ� ����...
        if (person != null)
        {
            if (person.age != 0)
                print(person.age.ToString());
            else
                print("��� �̸��� �����!");
        }
        else
            print("��� �̸��� �����!");
        */
    }
}
