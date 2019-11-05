using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Record //Record클래스 선언
{
    public int[] temp= new int[5]; //그냥 크기가 5인 배열 선언

    public int this[int index] //인덱스 선언(프로퍼티와 비슷)
    {
        get
        {
            if (index >= temp.Length)
            {
                Debug.Log("배열 오버플로우!"); //배열 값이 배열 길이보다 길면 오류출력

                return 0;
            }
            else
            {
                return temp[index];
            }
        }
        set 
        { if (index >= temp.Length) Debug.Log("배열 오버플로우!"); //배열 값이 배열 길이보다 길면 오류출력
            else temp[index] = value; } 
    }
}
public class Indexer : MonoBehaviour
{ 
    Record record=new Record(); //Record객체 선언
    
    void Start()
    {
        record[3] = 5; //인덱서를 사용하였기 때문에 그냥 record로 해도 this에서 index를 바로 인식해 준다.
        record[5] = 5; //배열의 값에서 벗어났으므로 인덱서에 의하여 오류 문장 출력
        print(record[3]); //잘 들어감
        print(record[5]); //배열 값에서 벗어나서 오류 메시지 출력, 0이 반환되므로 0도 함께 출력
    }
}
