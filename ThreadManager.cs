using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class ThreadManager : MonoBehaviour
{
   
    public Button StartButton;
 
    public int ThreadNumber;
 
    public int TotalCount = 100;
 
    [HideInInspector]
    public ObjectPool<int> NumberPool = new ObjectPool<int>();
    
    void Start()
    {
        for (int i = 0; i < TotalCount; i++)
        {
            NumberPool.Push(i + 1);
        }
 
        StartButton.onClick.AddListener(()=> { ThreadStart(); }); //버튼클릭시 쓰레드 시작하게 이벤트넣어줌
    }
 
    private void ThreadStart() //ThreadNumber가 3개 이상이면 쓰레드 3개 이상이 동시 실행될 때 순서대로 빼내오지 못하게 된다. (오차발생)
    {
        for (int i = 0; i < ThreadNumber; i++)
        {
            Work wk = new Work(i + 1, this);
                Task t = Task.Factory.StartNew(() => { wk.Run(); });
                //t.Wait();
        }
    }
 
    public void WriteConsole(int tNum, int number)
    {
        Debug.Log(string.Format("Thread Number:{0} CurrentNumber:{1}",tNum,number));
    }
    
}
