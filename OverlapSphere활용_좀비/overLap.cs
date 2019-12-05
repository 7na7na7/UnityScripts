using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class overLap : MonoBehaviour
{
    public LayerMask layer; //감지할 레이어
    public float speed = 5f; //속도
    public float radius; //감지할 원의 반지름

    private Vector3 firstPos;
    private void Start()
    {
        firstPos = transform.position; //처음 위치 저장
    }

    void Update()
    {
   
    //public ParticleSystem particle;
    
        //도히 기준으로 이내의 반경의 플레이어를 검색
        Collider2D col = Physics2D.OverlapCircle(transform.position, radius, layer);
        if (col != null) //플레이어가 비지 않았다면
        {
            //부드럽게 플레이어를 따라감
            transform.position += (col.transform.position-transform.position) * speed * Time.deltaTime;
            transform.position=new Vector3(transform.position.x,firstPos.y,0); //Y축 고정
        }
        else //비었다면
        {
            //처음 위치로 돌아옴
            transform.position += (firstPos-transform.position) * speed * 0.5f*Time.deltaTime;
        }
    }
}
