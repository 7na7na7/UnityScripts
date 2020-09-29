using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SlimeScript : MonoBehaviour
{
    public GameObject hpCanvas;
    public float bulletDMG;
    public float UZIDMG;
    public float ShotGunDMG;
    public float ExplosionDMG;
    private float guard = 0f;
    public float nuckBackPower;
    public GameObject[] bloods;
    private bool canMove = true;
    private GameManager gm;
    public Slider hp;
    public LayerMask layer; //감지할 레이어
    public float speed = 5f; //속도
    private float[] radius=new float[150];
    private bool isUp = false;
    private bool isDown = false;
    private bool isdead = false;
    private void Start()
    {
        if (gameObject.name != "Data")
        {
            gm = FindObjectOfType<GameManager>();
            gm.zombieCreate();
            if (gm.currentzombie > gm.zombiecount[gm.i])
            {
                gm.currentzombie--;
                Destroy(gameObject);
            }

            for (int i = 0; i < 150; i++)
            {
                radius[i] = i * 0.2f;
            }

            guardUp();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (gameObject.name != "Data")
        {
            if (other.CompareTag("Bullet"))
            {
                if (!other.GetComponent<Bullet>().isCollide)
                {
                    StartCoroutine(nuckBack(false, other.GetComponent<Bullet>().dir));
                    other.GetComponent<Bullet>().isCollide = true;
                    if (other.name.Contains("UZI") == true)
                        hp.value -= UZIDMG-UZIDMG* guard;
                    else if (other.name.Contains("ShotGun") == true)
                        hp.value -= ShotGunDMG -ShotGunDMG* guard;
                    else
                        hp.value -= bulletDMG -bulletDMG* guard;
                }
            }

            if (other.CompareTag("Grenade"))
            {
                hp.value -= ExplosionDMG - ExplosionDMG* guard;
            }
        }
    }
    private void Update()
    {
        if (gameObject.name != "SlimeData")
        {
            if (hp.value <= 0)
                {
                    StartCoroutine(die());
                }

            if (canMove)
            {
                if (isUp)
                {
                    transform.Translate(Vector2.down * Time.deltaTime * speed);
                }
                else if (isDown)
                {
                    transform.Translate(Vector2.up * Time.deltaTime * speed);
                }
                else
                {
                    int i = 0;
                    while (true)
                    {
                        Collider2D col;
                        try
                        {
                            col = Physics2D.OverlapCircle(transform.position, radius[i], layer);
                        }
                        catch (Exception e)
                        {
                            break;
                        }
                        
                        if (col != null) //플레이어가 비지 않았다면
                        {
                            
                                //부드럽게 플레이어를 따라감
                                Vector2 dir = col.transform.position - transform.position;
                                dir.Normalize();
                                //transform.Translate(dir * Time.deltaTime * speed);
                                GetComponent<Rigidbody2D>().velocity = dir * speed;
                                transform.position = new Vector3(transform.position.x, transform.position.y, 0); //Z축 고정
                                break;
                            
                        }
                        else
                        {
                            i++;
                        }
                    }
                }
            }
            else
            {
                GetComponent<Rigidbody2D>().velocity=Vector2.zero;
            }
        }
    }

    public IEnumerator UpSpawner()
    {
        isUp = true;
        Vector3 lastPos = transform.position + new Vector3(0, -1.3f, 0);
        yield return new WaitUntil(()=>transform.position.y-lastPos.y<0.1f);
        isUp = false;
    }
    public IEnumerator DownSpawner()
    {
        isDown = true;
        Vector3 lastPos = transform.position + new Vector3(0, 1.3f, 0);
        yield return new WaitUntil(()=>lastPos.y-transform.position.y<0.1f);
        isDown = false;
    }

    IEnumerator die()
    {
        if (gameObject.name != "Data")
        {
            if (!isdead)
            {
                isdead = true;
                hpCanvas.SetActive(false);
                canMove = false;
                float a = 1f;
                SpriteRenderer spr = GetComponent<SpriteRenderer>();
                Color color = spr.color;
                Destroy(GetComponent<CapsuleCollider2D>());
                while (true)
                {
                    color.a -= 0.1f;
                    spr.color = color;
                    yield return new WaitForSeconds(Time.deltaTime);
                    if (color.a < 0.1f)
                        break;
                }

                int r = Random.Range(0, 4);
                Instantiate(bloods[r], transform.position,
                    Quaternion.EulerAngles(new Vector3(0, 0, Random.Range(0, 360))));
                gm.zombieDead(1200);
                Destroy(gameObject);
            }
        }
    }

    public void onHit()
    {
        int r2 = Random.Range(0, 4);
            Instantiate(bloods[r2],transform.position,Quaternion.EulerAngles(new Vector3(0,0,Random.Range(0,360))));
    }
     IEnumerator nuckBack(bool isRandom = false, int dir = 3)
    {
        canMove = false;
        float x=0, y=0;
        if (isRandom)
        {
            int r = -1 * Random.Range(0, 2);
            int r2 = -1 * Random.Range(0, 2);
            x = nuckBackPower * r;
            y = nuckBackPower * r2;
        }
        else
        {
            switch (dir)
                {
                    //위부터 1, 시계방향
                    case 1: 
                        y = nuckBackPower;
                        break;
                    case 2:
                        y = nuckBackPower;
                        x = nuckBackPower;
                        break;
                    case 3:
                        x = nuckBackPower;
                        break;
                    case 4:
                        y = nuckBackPower * -1;
                        x = nuckBackPower;
                        break;
                    case 5:
                        y = nuckBackPower * -1;
                        break;
                    case 6:
                        y = nuckBackPower * -1;
                        x = nuckBackPower * -1;
                        break;
                    case 7:
                        x = nuckBackPower * -1;
                        break;
                    case 8:
                        y = nuckBackPower;
                        x = nuckBackPower * -1;
                        break;
                }
        }
        Vector3 V = new Vector3(x,y,0);
        transform.position += V;
        yield return new WaitForSeconds(0.1f);
        canMove = true;
    }
     public void guardUp()
     {
         for (int i = 0; i < gm.wave; i++)
         {
             guard += 0.05f;
         }
     }
}
