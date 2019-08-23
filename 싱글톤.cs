using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 싱글톤 : MonoBehaviour
{
    public static 싱글톤 instance;
    void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
    }
}