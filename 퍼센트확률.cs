using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 퍼센트확률 : MonoBehaviour
{
    public void PercentReturn(int percent)
    {
        int r = Random.Range(0, 100);
        bool[] bools=new bool[100];
        for (int i = 0; i < 100; i++)
        {
            if (i < percent)
                bools[i] = true;
            else
                bools[i] = false;
        }
        if (bools[r]==true)
            print(percent+"퍼센트의 확률 성공!");
        else
            print(percent+"퍼센트의 확률 실패...");
    }
}
