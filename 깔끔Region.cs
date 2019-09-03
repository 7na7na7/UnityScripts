using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 깔끔Region : MonoBehaviour
{
    //region을 이용해 싱글톤을 깔끔하게 표현해 보자!
    #region Singleton
    public static 깔끔Region instance;
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
    #endregion Singleton

}