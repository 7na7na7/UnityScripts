using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 인스펙터깔끔 : MonoBehaviour
{
    [Header("Transform")] //Transform이 위에 태그로 붙어서 어떤 변수들인지 인스펙터 창에서 확인할 수 있게 해준
    public Vector3 Position;
    public Vector3 Rotation;
    public Vector3 Scale;

    [Header("Player")]
    public string PlayerName;
    public float MoveSpeed; 
    public float JumoForce; 
    
    //[Space] //빈 공간을 띄워 줌, 깔끔하게 할 수 있음
    
    [Header("private값")]
    [SerializeField] //private변수도 인스펙터 창에서는 보이도록 해 준다. 
    private int privateValue;

    [Header("0.1부터 2까지 랜덤값설정")]
    [Range(.1f,2f)]//범위설정
    public float range;
}

