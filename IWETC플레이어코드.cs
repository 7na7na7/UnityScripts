using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;//
using Random = UnityEngine.Random;

public class IWETC플레이어코드: MonoBehaviour
{
    public first fst;
    Animator animator;//애니메이션 선언
    bool notforce = true;
    public AudioClip portal;//포탈소리
    public AudioClip jumpdae;//점프대소리
    public AudioClip sfx;//소리
    public AudioSource audioSource;//소리

    public int jumpcount = 2;
    Animator PlayerAnim;
    public float offset = 0.4f; //offset값으로 화면 밖 나가는거 제한 코드 오차조정
    public Transform tr;

    public static float movePower = 1f;
    public float jumpPower = 1f;
    public float slowPower = 0.3f;
    public float movePowersave = 1f;
    Rigidbody2D rigid;
    Vector3 movement;
    bool isJumping = false;
    private void Awake()
    {
        PlayerAnim = gameObject.GetComponent<Animator>();
    }
    void Start()
    {
        movePower = movePowersave;
        animator = GetComponent<Animator>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
    }

    IEnumerator OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("ground")) //땅 닿을시 점프카운트 초기화
        {
            movePower = movePowersave;
            jumpcount = 2;
        }
        if (coll.CompareTag("slowground")) //땅 닿을시 점프카운트 초기화 1개만
            jumpcount = 1;
        if (coll.CompareTag("portal")) //포탈 닿을시
        {
            audioSource.PlayOneShot(portal);//소리
            rigid.velocity = Vector2.zero;
            portal portalblock = coll.gameObject.GetComponent<portal>();
            Vector3 portalPos = portalblock.portalobj.transform.position;
            Vector3 warpPos = new Vector3(portalPos.x, portalPos.y - 0.2f, portalPos.z);
            transform.position = warpPos;
        }
        if (coll.CompareTag("outportal")) // out포탈 닿을시
        {
            audioSource.PlayOneShot(portal);//소리
            portal portalblock = coll.gameObject.GetComponent<portal>();
            Vector3 portalPos = portalblock.portalobj.transform.position;
            Vector3 warpPos = new Vector3(portalPos.x, portalPos.y + 0.2f, portalPos.z);
            transform.position = warpPos;
        }
        if (coll.CompareTag("up")) //점프대 닿을시
        {
            audioSource.PlayOneShot(jumpdae);//소리
            uparrow jumpblock = coll.gameObject.GetComponent<uparrow>();
            //this.transform.GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpblock.value * 100);
            rigid.velocity = Vector2.zero;//가속도 0으로

            Vector2 jumpVelocity = new Vector2(0, jumpblock.value);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
            //isJumping = false;
        }
        if (coll.CompareTag("slow"))
        {
            movePower = slowPower;
        }
        if (coll.CompareTag("forceup"))//위
        {
            rigid.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, 2);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
            notforce = false;///
            Invoke("trueforce", 0.2f);
        }
        if (coll.CompareTag("forcedown"))//아래
        {
            rigid.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, -2);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
            notforce = false;///
            Invoke("trueforce", 0.2f);
        }
        if (coll.CompareTag("forceright"))//오른쪽
        {
            rigid.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(2, 0);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
            notforce = false;///
            Invoke("trueforce", 0.2f);
        }
        if (coll.CompareTag("forceleft"))//왼쪽
        {
            rigid.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(-2, 0);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
            notforce = false;///
            Invoke("trueforce", 0.2f);
        }
        if (coll.CompareTag("upitem")) //점프아이템 닿을시
        {
            jumpcount++;
        }
        if (coll.CompareTag("ddong")) //새배설물 닿을시 
        {
            rigid.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(-3, 0);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
            jumpVelocity = new Vector2(0, -1.5f);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
            notforce = false;///
            Invoke("trueforce", 0.2f);
        }
        if (coll.CompareTag("snow"))
        {
            movePower /= 3;
            yield return new WaitForSeconds(0.7f);
            movePower = movePowersave;
        }
    }
    void Update()
    {

        if (Input.GetButtonDown("Jump") || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.RightShift))
        {
            isJumping = true;
        }

        //밖으로 나가지 못하게!
        float size = Camera.main.orthographicSize;


        if (tr.position.y <= -size + offset)
        {
            tr.position = new Vector3(tr.position.x, -(size - offset), 0);//아래

        }
        float screenRation = (float)Screen.width / (float)Screen.height;

        if (Input.GetKeyDown(KeyCode.Escape))
            SceneManager.LoadScene("title");
    }
    private void FixedUpdate()
    {
        if (notforce == true)
        {
            Move();
        }
        Jump();
    }

    private void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
            transform.localScale = new Vector3(1, 1, 1);//오른쪽으로 뒤집어짐
            animator.SetBool("Isstop", false);/////////////////////////
            animator.SetBool("Iswalk", true);/////////////////////////

        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
            transform.localScale = new Vector3(-1, 1, 1); //왼쪽으로 뒤집어짐
            animator.SetBool("Isstop", false);/////////////////////////
            animator.SetBool("Iswalk", true);/////////////////////////

        }
        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("Iswalk", false);/////////////////////////
            animator.SetBool("Isstop", true);/////////////////////////
        }
        transform.position += moveVelocity * movePower * Time.deltaTime;
    }
    void Jump()
    {
        if (!isJumping)
            return;
        if (jumpcount > 0)
        {
            audioSource.PlayOneShot(sfx);//점프소리
            rigid.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, jumpPower);
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
            isJumping = false;
            jumpcount--;
        }
    }
    void trueforce()
    {
        notforce = true;
    }
}

