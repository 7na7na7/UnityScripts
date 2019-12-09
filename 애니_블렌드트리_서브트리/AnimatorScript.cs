using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rigid;
    private BoxCollider2D col;
    
    public float jumpForce;
    public float moveSpeed;
    public LayerMask layermask;

    public float underray;
    
    private bool isMove;
    private bool isJump;
    private bool isFall;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        TryWalk();
        TryJump();
    }

    void TryJump()
    {
        if (isJump)
        {
            if (rigid.velocity.y <= -0.1f && !isFall) //떨어지고 있을 경우
            {
                isFall = true; //추락 ON
                anim.SetTrigger("fall");
            }

            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, underray); //아래쪽으로 발사

            if (hit.collider!=null)
            {
                anim.SetTrigger("land");
                isJump = false;
                isFall = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)&&!isJump) //스페이스바 눌렀을 때
        {
            isJump = true; //점프 ON
            //rigid.velocity=new Vector2(0,jumpForce); //점프
            rigid.AddForce(Vector2.up*jumpForce); //점프
            anim.SetTrigger("jump");
        }
    }
    
    private void TryWalk()
    {
        float _dirX = Input.GetAxisRaw("Horizontal"); //X값 넣어줌

        Vector3 direction=new Vector3(_dirX,0,0);
        
        isMove = false;
        
        if (direction != Vector3.zero)
        {
            isMove = true;
            print(direction);
            transform.Translate(direction.normalized*moveSpeed*Time.deltaTime); //방향만 나타냄
        }
        anim.SetBool("Move",isMove); //true, false값 넣어줌
        anim.SetFloat("DirX",direction.x); //x값 넣어줌
    }
}
