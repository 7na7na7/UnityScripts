using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rect_Transform : MonoBehaviour
{ 
    //Rect Transform은 UI에 들어있는 transform값이라 생각하면 쉽다!
    public GameObject[] choicewindow;

    private void Start()
    {
        //choicewindow[0]게임오브젝트의 RectTransform값의 offsetMin, offsetMax를 조절한다!
        choicewindow[0].GetComponent<RectTransform>().offsetMin = new Vector2(choicewindow[0].GetComponent<RectTransform>().offsetMin.x, choicewindow[0].GetComponent<RectTransform>().offsetMax.y-250); //Bottom을 250줄임
        choicewindow[0].GetComponent<RectTransform>().offsetMax = new Vector2(choicewindow[0].GetComponent<RectTransform>().offsetMax.x, choicewindow[0].GetComponent<RectTransform>().offsetMax.y-250); //Top을 250늘림
    }
}
