using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 배열 : MonoBehaviour
{
    int[] num = new int[5]; 

    void Start()
    {
        num [0] = 1; 
        num [1] = 2; 
        num [2] = 3; 
        num [3] = 4; 
        num [4] = 5;
    }
    //위는 스크립트 내에서 배열에 할당하는 방식,
    public int[] array; //그러나 이렇게 public 으로 배열을 할당받을 수도 있다.
    for (i = 0; i < array.Length; i++)
    {
        array[i] = 0;
    }
    //.Length를 사용하면 배열의 길이를 구할 수 있다. 이것으로 반복문을 돌릴 수 있다.
}
