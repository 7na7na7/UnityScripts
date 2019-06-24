using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgreturn : MonoBehaviour
{
    //배경으로 쓸 스프라이트의 Texture Type을 Default로 설정하고, Wrap Mode를 Repeat으로 설정한다.
    //3D Object - Quad 를 생성한다.
    //Shader를 Unlit - Transparent 로 설정하면 배경이 투명해진다.
    //이 스크립트를 넣고, 속도를 설정하면 끝!
    private new Renderer renderer;
    public float speed = 0.1f;
    public float offset;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void Update()
    {
        offset = Time.time * speed;
        renderer.material.SetTextureOffset("_MainTex", new Vector2(offset, 0));
    }

       
    }
}
