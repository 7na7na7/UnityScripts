using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class zombieclass : MonoBehaviour
{
    public float fullattack = 0, lessattack = 0;
    public int coinpercent = 75;
    protected bananagun gun;
    protected Level level;
    protected GameOver gameover;
    protected Move1 player;
    public float levelpower;
    public GameObject heart;
    public GameObject hp, hpframe;
    public float speed = 1.0f;
    public GameObject critical;
    public GameObject gold;

    private void Awake()
    {
        gun = FindObjectOfType<bananagun>();
        level = FindObjectOfType<Level>();
        gameover = FindObjectOfType<GameOver>();
        player = FindObjectOfType<Move1>();
        for (int i = 0; i < (level.wave - 1) / 5; i++)
        {
            hp.transform.localScale += new Vector3(levelpower, 0, 0);
            hpframe.transform.localScale += new Vector3(levelpower, 0, 0);
            hp.transform.Translate(-1 * levelpower * 0.25f, 0, 0);
            hpframe.transform.Translate(-1 * levelpower * 0.25f, 0, 0);
            speed += 0.2f;
        }
    }

    private void Update()
    {
        if (hp.transform.localScale.x <= 0)
        {
            gameover.zombiecount += 1;
            level.zombiecount[level.i]--;
            level.currentzombie--;
        }
    }

    protected virtual void OnTriggerEnter2D(Collider2D other)//가상 함수를 사용하면 override를 사용하여 재정의할 수 있게 된다.
    {
        if (other.CompareTag("banana") || other.CompareTag("knife"))
        {
            if (gun.weapon == "sniper")
                hp.transform.localScale += new Vector3(-1 * player.sniperdamage, 0, 0);
            else if (gun.weapon == "knife")
                hp.transform.localScale += new Vector3(-1 * player.knifedamage, 0, 0);
            else if (gun.weapon == "cowgun")
                hp.transform.localScale += new Vector3(-1 * player.cowgundamage, 0, 0);
            else if (gun.weapon == "sniper2")
                hp.transform.localScale += new Vector3(-1 * player.sniper2damage, 0, 0);
            else
                hp.transform.localScale += new Vector3(-1 * player.pistoldamage, 0, 0);
            int r = Random.Range(0, player.criticalpercent); //치명타확률계산
            if (r == 0)
            {
                //치명타시 체력회복 어빌리티
                player.slider.value += player.criticalheal;
                
                Instantiate(critical,
                    new Vector3(transform.position.x + 0.1f, transform.position.y + 0.5f, transform.position.z),
                    Quaternion.identity);
                if (gun.weapon == "sniper")
                    hp.transform.localScale += new Vector3(-1 * player.sniperdamage, 0, 0);
                else if (gun.weapon == "knife")
                    hp.transform.localScale += new Vector3(-1 * player.knifedamage, 0, 0);
                else if (gun.weapon == "cowgun")
                    hp.transform.localScale += new Vector3(-1 * player.cowgundamage, 0, 0);
                else if (gun.weapon == "sniper2")
                    hp.transform.localScale += new Vector3(-1 * player.sniper2damage, 0, 0);
                else
                    hp.transform.localScale += new Vector3(-1 * player.pistoldamage, 0, 0);
                hp.transform.localScale += new Vector3(-1 * player.criticaldamage, 0, 0);
            }

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
                hp.transform.localScale += new Vector3(-1 * fullattack, 0, 0);
            }

            if (player.slider.value <= player.slider.maxValue * 0.3f) //현재hp의30%이하일때
            {
                hp.transform.localScale += new Vector3(-1 * lessattack, 0, 0);
            }

            if (player.slider.maxValue - player.slider.value == 0) //풀피일떄
            {
                hp.transform.localScale += new Vector3(-1 * fullattack, 0, 0);
            }

            if (player.slider.value <= player.slider.maxValue * 0.3f) //현재hp의30%이하일때
            {
                hp.transform.localScale += new Vector3(-1 * lessattack, 0, 0);
            }
            if (hp.transform.localScale.x <= 0)
            {
                int a = Random.Range(0, player.heartpercent);
                if (a == 0)
                    Instantiate(heart,
                        new Vector3(this.transform.position.x, this.transform.position.y, heart.transform.position.z),
                        Quaternion.identity);
                
                string[] str = this.gameObject.name.Split('_');
                
                if (str[0]!="dummy")
                {
                    int b = Random.Range(0, 100);
                    if (0 <= b && b <= coinpercent)
                    {
                        Instantiate(gold,
                            new Vector3(this.transform.position.x, this.transform.position.y,
                                gold.transform.position.z),
                            Quaternion.identity); //동화생성
                    }
                }
            }
        }
    }
}
