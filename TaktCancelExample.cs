using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class TaktCancelExample : MonoBehaviour
{
    CancellationTokenSource m_CancelTokenSource; // ① CancellationTokenSource 클래스 필드에서 선언  
    Task<int> m_Task; 

    void Start() 
    { 
        m_CancelTokenSource = new CancellationTokenSource();  // ② CancellationTokenSource 객체를 생성 
        CancellationToken cancellationToken = m_CancelTokenSource.Token; 
        m_Task = Task.Factory.StartNew((Func<int>) TaskMethod, cancellationToken); 
    } 

    void Update() 
    { 
        if (Input.GetKeyDown(KeyCode.C)) 
        { 
            m_CancelTokenSource.Cancel(); // ④ CancellationTokenSource의 Cancel() 메서드를 호출해 작업 취소 
            if (m_Task != null) 
            { 
                Debug.Log("Count : " + m_Task.Result); //취소 후 태스크 결과인 count출력
            } 
        } 
    } 

    private int TaskMethod() 
    { 
        int count = 0; 
        for (int i = 0; i < 10; i++) //10번 반복, 10초동안 실행이겠네
        { 
            if (m_CancelTokenSource.Token.IsCancellationRequested) // ③ 비동기 작업 메서드 안에서 작업이 취소되었는지를 체크 
            { 
                break; 
            } 

            ++count;
            Thread.Sleep(1000); //1초
            print(count);
        } 
        return count; 
    } 
}
