using System.Collections;
using System.Collections.Generic;
using UnityEngine;

https://forum.unity.com/threads/how-to-cancel-and-restart-a-coroutine.435493/

public class 코루틴종료_완전종료재시작 : MonoBehaviour
{
    private Coroutine coroutine;
    

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            StopAndRestartCor();
        }
    }

  void StopAndRestartCor()
    {
        if (coroutine != null)
            StopCoroutine(coroutine);
        coroutine = StartCoroutine(cor());
    }

    IEnumerator cor()
    {
        int i = 0;
        while(true)
        {
            yield return new WaitForSeconds(1f);
            print(i);
            i++;
        }
    }
}
