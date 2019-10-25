using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    public Transform target; //바라볼 게임오브젝트의 transform 값
    private Quaternion left = Quaternion.identity; //Quaternion형 각도 변수 초기화하여 선언
    
    void Start()
    {
        //left.eulerAngles = new Vector3(0, 0, 90); //각도 값에 90도를 넣음(왼쪽)
    }
    
    void Update()
    {
        //transform.Rotate(Vector3(각도,각도,각도),Space.Self 또는 Space.World);
        if(Input.GetKey(KeyCode.R)) 
            transform.Rotate(Vector3.back); 
        //transform.RotateAround(point:Vector3, axis:Vector3, angle:float)
        //RotateAround() 함수는 현재 자신이 있는 위치(axis)와 특정 점(point)과의 거리를 반지름으로 하는 원을 그리면서 회전하는 공전과 축을 기준으로하는 자전을 동시에 수행한다.
        if (Input.GetKey(KeyCode.C))
            transform.RotateAround(Vector3.zero, Vector3.forward, 20);
        //Quaternion.eaulerAngles사용
        if (Input.GetKey(KeyCode.Q))
            transform.rotation = Quaternion.Slerp(transform.rotation, left, 2*Time.deltaTime); //왼쪽으로 서서히 회전하게 함
        
        
        //해당 벡터값 바라보게 하기
        transform.eulerAngles = new Vector3(0, 0, -getAngle(transform.position.x, transform.position.y, target.position.x, target.position.y)); //y2값에 180더하거나 말거나 ㅋ
        // z축 +180은 이미지 방향에 따라 수정하여 적용.
    }


    private float getAngle(float x1, float y1, float x2, float y2) //Vector값을 넘겨받고 회전값을 넘겨줌
    {
        float dx = x2 - x1;
        float dy = y2 - y1;

        float rad = Mathf.Atan2(dx, dy);
        float degree = rad * Mathf.Rad2Deg;
        
        return degree;
    }
}
