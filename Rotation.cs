using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    void Start() //아래 세 개 모두 똑같은 코드이다.
    {
        //Z각도를 90도로
        transform.rotation=Quaternion.Euler(0,0,90);
        
        //이것도 위와 똑같은 코드
        transform.eulerAngles=new Vector3(0,0,90);
        
        //이것도 위와 똑같은 코드
        Quaternion quaternion=Quaternion.identity; //Quaternion형 변수 생성 및 0으로 초기화
        quaternion.eulerAngles=new Vector3(0,0,90); //변수의 Z값에 90도를 넣음
        transform.rotation = quaternion; //변수 각도값을 넣어줌
    }
    void Update()
    {
        //오른쪽으로 계속 회전
        transform.Rotate(Vector3.back*Time.deltaTime*50f); 
    }
}
