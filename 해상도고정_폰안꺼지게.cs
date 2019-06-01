using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 폰: MonoBehaviour
{
    void Awake()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep; //폰이 안꺼지게 해준다.
        Screen.SetResolution(600, 1024, true); //600 X 1024 화면으로 해상도를 고정한다.
    }
}

