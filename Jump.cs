using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpforce = 0; //점프하는 힘의 크기
    public int maxjumpcount = 0; //최대 점프카운트
    private int jumpcount = 0; //현재 점프카운트
    public float offset = 1;
    private Rigidbody2D rigid = null;
    private float distance = 0; //raycast의 거리를 지정해 줌
    public LayerMask layermask = 0;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        distance = GetComponent<BoxCollider2D>().bounds.extents.y + offset; //콜라이더 y축 절반 크기+offset, offset은 플레이어 발판에서 떨어진 범위
    }

    void CheckGround()
    {
        if (rigid.velocity.y < 0) //낙하할 때만 체크
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 
                distance, layermask); 
            //플레이어 방향을 중심으로 아래 방향으로 distance만큼 쏘아 layermask레이어에 충돌하는 것을 저장
            if (hit)
            {
                if (hit.transform.CompareTag("ground")) //닿은 물체의 태그가 ground라면
                    jumpcount = 0; //점프카운트 0으로 초기화
            }
        }
    }
    void jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //스페이스 바를 누르면
        {
            if (jumpcount < maxjumpcount) //점프카운트가 최대 점프카운트보다 낮을 떄
            {
                jumpcount++; //점프카운트++
                rigid.velocity = Vector2.up * jumpforce; //점프
            }
        }
    }
    void Update()
    {
        jump();
        CheckGround();
    }
}
