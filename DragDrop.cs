using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems; //인터페이스 상속을 위해서


//아래 인터페이스는 캔버스 안의 UI에게만 적용
//이 스크립트는 캔버스 안의 이미지에 들어간다.
public class DragDrop : MonoBehaviour, IBeginDragHandler,IDragHandler,IEndDragHandler,IDropHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("드래그 시작");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("드래그 중");
        transform.position = eventData.position;
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("드롭");
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("드래그 끝");
    }
}
