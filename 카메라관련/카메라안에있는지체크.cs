using System;
using UnityEngine;
using System.Collections;

public class 카메라안에있는지체크 : MonoBehaviour
{
    public static CheckCamera instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    void Update () 
    {
        // 오브젝트가 카메라 안에 있는지 확인
        Debug.Log (CheckObjectIsInCamera(gameObject)); //안에 있으면 True, 없으면 False반환
    }

    public bool CheckObjectIsInCamera(GameObject _target)
    {
        Camera selectedCamera = Camera.main;
        Vector3 screenPoint = selectedCamera.WorldToViewportPoint(_target.transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;

        return onScreen;
    }
}