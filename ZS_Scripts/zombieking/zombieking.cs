using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombieking : MonoBehaviour
{
    private zombieclass zombieclass;
    private Level level;
    private float maxhp;
    private bananagun gun;
    private Move1 player;
    private Level lv;
    private bool isleft = false, isright = false;
    private bool once2 = false;
    private bool once = false;
    public GameObject gold;

    public GameObject critical;
    public GameObject bigheart;
    private bool isdead = false;
    private bool canevent = true;
    public AudioSource audiosource;
    public AudioClip dashsound;
    public AudioClip readysound;
    public AudioClip spawnsound;
    public AudioClip deathsound;

    public GameObject dummy;
    private Vector3 dir;
    private bool cananotdetect = false;
    private Animator anim;
    private bool ismove = true;
    public GameObject hp, hpframe;
    private GameObject obj;
    private Transform target; // 따라갈 물체의 방향
    public float speed = 1.0f;

    private void Start()
    {
        level = FindObjectOfType<Level>();
        gun = FindObjectOfType<bananagun>();
        player = GameObject.Find("player").GetComponent<Move1>();
        lv = FindObjectOfType<Level>();
        for (int i = 0; i < lv.wave / 5; i++) //일단 보스강화, 나중에 없애야지
        {
            //hp.transform.localScale += new Vector3(this.transform.localScale.x*0.5f, 0, 0);
            //hpframe.transform.localScale += new Vector3(this.transform.localScale.x*0.5f, 0, 0);
            speed += 0.3f;
        }
        maxhp = hp.transform.localScale.x;
        anim = GetComponent<Animator>();
        lv.currentzombie++;
        obj = this.gameObject;
        anim.SetBool("israge", false);
        StartCoroutine(pattern());
    }

    void Update()
    {
        if (!player.isdead)
        {
            if(ismove)
            {
            if (isleft || isright)
            {
                if (isleft)
                    transform.Translate(-0.15f, 0, 0);
                if (isright)
                    transform.Translate(0.15f, 0, 0);
            }
            else
            {
                if (cananotdetect == false)
                {
                    target = player.transform;
                    dir = target.position - transform.position; //사이의 거리를 구함
                }
            }
            dir.Normalize();
            transform.position += Time.deltaTime * speed * dir;
            }

                if (hp.transform.localScale.x <= maxhp / 2)
                {
                    if (once == false)
                    {
                        Debug.Log("레이제리에지레이제리에지레잊");
                        anim.SetBool("israge", true);
                        speed *= 2f;
                        once = true;
                    }
                }

                if (hp.transform.localScale.x <= 0)
                {
                    if (isdead == false)
                    {
                        isdead = true;
                        BoxCollider2D col = GetComponent<BoxCollider2D>();
                        col.enabled = false;
                        audiosource.PlayOneShot(deathsound, 2f);
                        GameOver gameover = GameObject.Find("Canvas").GetComponent<GameOver>();
                        gameover.zombiecount += 1;
                        level.zombiecount[level.i]--; //생성되면 zombiecount--
                        level.currentzombie--;
                        ismove = false;
                        canevent = false;
                        isdead = true;
                        StartCoroutine(delaycoin());
                        player.moveforce -= player.bossstrong;
                        Destroy(obj, 2f);
                    }
                }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("banana")||other.CompareTag("knife"))
        {
            if (gun.weapon == "sniper")
                hp.transform.localScale += new Vector3(-1*player.sniperdamage*0.4f, 0, 0);
            else if (gun.weapon == "knife")
                hp.transform.localScale += new Vector3(-1*player.knifedamage*0.4f, 0, 0);
            else if (gun.weapon == "sniper2")
                hp.transform.localScale += new Vector3(-1 * player.sniper2damage*0.4f, 0, 0);
            else
                hp.transform.localScale += new Vector3(-1*player.pistoldamage*0.4f, 0, 0);
            int r = Random.Range(0, player.criticalpercent); //치명타확률계산
           if (r == 0) //총기강화
            {
                if (gun.weapon == "pistol")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount * 0.5f, 0, 0);
                else if (gun.weapon == "sniper")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount*1f, 0, 0);
                else if (gun.weapon == "knife")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount*2f, 0, 0);
                else if (gun.weapon == "shotgun")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount*7f, 0, 0);
                else if (gun.weapon == "shotgun2")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount*1f, 0, 0);
                else if (gun.weapon == "cowgun")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount*0.7f, 0, 0);
                else if (gun.weapon == "sniper2")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount*2f, 0, 0);
            }
            else
            { 
                if (gun.weapon == "pistol")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount * 0.25f, 0, 0);
                else if (gun.weapon == "sniper")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount*0.5f, 0, 0);
                else if (gun.weapon == "knife")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount*1f, 0, 0);
                else if (gun.weapon == "shotgun")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount*0.35f, 0, 0);
                else if (gun.weapon == "shotgun2")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount*0.5f, 0, 0);
                else if (gun.weapon == "cowgun")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount*0.35f, 0, 0);
                else if (gun.weapon == "sniper2")
                    hp.transform.localScale += new Vector3(-1 * player.damagecount*1f, 0, 0);
            }
            if (player.slider.maxValue - player.slider.value == 0) //풀피일떄
            {
                hp.transform.localScale += new Vector3(-1 * zombieclass.fullattack, 0, 0);
            }

            if (player.slider.value <= player.slider.maxValue * 0.3f) //현재hp의30%이하일때
            {
                hp.transform.localScale += new Vector3(-1 * zombieclass.lessattack, 0, 0);
            }

            if (player.slider.maxValue - player.slider.value == 0) //풀피일떄
            {
                hp.transform.localScale += new Vector3(-1 * zombieclass.fullattack, 0, 0);
            }

            if (player.slider.value <= player.slider.maxValue * 0.3f) //현재hp의30%이하일때
            {
                hp.transform.localScale += new Vector3(-1 * zombieclass.lessattack, 0, 0);
            }
            hp.transform.localScale += new Vector3(-1 * player.bossstrong*0.5f, 0, 0); //어빌리티데미지
        }
    }

    IEnumerator delaycoin()
    {
        yield return new WaitForSeconds(1.9f);
        Instantiate(bigheart,
            new Vector3(this.transform.position.x, this.transform.position.y, bigheart.transform.position.z),
            Quaternion.identity);
          Instantiate(gold, new Vector3(this.transform.position.x+Random.Range(-2.5f,2.5f), this.transform.position.y+Random.Range(-2.5f,2.5f), gold.transform.position.z), Quaternion.identity); //동전생성
Instantiate(gold, new Vector3(this.transform.position.x+Random.Range(-2.5f,2.5f), this.transform.position.y+Random.Range(-2.5f,2.5f), gold.transform.position.z), Quaternion.identity); //동전생성
         Instantiate(gold, new Vector3(this.transform.position.x+Random.Range(-2.5f,2.5f), this.transform.position.y+Random.Range(-2.5f,2.5f), gold.transform.position.z), Quaternion.identity); //동전
         Instantiate(gold, new Vector3(this.transform.position.x+Random.Range(-2.5f,2.5f), this.transform.position.y+Random.Range(-2.5f,2.5f), gold.transform.position.z), Quaternion.identity); //동전
         Instantiate(gold, new Vector3(this.transform.position.x+Random.Range(-2.5f,2.5f), this.transform.position.y+Random.Range(-2.5f,2.5f), gold.transform.position.z), Quaternion.identity); //동전
         Instantiate(gold, new Vector3(this.transform.position.x+Random.Range(-2.5f,2.5f), this.transform.position.y+Random.Range(-2.5f,2.5f), gold.transform.position.z), Quaternion.identity); //동전
         Instantiate(gold, new Vector3(this.transform.position.x+Random.Range(-2.5f,2.5f), this.transform.position.y+Random.Range(-2.5f,2.5f), gold.transform.position.z), Quaternion.identity); //동전
         Instantiate(gold, new Vector3(this.transform.position.x+Random.Range(-2.5f,2.5f), this.transform.position.y+Random.Range(-2.5f,2.5f), gold.transform.position.z), Quaternion.identity); //동전
         Instantiate(gold, new Vector3(this.transform.position.x+Random.Range(-2.5f,2.5f), this.transform.position.y+Random.Range(-2.5f,2.5f), gold.transform.position.z), Quaternion.identity); //동전
         Instantiate(gold, new Vector3(this.transform.position.x+Random.Range(-2.5f,2.5f), this.transform.position.y+Random.Range(-2.5f,2.5f), gold.transform.position.z), Quaternion.identity); //동전
         Instantiate(gold, new Vector3(this.transform.position.x+Random.Range(-2.5f,2.5f), this.transform.position.y+Random.Range(-2.5f,2.5f), gold.transform.position.z), Quaternion.identity); //동전
         Instantiate(gold, new Vector3(this.transform.position.x+Random.Range(-2.5f,2.5f), this.transform.position.y+Random.Range(-2.5f,2.5f), gold.transform.position.z), Quaternion.identity); //동전

    }
    IEnumerator dash()
    {
        if (canevent)
        {
            cananotdetect = true; //캐릭터 감지 off
            ismove = false;
            audiosource.PlayOneShot(readysound,3f);
            yield return new WaitForSeconds(1f);
            audiosource.PlayOneShot(dashsound,4f);
            if(isdead==false) 
                ismove = true;
            speed *= 20;
            if (anim.GetBool("israge") == true) 
                yield return new WaitForSeconds(0.25f);
            else
                yield return new WaitForSeconds(0.5f);
            speed /= 25;
            cananotdetect = false; //캐릭터 감지 on
        }
    }
    IEnumerator pattern()
    {
        while (true)
        {
            int a;
            yield return new WaitForSeconds(1f);
            if (anim.GetBool("israge") == true)
            {
                if(lv.wave>13) 
                    a = Random.Range(0,3);
                else
                    a = Random.Range(0,5);
            }
            else
            {
                if(lv.wave>13)
                    a = Random.Range(0, 5);
                else
                    a = Random.Range(0,7);
            }
            if (a == 0)
            {
                a = Random.Range(0, 5);
                if(a==0||a==1||a==2)//5분의3
                {
                    StartCoroutine(dash());
                    yield return new WaitUntil(() => cananotdetect == false);
                }
                else//5분의2
                {
                    StartCoroutine(dummyspawn());
                    yield return new WaitUntil(() => ismove == true);
                }
            }
        }
    }

    IEnumerator dummyspawn()
    {
        if (canevent)
        {
            ismove = false;
            audiosource.PlayOneShot(spawnsound,5f);
            yield return new WaitForSeconds(1f);
            Instantiate(dummy, new Vector3(transform.position.x + 2, transform.position.y, transform.position.z),
                Quaternion.identity); //오른쪽
            Instantiate(dummy, new Vector3(transform.position.x - 2, transform.position.y, transform.position.z),
                Quaternion.identity); //왼쪽
            Instantiate(dummy, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z),
                Quaternion.identity); //위쪽
            Instantiate(dummy, new Vector3(transform.position.x, transform.position.y - 2, transform.position.z),
                Quaternion.identity); //아래쪽
            if (anim.GetBool("israge") == true)
            {
                Instantiate(dummy,
                    new Vector3(transform.position.x + 2, transform.position.y + 2, transform.position.z),
                    Quaternion.identity); //오른쪽위
                Instantiate(dummy,
                    new Vector3(transform.position.x - 2, transform.position.y - 2, transform.position.z),
                    Quaternion.identity); //왼쪽아래
                Instantiate(dummy,
                    new Vector3(transform.position.x + 2, transform.position.y - 2, transform.position.z),
                    Quaternion.identity); //오른쪽아래
                Instantiate(dummy,
                    new Vector3(transform.position.x - 2, transform.position.y - 2, transform.position.z),
                    Quaternion.identity); //왼쪽아래
            }

            yield return new WaitForSeconds(1.5f);
            if (isdead == false) 
                ismove = true;
        }
    }
}
