using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 참조2 : MonoBehaviour
{
    private CameraManager theCamera; 
    
    void Start()
    {
        theCamera = FindObjectOfType<CameraManager>(); //theCamera에 CameraManager타입을 가진 오브젝트를 대입해 준다
    }
}