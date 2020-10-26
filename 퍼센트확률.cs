using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 퍼센트확률 : MonoBehaviour
{
    public void PercentReturn(int percent)
    {
        if(Random.Range(1,101)<=percent)
            print(percent+"퍼센트의 확률 성공!");
        else
            print(percent+"퍼센트의 확률 실패...");
    }
}
