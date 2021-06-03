using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Threading.Tasks; //이거 잇어야 댄다!
public class TaskExample : MonoBehaviour
{
    void Start() 
    {
        //Task를 사용하는 방법은 직접 호출, Action 대리자 사용, 대리자, 람다식, 람다와 익명 메서드 등이 있습니다.
            
        Task.Factory.StartNew(() => { Debug.Log("Task"); }); // 1: 직접 호출, 스레드 생성과 시작 
        
        Task task2 = new Task(new Action(DebugLog)); // 2: Action 대리자 
        task2.Start(); 

        Task task3 = new Task(delegate { DebugLog(); });  // 3: 대리자 
        task3.Start(); 

        Task task4 = new Task(() => DebugLog()); // 4: 람다식 
        task4.Start(); 

        Task task5 = new Task(() => { DebugLog(); }); // 5: 람다와 익명 메서드 
        task5.Start();

        //제네릭을 사용하면 Result로 반환값을 받을 수 있다.
        Task<int> returntask = Task.Factory.StartNew<int>(() => GetSize("GenericTask")); 
        int result = returntask.Result; 
        Debug.Log(result); // 출력 : 11 


        task2.Wait(); // Task가 끝날 때까지 대기  
        task3.Wait(); // Task가 끝날 때까지 대기 
        task4.Wait(); // Task가 끝날 때까지 대기 
        task4.Wait(); // Task가 끝날 때까지 대기 
       
    } 
    int GetSize(string data) 
    { 
        return data.Length; 
    }
    void DebugLog() 
    { 
        Debug.Log("Task"); 
    } 
}
