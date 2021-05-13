using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 날짜시간 : MonoBehaviour
{
    void Update()
    {
        var date = DateTime.Now; 
        print(string.Format("Today is {0}, it's {1:HH:mm} now.", date.DayOfWeek, date));
    }
}
