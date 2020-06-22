using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 안드로이드_PC구분 : MonoBehaviour
{
    private void Start()
    {
#if(UNITY_ANDROID)
        print("안드로이드");
#else
print("PC");
#endif
    }
}
