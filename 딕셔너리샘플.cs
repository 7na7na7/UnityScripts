using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Man
{
    private string name;
    private int age;
    private bool isMale;

    public Man(string _name, int _age, bool _isMale)
    {
        name = _name;
        age = _age;
        isMale = _isMale;
    }

    public void ShowData()
    {
        Debug.Log("제 이름은 " + name + "이고, 나이는 " + age + "살인 " + (isMale ? "남자입니다.":"여자입니다."));
    }
}
public class 딕셔너리샘플 : MonoBehaviour 
{
    void Start()
    {
        Dictionary<int, Man> people = new Dictionary<int, Man>();

        string name;

        name = "민구";
        people.Add(0, new Man(name, 19, true));

        name = "서영";
        people.Add(1, new Man(name, 19, false));

        name = "짱구";
        people.Add(2, new Man(name, 5, true));

      for(int i=0;i<people.Count;i++)
        {
            people[i].ShowData();
        }
    }
}
