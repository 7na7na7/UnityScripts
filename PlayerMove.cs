using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public static PlayerMove instance; //싱글톤을 위해서

    #region PUBLIC
    //충돌처리를 위해 쏠 Ray
    public float RightRay, LeftRay; //쏠 레이의 길이
    public float[] UpRay=new float[2]; //0번째는 최소x, 1번쨰는 최대x, 2번째는 y
    public float[] DownRay=new float[2];//0번째는 최소x, 1번쨰는 최대x, 2번째는 y
    public LayerMask Groundlayer; //Ray감지 마스크
    /*
    public float runSpeed = 12; //뛰는 스피드
    public float DashLength = 3f; //대쉬 길이
    public float DashSpeed = 5f; //대쉬 스피드
    public float DashDelay = 1f; //다시 대쉬할 수 있을 떄까지의 딜레이
    public float RaycastLength = 1f; //레이저의 길이
    public Animator anim; //플레이어 애니메이터 얻어오기
    */
    public float speed = 10; //스피드
    public float jumpSpeed = 10; //점프하는 힘
    public float MaxJumpTime = 1f; //최대 점프 시간
    public int maxJumpCount = 1; //최대 점프 수
    #endregion
   

    #region PRIVATE
    private float jumpTime = 0f; //점프키를 누를수록 오래 점프하기 위해서
    private bool canJump = false; //점프키를 계속 누르고 있으면 계속 점프하는 것 수정
    private int jumpCount = 0; //점프횟수
    private bool canDetect = true; //아래쪽 감지기능
    private Collider2D col;
    
    //방향키 두번 연속으로 누르면 뛰기를 위한 변수
    /*
    private bool canRunCoruRight = false;
    private bool canRunRight = false;
    private bool canRunCoruLeft = false;
    private bool canRunLeft = false;
    */
    private RaycastHit2D up; //위로쏘는 레이
    private RaycastHit2D down; //아래로쏘는 레이
    private Rigidbody2D rigid; //리지드바디 얻어오기
    private SpriteRenderer SpriteRenderer; //스프라이트 렌더러 얻어오기
    #endregion
   
    
    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>(); //리지드바디 컴포넌트 얻어옴
        SpriteRenderer = GetComponent<SpriteRenderer>(); //스프라이트 렌더러 컴포넌트 얻어옴
        
        //싱글톤
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        col = GetComponent<Collider2D>();
        
        maxJumpCount++;
        

            //StartCoroutine(stop()); //코루틴실행

        //동적으로 설정하고 싶다면 아래를 주석처리하세요
        RightRay = 0.5f;
        LeftRay = 0.5f;
        UpRay[0] = 0.25f;
        UpRay[1] = 0.25f;
        UpRay[2] = 0.5f;
        DownRay[0] = 0.25f;
        DownRay[1] = 0.25f;
        DownRay[2] = -0.5f;
    }

    void Update()
    {
        //anim.SetFloat("velocity",rigid.velocity.y);
        //Move();
        SimpleMove();
    }

    void SimpleMove()
    {
        if (Input.GetKey(KeyCode.RightArrow)) //오른쪽 키를 누르고 있는 중
        {
            RaycastHit2D right = Physics2D.Raycast(col.transform.position, Vector2.right, RightRay, Groundlayer);
            if (right.collider == null) 
                transform.Translate(Vector3.right * Time.deltaTime * speed); //걷기   
            SpriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow)) //왼쪽 키를 누르고 있는 중
        {
            RaycastHit2D left = Physics2D.Raycast(col.transform.position, Vector2.left, LeftRay, Groundlayer);
            if (left.collider == null) 
                transform.Translate(Vector3.left * Time.deltaTime * speed); //걷기
            SpriteRenderer.flipX = false;
        }
         if (Input.GetKeyDown(KeyCode.UpArrow)) //점프 키를 눌렀을 때
        { 
            if (jumpCount < maxJumpCount)
                canJump = true;
            else
                canJump = false;
        }
         if (Input.GetKey(KeyCode.UpArrow)) //점프 키를 누르고 있는 중
        {

            up = Physics2D.Linecast(new Vector2(col.transform.position.x+col.bounds.size.x*UpRay[0],col.transform.position.y + col.bounds.size.y*UpRay[2]), 
                new Vector2(col.transform.position.x+col.bounds.size.x*UpRay[1],col.transform.position.y + col.bounds.size.y*UpRay[2]),Groundlayer);

            
            if (up.collider == null)
            {
                if (jumpTime < MaxJumpTime && canJump)
                {
                    
                    jumpTime += Time.deltaTime;
                    rigid.velocity = new Vector2(0f, 4f); //최대 거리에서 딱딱하게 고정되는 느낌을 부드럽게 바꿔 보았다.
                    transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed);
                }
            }
            else
            {
                jumpTime = MaxJumpTime;
               rigid.velocity = Vector2.down; //가속도 없애고 떨어지는 느낌으로
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) //점프 키를 뗏을 때
        {
            jumpTime = 0;
            jumpCount++;
        }

        down = Physics2D.Linecast(new Vector2(col.transform.position.x+col.bounds.size.x*DownRay[0],col.transform.position.y+col.bounds.size.y*DownRay[2]),
            new Vector2(col.transform.position.x+col.bounds.size.x*DownRay[1],col.transform.position.y+col.bounds.size.y*DownRay[2]),Groundlayer);

        try
        {
            if (down.collider.CompareTag("Ground"))
            {
                canJump = false;
                jumpTime = 0;
                jumpCount = 0;
                canDetect = true;
            }
            else
            {
                if (canDetect)
                {
                    jumpCount++;
                    canDetect = false;
                }
            }
        }
        catch (System.Exception e)
        {
            if (canDetect)
            {
                jumpCount++;
                canDetect = false;
            }
        }
    }
    /*
    void Move()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) //오른쪽 키를 눌렀을 때
        {
            if (canRunCoruRight)
            {
                canRunCoruRight = false;
                canRunRight = true;
            }
            else
            {
                StartCoroutine(CanRunCorRight());
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)) //오른쪽 키를 누르고 있는 중
        {
            canRunLeft = false;
            if (Input.GetKey(KeyCode.LeftArrow)) //왼쪽 키를 누르고 있는 중
            {
                RaycastHit2D left = Physics2D.Raycast(col.transform.position, Vector2.left, LeftRay, Groundlayer);

                if (left.collider == null)
                {
                    if (canRunLeft)
                    {
                        //오른쪽으로 가다 왼쪽으로 가면 걷게 함, 바로 뛰면 안되니까!
                        transform.Translate(Vector3.left * Time.deltaTime * runSpeed);
                    }
                    else
                    {
                        transform.Translate(Vector3.left * Time.deltaTime * speed); //걷기
                    }
                }
            }
            else
            {
                RaycastHit2D right = Physics2D.Raycast(col.transform.position, Vector2.right, RightRay, Groundlayer);
                if (right.collider == null)
                {
                    if (canRunRight)
                    {
                        SpriteRenderer.flipX = false;
                        transform.Translate(Vector3.right * Time.deltaTime * runSpeed); //뛰기
                        if(!PlayerAttack.instance.isAttack&&rigid.velocity.y==0) 
                            Run();
                    }
                    else
                    {
                        SpriteRenderer.flipX = false;
                        transform.Translate(Vector3.right * Time.deltaTime * speed); //걷기 
                        if(!PlayerAttack.instance.isAttack&&rigid.velocity.y==0) 
                            Walk();
                    }
                    isright = true;
                    isleft = false;
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.RightArrow)) //오른쪽 키를 뗐을 때
        {
            canRunRight = false;
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow)) //왼쪽 키를 누를 때
        {
            if (canRunCoruLeft)
            {
                canRunCoruLeft = false;
                canRunLeft = true;
            }
            else
            {
                StartCoroutine(CanRunCorLeft());
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow)) //왼쪽 키를 누르고 있는 중
        {
            canRunRight = false;
            if (Input.GetKey(KeyCode.RightArrow))
            {
                RaycastHit2D right = Physics2D.Raycast(col.transform.position, Vector2.right, RightRay, Groundlayer);

                if (right.collider == null)
                {
                    if (canRunRight)
                    {
                        //왼쪽으로 가다 오른쪽으로 가면 걷게!
                        transform.Translate(Vector3.right * Time.deltaTime * runSpeed);
                    }
                    else
                    {
                        transform.Translate(Vector3.right * Time.deltaTime * speed); //걷기   
                    }
                }
            }
            else
            {
                RaycastHit2D left = Physics2D.Raycast(col.transform.position, Vector2.left, LeftRay, Groundlayer);

                if (left.collider == null)
                {
                    if (canRunLeft)
                    {
                        SpriteRenderer.flipX = true;
                        transform.Translate(Vector3.left * Time.deltaTime * runSpeed); //뛰기
                        if(!PlayerAttack.instance.isAttack&&rigid.velocity.y==0) 
                            Run();
                    }
                    else
                    {
                        SpriteRenderer.flipX = true;
                        transform.Translate(Vector3.left * Time.deltaTime * speed); //걷기
                        if(!PlayerAttack.instance.isAttack&&rigid.velocity.y==0) 
                            Walk();
                    }
                }
            }
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow)) //왼쪽 키를 뗐을 때
        {
            canRunLeft = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow)) //점프 키를 눌렀을 때
        { 
            if (jumpCount < maxJumpCount)
                canJump = true;
            else
                canJump = false;
            
             if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (up.collider == null)
            {
                if (jumpTime < MaxJumpTime && canJump)
                {
                    StartCoroutine(Jump());
                } 
            } 
        } 
        }

        if (Input.GetKey(KeyCode.UpArrow)) //점프 키를 누르고 있는 중
        {

            up = Physics2D.Linecast(new Vector2(col.transform.position.x+col.bounds.size.x*UpRay[0],col.transform.position.y + col.bounds.size.y*UpRay[2]), 
                new Vector2(col.transform.position.x+col.bounds.size.x*UpRay[1],col.transform.position.y + col.bounds.size.y*UpRay[2]),Groundlayer);

            
            if (up.collider == null)
            {
                if (jumpTime < MaxJumpTime && canJump)
                {
                    
                    jumpTime += Time.deltaTime;
                    rigid.velocity = new Vector2(0f, 4f); //최대 거리에서 딱딱하게 고정되는 느낌을 부드럽게 바꿔 보았다.
                    transform.Translate(Vector3.up * Time.deltaTime * jumpSpeed);
                }
            }
            else
            {
                jumpTime = MaxJumpTime;
               rigid.velocity = Vector2.down; //가속도 없애고 떨어지는 느낌으로
            }
        }

        if (Input.GetKeyUp(KeyCode.UpArrow)) //점프 키를 뗏을 때
        {
            jumpTime = 0;
            jumpCount++;
        }

        down = Physics2D.Linecast(new Vector2(col.transform.position.x+col.bounds.size.x*DownRay[0],col.transform.position.y+col.bounds.size.y*DownRay[2]),
            new Vector2(col.transform.position.x+col.bounds.size.x*DownRay[1],col.transform.position.y+col.bounds.size.y*DownRay[2]),Groundlayer);

        try
        {
            if (down.collider.CompareTag("Ground"))
            {
                canJump = false;
                jumpTime = 0;
                jumpCount = 0;
                canDetect = true;
            }
            else
            {
                if (canDetect)
                {
                    jumpCount++;
                    canDetect = false;
                }
            }
        }
        catch (System.Exception e)
        {
            if (canDetect)
            {
                jumpCount++;
                canDetect = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(Dash());
        } //대쉬 키를 눌렀을 때
        
        //플레이어위치제한
        transform.position =
            new Vector2(
                Mathf.Clamp(transform.position.x, CameraMove.instance.minBound.x, CameraMove.instance.maxBound.x),
                transform.position.y);
        
    }
    */
    
/*
    IEnumerator CanRunCorRight()
    {
        canRunCoruRight = true;
        yield return new WaitForSeconds(0.5f);
        canRunCoruRight = false;
    }
    IEnumerator CanRunCorLeft()
    {
        canRunCoruLeft = true;
        yield return new WaitForSeconds(0.5f);
        canRunCoruLeft = false;
    }

    IEnumerator stop()
    {
        while (true)
        {
            float x = transform.position.x;
            yield return new WaitForSeconds(0.1f);
            if (x == transform.position.x)
            {
                if (!PlayerAttack.instance.isAttack && rigid.velocity.y == 0) //공격 중이 아니고, 떨어지고 있는 중이 아니라면
                {
                    Idle(); //Idle애니메이션으로 변환
                }
            }
        }
    }
 IEnumerator Dash()
    {
        float x=!SpriteRenderer.flipX ?x = transform.position.x + DashLength: x = transform.position.x - DashLength;
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if (transform.position.x <= x) //플레이어가 x보다 왼쪽에 있으면
            {
                transform.Translate(Vector3.right*DashSpeed*Time.deltaTime);
                if (transform.position.x >= x)
                    break;
            }
            else
            {
                transform.Translate(Vector3.left*DashSpeed*Time.deltaTime);
                if (transform.position.x <= x)
                    break;
            }
        }

        yield return null;
    }
    public IEnumerator Jump()
    {
        yield return new WaitForSeconds(0.05f);
        anim.Play("Jump");
    }
    public void Run()
    {
      anim.Play("Run");
    }
    public void Idle()
    {
        anim.Play("Idle");
    }
    public void Walk()
    {
        anim.Play("Walk");
    }
*/
}

