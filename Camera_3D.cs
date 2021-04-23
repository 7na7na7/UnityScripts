using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_3D : MonoBehaviour
{
    public Transform target;
    private Vector3 offset;

    private void Awake()
    {
        offset = transform.position - target.position;
    }

    void Update()
    {
        transform.position = target.position + offset;
    }
}
