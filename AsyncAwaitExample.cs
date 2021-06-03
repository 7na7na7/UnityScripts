using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncAwaitExample : MonoBehaviour
{
    void Start() 
    { 
        //TaskRun(); 
        TaskFromResult(); 
    } 

    async void TaskRun() //await를 가지고잇다고 알려줌
    { 
        var task = Task.Run(() => TaskRunMethod(3)); 
        await task; //비동기로 해줌
        Debug.Log("Count : " + task.Result); // 출력 : Count : 3, 3초 비동기 실행 후 출력
    } 
    private int TaskRunMethod(int limit) 
    { 
        int count = 0; 
        for (int i = 0; i < limit; i++) 
        { 
            ++count; 
            Thread.Sleep(1000); //1초 대기
        } 

        return count; 
    }
    async void TaskFromResult() 
    { 
        int sum = await Task.FromResult(Add(1, 100)); //이건 비동기아니고 그냥 result구하기
        Debug.Log(sum); // 출력 : 3  
    } 

    private int Add(int a, int b) //a부터 b까지 더하는 함수
    {
        int sum = 0;
        for (int i = a; i <= b; i++)
        {
            sum += i;
        }

        return sum;
    } 
}
