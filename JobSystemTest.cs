using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Unity.Collections;
using UnityEngine;
using Unity.Jobs; //여기 들어있다
using Unity.Collections; //nativearray들어잇다
public class JobSystemTest : MonoBehaviour
{
    //https://blog.naver.com/cdw0424/221593451377 
    //잘 기억이 안나면 여기를 보고 다시 공부하자!
    
    private NativeArray<int> A;
    private NativeArray<int> B;
    private NativeArray<int> Result;
    void Start()
    {
        //1프레임 안에하고싶음 TempJob, 아님 4프렘하는 persistat
        A=new NativeArray<int>(100, Allocator.TempJob);
        B=new NativeArray<int>(100, Allocator.TempJob);
        Result=new NativeArray<int>(100, Allocator.TempJob);
        for (int i = 0; i < 100; i++)
        {
            A[i] = i;
        }
       
        for (int i = 0; i < 100; i++)
        {
            B[i] = i;
        }
        StartCoroutine(CoJob());
        //print("현재 쓰레드 : "+Thread.CurrentThread.ManagedThreadId);
    }

    IEnumerator CoJob()
    {
        TestJob testJob; //struct라 new필요없음
        testJob.a = A;
        testJob.b = B;
        testJob.result = Result;
        //testJob.Schedule(); //스케줄 등록, 잡 실행
        JobHandle Handle = testJob.Schedule(100, 32);  //잡 실행과 돌시에 Handle에 넣어줌
        //JobHandle Handle = testJob.Schedule(1000,64); //다중실행, IJob대신 IJobParallelFor!
        //다중실행, 1000개를 한번에 64개 돌리기
        while (!Handle.IsCompleted) //작업이 끝나지 않은 동안 계속 대기
        {
            yield return null; //한 프레임 이동
        }
        Handle.Complete(); //끝날때까지 대기, async와 같은 용도이다. 이거때문에 다른쓰레드로 못넘어간다.
        for (int i = 0; i < 100; i++)
        {
            print("결과 : "+A[i]+" + "+B[i]+" = "+Result[i]);
        }
        A.Dispose();
        B.Dispose();
        Result.Dispose();
     
    }
    struct TestJob : IJobParallelFor
    {
        public NativeArray<int> a;
        public NativeArray<int> b;
        public NativeArray<int> result;
        
        public void Execute(int index)
        {
            //2 4 6 8
            result[index] = a[index] + b[index];
            print("현재 쓰레드 : "+Thread.CurrentThread.ManagedThreadId);
//            print("작업완료");
        }
    }
}
