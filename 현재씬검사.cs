using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 현재씬검사 : MonoBehaviour
{
    private void Start()
    {
        if(SceneManager.GetActiveScene().name=="first")
            Debug.Log("현재 씬은 first입니다.");
    }
}
