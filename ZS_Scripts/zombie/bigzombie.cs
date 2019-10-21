using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigzombie : zombieclass
{
    private zombieclass zombieclass;
    private GameObject obj;
    private Transform target;

    private void Start()
    {
        zombieclass = FindObjectOfType<zombieclass>();
        obj = this.gameObject;
        if (level.currentzombie > level.zombiecount[level.i])
            Destroy(obj);
        else
            level.currentzombie++;
    }

    void LateUpdate()
    {
        target = player.transform;
        Vector3 dir = target.position - transform.position; //사이의 거리를 구함
        dir.Normalize();
        transform.position += dir * speed * Time.deltaTime;
        if (hp.transform.localScale.x <= 0)
        {
            Destroy(obj);
        }
    }

    protected override void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("banana") || other.CompareTag("knife"))
        {
            if (gun.weapon == "sniper")
                hp.transform.localScale += new Vector3(-1 * player.sniperdamage * 0.4f, 0, 0);
            else if (gun.weapon == "knife")
                hp.transform.localScale += new Vector3(-1 * player.knifedamage * 0.4f, 0, 0);
            else if (gun.weapon == "sniper2")
                hp.transform.localScale += new Vector3(-1 * player.sniper2damage * 0.4f, 0, 0);
            else
                hp.transform.localScale += new Vector3(-1 * player.pistoldamage * 0.4f, 0, 0);
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
        }

        if (hp.transform.localScale.x <= 0)
        {
            int a = Random.Range(0, player.heartpercent);
            if (a == 0)
                Instantiate(heart,
                    new Vector3(this.transform.position.x, this.transform.position.y, heart.transform.position.z),
                    Quaternion.identity);

            string[] str = this.gameObject.name.Split('_');

            if (str[0] != "dummy")
            {
                int b = Random.Range(0, 100);
                if (0 <= b && b <= coinpercent)
                {
                    Instantiate(gold,
                        new Vector3(this.transform.position.x, this.transform.position.y,
                            gold.transform.position.z),
                        Quaternion.identity); //돈생성
                }
            }
        }
    }
}