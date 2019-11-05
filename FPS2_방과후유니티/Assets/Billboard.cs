using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    //카메라의 앞에 정면만 보이겠다
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = -Camera.main.transform.forward;
    }
}
