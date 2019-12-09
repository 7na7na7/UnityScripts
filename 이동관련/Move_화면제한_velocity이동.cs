using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_화면제한_velocity이동 : MonoBehaviour
{
    private float right, left; //가는 방향 바라보도록 localScale조정용
    
    Animator animator;//애니메이션 선언
    
    public Transform tr; //카메라밖 제한을 위해서 플레이어의 위치를 넣어준다.
    public float offset = 0.4f; //제한할때 오차 조정 코드(플레이어 중간을 인식해서 생기는 오차)
    float screenRation = (float)Screen.width / (float)Screen.height;

    public float moveforce = 1; 
    private int jumpcount = 2;
    public float jumpPower = 1f;
    public Rigidbody2D rigid;

    private void Start()
    {
        animator = GetComponent<Animator>();
        right = transform.localScale.x;
        left = transform.localScale.x * -1f;
    }

    private void Update()
    {
        Move();
        if (Input.GetKeyDown(KeyCode.Space))
        { 
            if (jumpcount > 0)
            { 
                rigid.velocity = Vector2.zero; 
                Vector2 jumpVelocity = new Vector2(0, jumpPower);
                rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
                jumpcount--;
            }
        }
        
        //아래는 카메라밖으로 못나가게 하는코드
        float size = Camera.main.orthographicSize;
        float wSize = Camera.main.orthographicSize * screenRation;
        if (tr.position.y >= size - offset)
        {
            tr.position = new Vector3(tr.position.x, size - offset, 0);//위

        }
        if (tr.position.y <= -size + offset)
        {
            tr.position = new Vector3(tr.position.x, -(size - offset), 0);//아래

        }
        if (tr.position.x >= wSize - offset)
        {
            tr.position = new Vector3(wSize - offset, tr.position.y, 0);//오른쪽
        }
        if (tr.position.x <= -wSize + offset)
        {
            tr.position = new Vector3(-wSize + offset, tr.position.y, 0);//왼쪽
        }
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.collider.CompareTag("ground")) //땅 닿을시 점프카운트 초기화
        { 
            jumpcount = 2;
        }
    }
        
    private void Move()
    {
        Vector3 moveVelocity = Vector3.zero;
        if (Input.GetAxisRaw("Horizontal") > 0)//오른쪽으로 갈때
        { 
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(right, this.transform.localScale.y, this.transform.localScale.z);//오른쪽으로 뒤집어짐
            animator.SetBool("Isstop", false); //가만히 있는 애니메이션 재생
            animator.SetBool("Iswalk", true);
        }
        if (Input.GetAxisRaw("Horizontal") < 0)//왼쪽으로 갈때
        { 
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(left, this.transform.localScale.y, this.transform.localScale.z); //왼쪽으로 뒤집어짐
            animator.SetBool("Isstop", false); //가만히 있는 애니메이션 재생
            animator.SetBool("Iswalk", true);
        } 
        if (Input.GetAxisRaw("Horizontal") == 0) //가만있을때
        {
            animator.SetBool("Iswalk", false);
            animator.SetBool("Isstop", true);//걷는 애니메이션 재생
        }
        transform.position += moveVelocity * moveforce * Time.deltaTime;
    }
}