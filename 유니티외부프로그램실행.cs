using System;
using UnityEngine;

public class 유니티외부프로그램실행 : MonoBehaviour
{
    void Start()
    {
        System.Diagnostics.Process.Start("D:/앙기모띠/기모띠.exe");
    }
}
