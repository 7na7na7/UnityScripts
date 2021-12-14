using System;
using UnityEngine;
using System.Collections;

public class 화면밖인지확인 : MonoBehaviour
{
    public static 화면밖인지확인 instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    
    public bool CheckObjectIsInCamera(GameObject _target)
    {
        Camera selectedCamera = Camera.main;
        Vector3 screenPoint = selectedCamera.WorldToViewportPoint(_target.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        return onScreen;
    }
}