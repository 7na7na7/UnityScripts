using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_3D : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    
    private Animator anim;
    private Rigidbody rigid;
    private Vector2 axis;
    private Vector3 moveVec;
    private Vector3 dodgeVec;
    private bool walkDown;
    private bool jumpDown;
    private bool isJump;
    private bool isDodge;
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }
    
    void Update()
    { 
        GetInput(); //키입력
        Move();  //이동
        SetAnim(); //애니메이션 설정
        Turn(); //이동방향으로 바라보기
        Jump(); //점프
        Dodge(); //구르기
    }

    void GetInput()
    {
        axis.x=Input.GetAxisRaw("Horizontal");
        axis.y = Input.GetAxisRaw("Vertical");
        walkDown = Input.GetButton("Walk");
        jumpDown = Input.GetButtonDown("Jump");
        
    }

    void Move()
    {
        if (isDodge)
            moveVec = dodgeVec;
        else
            moveVec = new Vector3(axis.x, 0, axis.y).normalized; //정규화해서 대각선이동 속도일정

        rigid.MovePosition(transform.position+moveVec*speed*Time.deltaTime*(walkDown ? 0.3f:1f)); //MovePosition이동
    }

    void SetAnim()
    {
        anim.SetBool("isRun",moveVec!=Vector3.zero); //이동중이면 isRun 참으로 전달
        anim.SetBool("isWalk",walkDown); //걷는지 안걷는지 전달
    }

    void Turn()
    {
        if (moveVec != Vector3.zero)
        {
            Vector3 relativePos = (transform.position + moveVec) - transform.position;
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime*10);   
        }

        //transform.LookAt(transform.position + moveVec); 을 선형보간으로 구현했다!
    }

    void Jump()
    {
        if (jumpDown&&!isJump&&moveVec==Vector3.zero&&!isDodge)
        {
            isJump = true;
            rigid.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
            anim.SetBool("isJump",true);
            anim.SetTrigger("doJump"); 
        }
    }

    void Dodge()
    {
        if (jumpDown && !isJump&&moveVec!=Vector3.zero&&!isDodge)
        {
            speed *= 2;
            anim.SetTrigger("doDodge");
            dodgeVec = moveVec;
            isDodge = true;
            Invoke("DodgeOut",0.5f);
        }
    }

    void DodgeOut()
    {
        speed *= 0.5f;
        isDodge = false;
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Floor"))
        {
            isJump = false;
            anim.SetBool("isJump",false);
        }
    }
}
