using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 사다리 : MonoBehaviour
{
    //사다리에는 Ladder태그를 넣고, 반드시 리지드바디를 넣은 다음 타입은 Dynamic에 중력은 0으로 설정해야 한다!  
    
    
    public float speed = 10; //스피드
    public float jumpSpeed = 10; //점프하는 힘
    public int maxJumpCount = 1; //최대 점프 수
    public float LadderSpeed = 2;


    private int jumpCount = 0; //점프횟수
    private bool canDetect = true; //아래쪽 감지기능

    private Rigidbody2D rigid; //리지드바디 얻어오기
    private SpriteRenderer SpriteRenderer; //스프라이트 렌더러 얻어오기
    private bool isLadder = false;
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); //리지드바디 컴포넌트 얻어옴
        SpriteRenderer = GetComponent<SpriteRenderer>(); //스프라이트 렌더러 컴포넌트 얻어옴
    }

    void Update()
    {
        SimpleMove();
    }

    void SimpleMove()
    {
        if (isLadder)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigid.bodyType = RigidbodyType2D.Dynamic;
                rigid.AddForce(Vector2.up*400);
                isLadder = false;
            }
        }
        else
        {
            if (Input.GetAxisRaw("Horizontal") == 1)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed); 
                SpriteRenderer.flipX = true; 
            }
            else if (Input.GetAxisRaw("Horizontal") == -1)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
                SpriteRenderer.flipX = false;
            }
        
            if (Input.GetKeyDown(KeyCode.Space)) //위를 눌렀을 때
            {
                if (jumpCount < maxJumpCount)
                {
                    jumpCount++;
                    rigid.velocity = new Vector2(0f, jumpSpeed); 
                }
            }      
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag=="Ground")
            jumpCount = 0;
    }
    
    
    //사다리타기
    private void OnTriggerStay2D(Collider2D other)
    {
        //위 키를 누르고 있고, 닿아 있는 물체의 태그가 ladder라면
        if (other.CompareTag("Ladder"))
        {
            if (Input.GetKey(KeyCode.UpArrow)) //위 키를 누르면
            {
                if(rigid.bodyType==RigidbodyType2D.Dynamic) 
                    rigid.bodyType = RigidbodyType2D.Static;
                if (rigid.bodyType == RigidbodyType2D.Static)
                {
                    isLadder = true; //사다리 타는 중
                    transform.Translate(Vector3.up * Time.deltaTime * 3);
                }
            }
            if (Input.GetKey(KeyCode.DownArrow)) //위 키를 누르면
            {
                if (rigid.bodyType == RigidbodyType2D.Static)
                {
                    isLadder = true; //사다리 타는 중
                    transform.Translate(Vector3.down * Time.deltaTime * 3);
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ladder"))
        {
            if (isLadder)
            {
                rigid.bodyType = RigidbodyType2D.Dynamic;
                rigid.AddForce(Vector2.up*400);
                isLadder = false;   
            }
        }
    }
}
