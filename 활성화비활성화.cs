using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class 활성화비활성화 : MonoBehaviour
{
    public GameObject Target;
    private bool isactive = false;
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) //마우스 왼쪽 버튼을 누르면
        {
            if (isactive == false) //만약 isactive가 false라면
            {
                Target.SetActive(true); //활성화
                isactive = true;
            }
            else //아니라면
            {
                Target.SetActive(false); //비활성화
                isactive = false;
            }
        }
    }
}

