﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 해상도설정_ScreenResolution : MonoBehaviour
{
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, true); //풀스크린, 1920 x 1080
    }
}
