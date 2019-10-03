using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgreturn2 : MonoBehaviour
{
    public Vector2 speed = Vector2.zero;
    private MeshRenderer m_mesh = null;

    private void Start()
    {
        m_mesh = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        m_mesh.material.mainTextureOffset += speed * Time.deltaTime;
    }
}
