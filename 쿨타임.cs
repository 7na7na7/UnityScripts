using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class 쿨타임 : MonoBehaviour
{
    //이미지 두개를 씌운다. 반투명한 것은 배경, 불투명한 것은 시계방향으로 변할 값. 이미지의 타입을 filled로 바꿔 준다!
    
    public Image dashCoolImg; //대쉬쿨타임 이미지(배경아님, 배경은 반투명)
    public Text dashCoolText; //대쉬쿨타임 표시 텍스트
    public float coolTime; //쿨타임
    
    private float currentCoolTime = 0;

    private void Update()
    {
        DashCooltime();
        Dash();
        if(currentCoolTime>0) //현재 쿨이 0초 이상이면
            currentCoolTime -= Time.deltaTime; //줄어들게 함
    }

    void DashCooltime()
    {
        dashCoolImg.fillAmount = 1-(currentCoolTime / coolTime);
        if (Mathf.Round(currentCoolTime * 10) * 0.1f != 0)
            dashCoolText.text = (Mathf.Round(currentCoolTime * 10) * 0.1f).ToString();
        else
            dashCoolText.text = "";
    }

    void Dash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentCoolTime <= 0) //현재 쿨이 0이하일 때
            {
                print("대쉬!");
                currentCoolTime = coolTime;
            }
        }
    }
}
