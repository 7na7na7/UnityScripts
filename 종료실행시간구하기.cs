using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 종료실행시간구하기 : MonoBehaviour
{
    public void 종료시()
    {
        PlayerPrefs.SetString("SaveLastTime", System.DateTime.Now.ToString());
        Debug.Log("종료 시간 : " + System.DateTime.Now.ToString());
    }

    public void 실행시()
    {
        string lastTime = PlayerPrefs.GetString("SaveLastTime");
        System.DateTime lastDateTime = System.DateTime.Parse(lastTime);
        System.TimeSpan conpareTime = System.DateTime.Now - lastDateTime;



        Debug.Log("실행 시간 : " + System.DateTime.Now.ToString());
        Debug.LogFormat("게임 종료 후, {0}초 지났습니다.", conpareTime.TotalSeconds);   
    }
}
