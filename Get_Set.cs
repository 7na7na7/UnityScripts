using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Get_Set : MonoBehaviour
{
    //이렇게 쓴다 ㅎㅎ
    private int age;
    public int Age
    {
        get { return age; }
        set
        {
            if (value < 20)
            {
                print("20세 미만은 사용 불가합니다.");
            }
            else
            {
                age = value; AgeChanged();

            }
        }
    }
    void Start()
    {
        Age = 10; // value is under 20 so assign value is fail.
        Age = 25; // value is over 20 so assign value is success.
    }

    void AgeChanged() { print("나이가 변경되었습니다."); }
}
