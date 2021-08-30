using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPref저장변수프로퍼티
{
    //이렇게 하면 언제든 PlayerPref저장변수프로퍼티.savedValue로 한번에 저장과 로드를 하며 가져올 수 있다!
    public static float savedValue
    {
        get { return PlayerPrefs.GetFloat("savedValue", 1.0f); }
        set { PlayerPrefs.SetFloat("savedValue", value); }
    }
}
