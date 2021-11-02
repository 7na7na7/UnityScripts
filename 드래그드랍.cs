using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class 드래그드랍 : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        print("드래그 시작!");
    }

    // 마우스 드래그 중일 때 계속 발생하는 이벤트
    public void OnDrag(PointerEventData eventData)
    {
        print("드래그 중...");
        transform.position = eventData.position;
    }

    // 마우스 드래그가 끝났을 때 발생하는 이벤트
    public void OnEndDrag(PointerEventData eventData)
    {
        print("드래그 끝!");
    }
}
