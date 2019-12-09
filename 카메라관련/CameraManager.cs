using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float speed = 2f;
    public GameObject target; //카메라가 따라갈 대상
    public BoxCollider2D bound; //카메라가 나가지 못하는 영역을 박스 콜라이더로 받음
    
    private Vector3 targetPosition; //대상의 현재 값
    private Vector3 minBound, maxBound; //박스 콜라이더 영역의 최소/최대 xyz값을 지님
    private float halfWidth, halfHeight; //카메라의 반너비, 반높이 값을 지닐 변수
    private Camera theCamera; //카메라의 반높이값을 구할 속성을 이용하기 위한 변수

    private void Start()
    {
        theCamera = GetComponent<Camera>();
        minBound = bound.bounds.min; //minbound에 box콜라이더의 영역 최솟값 대입
        maxBound = bound.bounds.max;
        halfHeight = theCamera.orthographicSize;
        halfWidth = halfHeight * Screen.width / Screen.height; //카메라 반너비 공식
    }

    void Update()
    {
        if (target.gameObject != null)
        {
            targetPosition.Set(target.transform.position.x, target.transform.position.y, this.transform.position.z);
            //transform.position = targetPosition;
            transform.position = Vector3.Lerp(transform.position, targetPosition, speed * Time.deltaTime); 
            float clampedX = Mathf.Clamp(this.transform.position.x, minBound.x + halfWidth, maxBound.x - halfWidth);
            float clampedY = Mathf.Clamp(this.transform.position.y, minBound.y + halfHeight, maxBound.y - halfHeight);
            //Mathf.Clamp(10,0,100) 일 경우 값은 10,
            //Mathf.Clamp(-10,0,100)일 경우 값은 0이다.
            this.transform.position=new Vector3(clampedX,clampedY,this.transform.position.z);
        }
    }

    public void SetBound(BoxCollider2D newBound)
    {
        bound = newBound;
        minBound = bound.bounds.min; //minbound에 box콜라이더의 영역 최솟값 대입
        maxBound = bound.bounds.max;
    }
}
