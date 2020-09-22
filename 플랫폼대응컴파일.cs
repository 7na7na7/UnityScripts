using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 플랫폼대응컴파일 : MonoBehaviour
{
    //if비교와 #if비교 차이 : 전자는 플랫폼확인 실행, 후자는 빌드타겟확인실행으로 에디터에서도 안드로이드발동 가능
    private void Awake()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            Debug.Log("안드로이드 폰 입니다.");
        } 
        else if (Application.platform == RuntimePlatform.IPhonePlayer)
        {
            Debug.Log("아이폰 입니다.");
        } 
        else 
        { 
            Debug.Log("안드로이드도 아이폰도 아닙니다."); 
        }


#if UNITY_ANDROID 
        Debug.Log("안드로이드 입니다."); 
#elif UNITY_IOS 
Debug.Log("아이폰 입니다."); 
#else 
Debug.Log("안드로이드도 아이폰도 아닙니다."); 
#endif
        
    }
}
