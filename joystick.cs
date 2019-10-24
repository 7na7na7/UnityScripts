using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //포인터 입력을 상속받기 위해

//터치를 받기 위해 3개 상속받음
public class joystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    //RectTransform으로 받아옴
    public RectTransform rect_Background;
    public RectTransform rect_Joysick;

    private float radius; //반지름 저장 변수
    private bool isTouch = false; //터치 중인지
    private Vector3 movePosition; //움직일 좌표 저장
    private Vector2 value;
    
    public GameObject go_Player; //움직일 플레이어
    public float moveSpeed; //이동 속도
    void Start()
    {
        radius = rect_Background.rect.width * 0.5f; //반지름을 구함
    }
    
    void Update()
    {
        if (isTouch) //터치 중일 때만
        {
            //go_Player.transform.position += movePosition; //이동
            go_Player.GetComponent<Rigidbody>().AddForce(value);
        }
    }

    public void OnPointerDown(PointerEventData eventData) //터치를 시작하면
    {
        isTouch = true;
    }

    public void OnPointerUp(PointerEventData eventData) //터치를 떼면
    {
        isTouch = false;
        rect_Joysick.localPosition = Vector3.zero; //제자리로 돌아감
        movePosition=Vector3.zero;
    }

    public void OnDrag(PointerEventData eventData) //드래그할 때 조이스틱이 움직이도록
    {
        value = eventData.position - (Vector2)rect_Background.position;
        //마우스 현재 좌표에서 배경의 좌표를 뺀다.
        //그럼 즉, 배경의 좌표에서 상대적으로 얼마나 이동했는지를 구할 수 있다.

        value = Vector2.ClampMagnitude(value, radius); //value를 radius안에 가둠
        // (1,4)가 들어가면 1-4에서 1+4까지 가둔다. 즉 -3에서 5까지 나올 수 있다.
        
        rect_Joysick.localPosition = value;
        //localPosition은 부모 객체에 대해 상대적인 좌표를 나타낸다.
        //즉, 부모 객체에서 떨어지는 정도를 value, 배경의 좌표에서 이동한 만큼 조이스틱을 이동해 주는 것이다.

        float distance = Vector2.Distance(rect_Background.position, rect_Joysick.position)/radius;
        //백그라운드와 조이스틱의 거리차를 구함, distance는 거리 차가 클수록 커짐.
        //그리고 반지름으로 나눠 가장 빠를 때는 1, 느릴때는 반지름분의 1까지도 떨어질 수 있다.
        
        value = value.normalized; //속도값은 빠지고 방향값만 남게 됨
        //(50, 0, 30) -> (0.5, 0.3)
        movePosition=new Vector3(value.x*moveSpeed*distance*Time.deltaTime,value.y*moveSpeed*distance*Time.deltaTime,value.y*moveSpeed*distance*Time.deltaTime);
        //이동할 값을 정함. 위로는 이동하지 않으니 y는 0. 그리고 distance를 곱해줌. 최대 속도에서는 distance 0
    }
}
