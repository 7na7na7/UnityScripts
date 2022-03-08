using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 소수점2번째자리까지남기기 : MonoBehaviour
{
    void Start()
    {
        float f = 123.123f;
        print(f.ToString("F1")); //123.1
        print(f.ToString("F2")); //123.12
        print(f.ToString("F3")); //123.123
    }

}
