using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 오브젝트드래그 : MonoBehaviour
{
    //오브젝트에 콜라이더(클릭범위) 넣어주고
       void OnMouseDrag() //드래그 중일 때
       {
           Vector3 mousePos3D = Input.mousePosition;
           this.transform.position = Camera.main.ScreenToWorldPoint(mousePos3D);
           transform.position=new Vector3(transform.position.x,transform.position.y,0);
       }
}
