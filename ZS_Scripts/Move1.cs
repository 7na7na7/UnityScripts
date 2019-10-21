using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public  class Move1 : MonoBehaviour
{
    public float bossstrong = 0;
    public float criticalheal = 0;
    public float standheal = 0;
    public float goldspeed = 0;
    private float savedmoveforce;
    public float dashforce = 4f;
    public float dashtime = 0.15f;
    private button btn;
    
    public float pistoldamage=0.5f;
    public float sniperdamage=1.5f;
    public float knifedamage = 2.5f;
    public float cowgundamage = 0.25f;
    public float sniper2damage = 3f;
    
    public int criticaldamage = 0;
    private Level lv;
    public int criticalpercent = 20;
    public int heartpercent = 20;
    public float staminahealvalue = 0.1f;
    public int healvalue = 5;
    private hitomi htm;
    public int level=1;
    private GoldManager gold;
    public bool isflip = false;
    public int shotdelaycount = 0, damagecount = 0; //무기강화 카운트
    public bool isdash;
    public AudioClip dashsound;
    public AudioClip healsound;
    public AudioClip coinsound;
    public LayerMask layerMask; //통과가 불가능한 레이어 설정
    public AudioSource audiosource; //오디오소스
    public Slider stamina;
    public int damage;
    public Transform min, max;
    public bool isdead = false;
    public float invisibletime;
    private Color color;
    public bool isdamaged = false;
    public Collider2D col;
    public Slider slider;
    public Vector3 moveVelocity;
    Animator animator;//애니메이션 선언
    public Transform tr; //카메라밖 제한을 위해서 플레이어의 위치를 넣어준다.
    public float offset = 0.4f; //제한할때 오차 조정 코드(플레이어 중간을 인식해서 생기는 오차)
    float screenRation = (float)Screen.width / (float)Screen.height;
    public float minusforce,plusforce;
    
    public float moveforce = 1;
    public float sniperforce = 0.9f;
    public float knifeforce = 1.2f;
    public float sniper2force = 0.8f;

    private void Start()
    {
        savedmoveforce = moveforce;
        btn = FindObjectOfType<button>();
        Time.timeScale = 1;
        lv = FindObjectOfType<Level>();
        level = 1;
        htm = FindObjectOfType<hitomi>();
        gold = FindObjectOfType<GoldManager>();
        gold.realgold = 0;
        //weaponselect(0);
        minusforce=this.transform.localScale.x * -1;
        plusforce=this.transform.localScale.x;
        animator = GetComponent<Animator>();
        //dashforce += dashforce * 0.5f;
        gold.gold = 1000;
    }
    
    void Update()
    {
        animator.speed = 0.2f * moveforce;
        
        if(Time.timeScale!=0)
            stamina.value += staminahealvalue;
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (Time.timeScale!=0)
            {
                if (stamina.value > 30)
                {
                    StartCoroutine(dash());
                    stamina.value -= 30;
                }
            }
        }
        
        if (slider.value <= 0)
        {
            if (isdead == false)
            {
                SpriteRenderer sprite = GetComponent<SpriteRenderer>(); //스프라이트로 함
                color.r = 255;
                color.g = 255;
                color.b = 255;
                color.a = 0.0f;
                sprite.color = color; //스프라이트 투명화
                gold.savedgold += gold.realgold;
                lv.canpause = false;
                PlayerPrefs.SetInt(gold.goldstring, gold.savedgold); //골드저장
                isdead = true;
                for (int i = 0; i < 5; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);   
                }
            }
        }
    }
    private void FixedUpdate()
    {
        if(!isdead) 
            Move();
    }

    private void Move()
    {
        moveVelocity = Vector3.zero;
            if (Input.GetAxisRaw("Horizontal") > 0) //오른쪽으로 갈때
            {
                if (transform.position.x < max.position.x)
                {
                    moveVelocity.x += 1;
                    if (isCol() == true)
                        moveVelocity.x -= 1;
                    //transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                    transform.localScale = new Vector3(plusforce, this.transform.localScale.y, this.transform.localScale.z);//오른쪽으로 뒤집어짐
                    isflip = false;
                    animator.SetBool("iswalk", true);
                }
            }

            if (Input.GetAxisRaw("Horizontal") < 0) //왼쪽으로 갈때
            {
                if (transform.position.x > min.position.x)
                {
                    moveVelocity.x -= 1;
                    if (isCol() == true)
                        moveVelocity.x += 1;
                    //transform.rotation = Quaternion.Euler(180f, 0f, 180f);
                    transform.localScale = new Vector3(minusforce, this.transform.localScale.y, this.transform.localScale.z); //왼쪽으로 뒤집어짐
                    isflip = true;
                    animator.SetBool("iswalk", true);
                }
            }

            if (Input.GetAxisRaw("Vertical") > 0) //위쪽으로 갈때
            {
                if (transform.position.y < max.position.y)
                {
                    moveVelocity.y += 1;
                    if (isCol() == true)
                        moveVelocity.y -= 1;
                    animator.SetBool("iswalk", true);
                }
            }

            if (Input.GetAxisRaw("Vertical") < 0) //아래쪽으로 갈때
            {
                if (transform.position.y > min.position.y)
                {
                    moveVelocity.y -= 1;
                    if (isCol() == true)
                        moveVelocity.y += 1;
                    animator.SetBool("iswalk", true);
                }
            }

            if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0) //가만있을때
            {
                if(lv.currentzombie>=1) 
                    slider.value += standheal;
                animator.SetBool("iswalk", false);
            }
            transform.position += moveVelocity * moveforce * Time.deltaTime;
    }
    /*
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.CompareTag("edge"))
        {
            Debug.Log("asfsf");
            if (Input.GetAxisRaw("Vertical") > 0)//위쪽으로 갈때
            {
                transform.position += Vector3.down * moveforce * Time.deltaTime;
            }
            else if (Input.GetAxisRaw("Vertical") < 0)//아래쪽으로 갈때
            {
                transform.position += Vector3.up * moveforce * Time.deltaTime;
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)//왼
            {
                transform.position += Vector3.right * moveforce * Time.deltaTime;
            } 
            else if (Input.GetAxisRaw("Horizontal") > 0)//오
            {
                transform.position += Vector3.left * moveforce * Time.deltaTime;
            }
        }
    }
*/
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isdash == false)
        {
            if (other.CompareTag("zombie")||other.CompareTag("acid"))
            {
                if (isdamaged == false)
                {
                    StartCoroutine(damaged("zombie"));
                    StartCoroutine(invisible());
                }
            }
            else if (other.CompareTag("zombieking"))
            {
                if (isdamaged == false)
                {
                    StartCoroutine(damaged("zombieking"));
                    StartCoroutine(invisible());
                }
            }
        }
        if (other.CompareTag("gold"))
        {
            Debug.Log("동전에 닿음!");
            audiosource.PlayOneShot(coinsound, 5f);
        }

        if (other.CompareTag("heart"))
        {
            Destroy(other.gameObject);
            slider.value += healvalue;
            audiosource.PlayOneShot(healsound, 0.7f);
        }
        if (other.CompareTag("bigheart"))
        {
            Destroy(other.gameObject);
            slider.value += healvalue+15;
            audiosource.PlayOneShot(healsound, 0.7f);
        }
    }

    IEnumerator damaged(string enemy)
    {
        if (enemy == "zombie")
        {
            isdamaged = true;
            slider.value -= damage;
            //col.enabled = false;
            yield return new WaitForSeconds(1.5f);
            //col.enabled = true;
            isdamaged = false;
        }
        else if (enemy == "zombieking")
        {
            isdamaged = true;
            slider.value -= damage*2;
            //col.enabled = false;
            yield return new WaitForSeconds(1.5f);
            //col.enabled = true;
            isdamaged = false;
        }
    }

    IEnumerator invisible()
    {
        SpriteRenderer sprite= GetComponent<SpriteRenderer>();//스프라이트로 함
        color.r = 255;
        color.g = 255;
        color.b = 255;
        color.a = 0.5f;
        sprite.color = color;
        yield return new WaitForSeconds(invisibletime);
        color.a = 1f;
        sprite.color = color;
        yield return new WaitForSeconds(invisibletime);
        color.a = 0.5f;
        sprite.color = color;
        yield return new WaitForSeconds(invisibletime);
        color.a = 1f;
        sprite.color = color;
        yield return new WaitForSeconds(invisibletime);
        color.a = 0.5f;
        sprite.color = color;
        yield return new WaitForSeconds(invisibletime);
        color.a = 1f;
        sprite.color = color;
        yield return new WaitForSeconds(invisibletime);
    }

    IEnumerator dash()
    {
        htm.gameObject.SetActive(false);
        isdash = true;
        animator.SetBool("isdash",true);
        audiosource.PlayOneShot(dashsound);
        moveforce *= dashforce;
        //col.enabled = false;
        yield return new WaitForSeconds(dashtime);
        //col.enabled = true;
        moveforce /= dashforce;
        htm.gameObject.SetActive(true);
        animator.SetBool("isdash",false);
        yield return new WaitForSeconds(0.1f);
        isdash = false;
    }

    private bool isCol()
    {
        RaycastHit2D hit;
        //RaycastHit2D란?
        //A지점에서 B지점으로 레이저를 발사했을 때, 레이저가 도달하면 hit에 Null이 반환,
        //레이저가 도달하지 못하면 hit에 레이저와 충돌한 방해물이 반환된다!
        Vector3 start = transform.position; //A지점은 현재 위치
        Vector3 end =
            start + moveVelocity * moveforce * Time.deltaTime;
        col.enabled = false; //플레이어가 자기 자신과의 충돌 판정을 하는 것을 막기 위해 잠시 콜라이더 비활성화
        hit = Physics2D.Linecast(start, end, layerMask);
        col.enabled = true; //다시 활성화
        if (hit.transform != null) //만약 플레이어의 위치와 플레이어가 이동할 위치 사이에 장애물이 있을 경우
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void weaponselect(int weapon)
    {
        for (int i = 0; i < 7; i++)
        {
            if (i == weapon)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        if (weapon == 2)
        {
            moveforce = sniperforce;
        }
        else if (weapon == 3)
        {
            moveforce = knifeforce;
        }
        else if (weapon == 5)
        {
            moveforce = sniper2force;
        }
        else
        {
            moveforce = savedmoveforce;
        }
        if(weapon>=0&&weapon<=3)
        {
            {
                Debug.Log("asdfasf");
                damagecount = 0;
                shotdelaycount = 0;
                btn.enhancecount = 20;////////////?????
                btn.enhancesaving = 15;
                btn.enhancebtn.text = "무기 강화 - " +  btn.enhancecount + "G";
            }
        }
        else if(weapon>=4&&weapon<=7)
        {
            damagecount = 0;
            shotdelaycount = 0;
            btn.enhancecount = 30;
            btn.enhancesaving = 20;
            btn.enhancebtn.text = "무기 강화 - " +  btn.enhancecount + "G";
        }
    }
    public void weaponupgrade(int weapon)
    {
        for (int i = 0; i < 7; i++)
        {
            if (i == weapon)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        if (weapon == 2)
        {
            moveforce = sniperforce;
        }
        else if (weapon == 3)
        {
            moveforce = knifeforce;
        }
        else if (weapon == 5)
        {
            moveforce = sniper2force;
        }
        else
        {
            moveforce = savedmoveforce;
        }
        /*
        damagecount = 0;
        shotdelaycount = 0;
        btn.enhancecount = 20;
        btn.enhancesaving = 15;
        btn.enhancebtn.text = "무기 강화 - " + btn.enhancecount + "G";
        */
    }
}
