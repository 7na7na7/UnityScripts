using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ref사용법 : MonoBehaviour
{
    void Start()
    {
        int a = 1;
        int b = 2;
        print(a + " " + b);
        swap(ref a, ref b);
        print(a + " " + b);
    }

    void swap(ref int q, ref int w)
    {
        int temp = q;
        q = w;
        w = temp;
    }
}
