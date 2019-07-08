using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 코루틴중단 : MonoBehaviour
{
    private IEnumerator coroutine; //IEnumerator 변수 선언
    
    private int x = 0;//출력할 수 
    
    IEnumerator Start()
    {
        coroutine = number();//IEnumerator 변수에 b()코루틴을 넣음
        StartCoroutine(coroutine);//코루틴 실행
        yield return new WaitForSeconds(10); //10초 후
        StopCoroutine(coroutine);//코루틴 종료
    }

    IEnumerator number()
    {
        while (true)
        {
            Debug.Log(x);
            yield return new WaitForSeconds(1);
            x++;
        }
    }
}
