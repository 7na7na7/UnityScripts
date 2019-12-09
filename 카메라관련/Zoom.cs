using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    public float zoomSpeed; //줌 속도
    public float zoomMax; //줌 최대값
    public float zoomMin; //줌 최솟값

    public float moveSpeed; //이동속도
    public float rotateSpeed; //회전속도
    void CameraZoom() //카메라를 줌인/줌아웃할 수 있게 해주는 함수
    {
        float zoomDirection = Input.GetAxis("Mouse ScrollWheel"); //휠입력을 받음

        if (transform.position.y <= zoomMax && zoomDirection > 0)//마우스 휠을 위로 끌고 있는데 최댓값 이상이 되면
            return; //아무것도안함
        if (transform.position.y >= zoomMin && zoomDirection < 0) //마우스 휠을 아래로 끌고 있는데 최솟값 이하가 되면
            return; //아무것도안함

        transform.position += transform.forward * zoomDirection * zoomSpeed; //카메라의 y축 이동
    }

    void CameraMove()
    {
        if (Input.GetMouseButton(2)) //휠버튼 클릭하는 중
        {
            float posX = Input.GetAxis("Mouse X"); //Mouse X는 커서를 오른쪽으로 움직이면 1, 왼쪽으로는 -1리턴됨
            float posZ = Input.GetAxis("Mouse Y"); //Mouse Y는 커서를 위쪽으로 움직이면 1, 아래쪽으로는 -1리턴됨
            
            transform.Translate(-posX*moveSpeed*Time.deltaTime,-posZ*moveSpeed*Time.deltaTime,0);
        }
    }

    void CameraRotate()
    {
        if (Input.GetMouseButton(1)) //오른쪽 클릭하는 중
        {
            float posX = Input.GetAxis("Mouse X"); //Mouse X는 커서를 오른쪽으로 움직이면 1, 왼쪽으로는 -1리턴됨
            float posY = Input.GetAxis("Mouse Y"); //Mouse Y는 커서를 위쪽으로 움직이면 1, 아래쪽으로는 -1리턴됨
            
            transform.Rotate(posY, posX, 0);
            transform.rotation = Quaternion.Euler(new Vector3(transform.eulerAngles.x,transform.eulerAngles.y,0));
        }
    }
    private void Update()
    {
        CameraZoom();
        CameraMove();
        CameraRotate();
       
        transform.Translate( Input.GetAxis("Horizontal")*5*Time.deltaTime,0,0); //WASD, 방향키로도 
        transform.Translate( 0,0,Input.GetAxis("Vertical")*5*Time.deltaTime); //이동 가능하게 해봄!
    }
}