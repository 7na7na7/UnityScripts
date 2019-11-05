using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRot : MonoBehaviour
{
    //마우스의 입력을 받아서 카메라 로테이션
    //마우스 입력값
    float mx, my;
    //카메라 로테이션 값
    float rx, ry;
    float camSpeed = 200.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //마우스 속도에 따라 값이 커짐
        mx = Input.GetAxis("Mouse X");
        my = Input.GetAxis("Mouse Y");

        rx += mx*camSpeed* Time.deltaTime;
        ry -= my * camSpeed * Time.deltaTime;

        ry=Mathf.Clamp(ry, -60, 60);
        transform.eulerAngles =new Vector3(ry, rx, 0);
    }
}
