using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Keys { UP, DOWN, LEFT, RIGHT, COMBINE, DROP, USE, MAP }

public static class SetKey
{
    public static Dictionary<Keys,KeyCode> keys=
        new Dictionary<Keys, KeyCode>();
}
public class KeySetting : MonoBehaviour
{
    public Text[] keyTexts;
    private void Awake()
    {
        //기본 키로 초기화
       SetKey.keys.Add(Keys.UP,KeyCode.W);
       SetKey.keys.Add(Keys.DOWN,KeyCode.S);
       SetKey.keys.Add(Keys.LEFT,KeyCode.A);
       SetKey.keys.Add(Keys.RIGHT,KeyCode.D);
       SetKey.keys.Add(Keys.UP,KeyCode.);
       SetKey.keys.Add(Keys.DOWN,KeyCode.S);
       SetKey.keys.Add(Keys.LEFT,KeyCode.A);
       SetKey.keys.Add(Keys.RIGHT,KeyCode.D);
    }

    private void OnGUI()
    {
        Event keyEvent=Event.current; //현재 이벤트 가지고옴
        if (keyEvent.isKey&&key!=-1) //만약 이벤트가 키고 설정 가능하다면
        {
            SetKey.keys[(Keys)key] = keyEvent.keyCode; //0,1,2,3을 Keys형으로 변환해 각각 UP, DOWN, LEFT, RIGHT로 캐스팅
            keyTexts[key].text = keyEvent.keyCode.ToString(); //바꾼키 텍스트 표시
            key = -1; //첫 키만 적용되게 다시 -1로 바꿈
        }
    }

    private int key=-1;

    public void ChangeKey(int num)
    {
        key = num;
    }
}
