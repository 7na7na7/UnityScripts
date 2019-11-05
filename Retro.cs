using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Retro : MonoBehaviour
{
  //배열
  private int[] exp = new int[5] {1, 2, 3, 4, 5};
  
  
  //ArrayList(배열 리스트) - https://zzdd1558.tistory.com/59
  private ArrayList arrayList = new ArrayList();

  
  //List(리스트)
  private List<int> list = new List<int>(); //int형 리스트 선언
  //리스트는 배열 리스트와 다르게 자료형이 정해져 있어 변환 연산을 거치지 않아 컴퓨터가 더 좋아한다.
  //사용법은 배열 리스트나 리스트나 같다

  
  //Hashtable(해쉬 테이블)
  private Hashtable hashTable = new Hashtable();
  
  
  //Dictionary(딕셔너리)
  Dictionary<string,int> dictionary=new Dictionary<string, int>();
  //사용법 - dictionary.Add("인덱스1",100); 
  //딕셔너리도 해쉬 테이블과 비슷하지만, 자료형 두 개를 정해 줄 수 있어 더 연산에 편리하다고 한다.
  
  
  //Queue(큐), 선입선출 FIFO구조
  Queue<int> queue = new Queue<int>(); //int형 큐 선언
  //포션 제작소에서 10개 제작을 걸면 첫번째 주문한 포션이 제일 먼저 제작되고, 마지막에 주문한 포션이 마지막에 제작됨
  
  
  //Stack(스택), 후입 선출 LIFO구조
  Stack<int> stack = new Stack<int>(); //int형 스택 선언
  

  private void Start()
  {
    ArrayList();
    //HashTable();
    //Queue();
    //Stack();
  }

  void ArrayList() //ArrayList 함수
  {
    arrayList.Add(13);
    arrayList.Add(3.8);
    arrayList.Insert(0,5);//인덱스 0에 5끼워넣기, 13과 3.8은 5뒤로 밀림
    arrayList.Add("하이루");
    arrayList.Add("이히히히");
    arrayList.Remove(13); //13 삭제
    arrayList.RemoveAt(3);//4번째 원소 삭제, 13이 사라졌으므로 ArrayList의 크기는 4가 되어 이히히히가 삭제된다.
    //arrayList.RemoveRange(0, 3); //인덱스 0부터 3까지의 원소 삭제, 모두 삭제됨
    //arrayList.Clear(); //초기화
    
    Debug.Log("ArrayList의 크기 : "+arrayList.Count);
    Debug.Log(arrayList.Contains("하이루")); //"하이루"를 포함하고 있으므로 treu출력
    
    foreach (var element in arrayList) //for문으로 arrayList.Count로 해도 상관없다.
    {
      Debug.Log(element); // 5, 3.8, 하이루 출력
    }
  }

  void HashTable()
  {
    hashTable.Add("만", 10000);
    hashTable.Add(50, "오십");
    
    //Clear, Remove, Contain등 컬렉션들은 다 비슷하게 사용하고 있다.
    
    Debug.Log(hashTable["만"]); //10000 출력
    Debug.Log(hashTable[50]); //오십 출력
  } //HashTable 함수
 
  void Queue()
  {
    queue.Enqueue(5); //5넣음
    queue.Enqueue(10); //10넣음
    
    if(queue.Count!=0) //큐가 비어 있지 않다면
      Debug.Log(queue.Dequeue());//값을 하나 빼고 반환, 5출력
    if(queue.Count!=0) //큐가 비어 있지 않다면
      Debug.Log(queue.Dequeue());//값을 하나 빼고 반환, 10출력
    if(queue.Count!=0) //큐가 비어 있지 않다면
      Debug.Log(queue.Dequeue());//이제 큐가 비었으므로 이 구문은 실행되지 않음
    
    //결과적으로 5, 10 순서로 출력
  } //Queue 함수

  void Stack()
  {
    stack.Push(1); //스택에 1 넣음
    stack.Push(2); //스택에 2 넣음
    stack.Push(3); //스택에 3 넣음
    
    if(stack.Count!=0) //스택이 비지 않았다면
      Debug.Log(stack.Pop()); //3반환하고 출력
    if(stack.Count!=0) //스택이 비지 않았다면
      Debug.Log(stack.Pop()); //2반환하고 출력
    if(stack.Count!=0) //스택이 비지 않았다면
      Debug.Log(stack.Pop()); //1반환하고 출력
    if(stack.Count!=0) //스택이 비지 않았다면
      Debug.Log(stack.Pop()); //스택이 비었으므로 출력되지 않음
  } //Stack 함수
}
