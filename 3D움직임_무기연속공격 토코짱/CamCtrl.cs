using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamCtrl : MonoBehaviour
{
   public Transform target; //카메라가 추적할 플레이어
   public float xMoveSpeed = 500; //카메라 y축 회전속도
   public float yMoveSpeed = 250; //카메라 x축 회전속도

   private float yMinLimit = 5; //카메라 x축 회전 제한 최소 값
   private float yMaxLimit = 80;//카메라 x축 회전 제한 최대 값
   private float x, y; //마우스 이동 방향 값
   private float distance; //카메라와 target의 거리

   private void Awake()
   {
      //최초 설정된 target과 카메라의 위치를 바탕으로 distance값 초기화
      distance = Vector3.Distance(transform.position, target.position);
      //최초 카메라의 회전 값을 x,y변수에 저장
      Vector3 angles = transform.eulerAngles;
      x = angles.y;
      y = angles.x;
   }

   private void Update()
   {
      //target이 존재하지 않으면 리턴
      if (target == null) return;
      
      //마우스를 x,y축 움직임 방향 정보
      x += Input.GetAxis("Mouse X") * xMoveSpeed * Time.deltaTime;
      y -= Input.GetAxis("Mouse Y") * yMoveSpeed * Time.deltaTime;
      //오브젝트의 위/아래(x축) 한계 범위 생성
      y = ClampAngle(y, yMinLimit, yMaxLimit);
      //카메라의 회전정보 갱신
      transform.rotation = Quaternion.Euler(y, x, 0);
      //카메라의 위치정보 갱신, target의 위치를 기준으로 distance만큼 떠어져서 쫓아감
      transform.position = transform.rotation * new Vector3(0, 0, -distance) + target.position;
   }


   float ClampAngle(float angle, float min, float max)
   {
      if (angle < -360) angle += 360;
      if (angle > 360) angle -= 360;

      return Mathf.Clamp(angle, min, max);
   }
}
