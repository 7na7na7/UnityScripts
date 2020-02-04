using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class 포인터가올려져있는가 : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private bool isBtnDown = false;
 
    private void Update()
    {
        if (isBtnDown) {
            print("A"); 
            GetComponent<Text>().color = Color.black;
        }
        else
        {
            print("B");
            GetComponent<Text>().color = new Color(200, 200, 200);
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isBtnDown = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isBtnDown = false;
    }
}
