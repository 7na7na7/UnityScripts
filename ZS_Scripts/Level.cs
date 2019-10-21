using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Level : MonoBehaviour
{
    public float offset = 6f;
    private GoldManager gold;
    private save save;
    private GameOver gameover;
    private bool once = false;
    public GameObject abil1, abil2,reroll;
    public GameObject nextwave;
    public Text goldtext;
    public bool isnext = false;
    public bool canpause = true;
    public Canvas shop;
    private int bossNumber = 0;
    public GameObject[] Boss;
    public int savedcount;
    public int currentzombie = 0;
    public int i = 0;
    private Move1 player;
    public Text wavetext, lefttext;
    public bool isdelay = false;
    //public Transform parent;
    public int wave = 1;
    public int[] zombiecount;
    public float waitTime = 10;
    public GameObject spawner;
    void Start()
    {
        save = FindObjectOfType<save>();
        gameover = FindObjectOfType<GameOver>();
        gold = FindObjectOfType<GoldManager>();
        gold.gold = 0;
        player = GameObject.Find("player").GetComponent<Move1>();
        Instantiate(spawner, new Vector3(Random.Range(player.min.position.x-offset, player.max.position.x+offset), player.min.position.y-offset, 0),Quaternion.identity); //아래
        Instantiate(spawner, new Vector3(Random.Range(player.min.position.x-offset, player.max.position.x+offset), player.max.position.y+offset, 0),Quaternion.identity); //위
        Instantiate(spawner, new Vector3( player.max.position.x+offset,Random.Range(player.min.position.y-offset,player.max.position.y+offset), 0),Quaternion.identity); //오른
        Instantiate(spawner, new Vector3( player.min.position.x-offset,Random.Range(player.min.position.y-offset,player.max.position.y+offset), 0),Quaternion.identity); //왼
        StartCoroutine(spawncoroutine());
        StartCoroutine(spawn());
    }

    private void Update()
    {
        goldtext.text = gold.gold.ToString() + " " + "Gold";
        //lefttext.text = "Left Zombie : " + zombiecount[i];
        lefttext.text = "Left Zombie : " + currentzombie;
        wavetext.text = "Wave " + wave;
    }

    IEnumerator spawncoroutine()
    {
        while (true)
        {
            int a = Random.Range(0, 4);
            if (a == 0)
                Instantiate(spawner,
                    new Vector3(Random.Range(player.min.position.x - offset, player.max.position.x +offset),
                        player.min.position.y - offset, 0), Quaternion.identity); //아래
            else if (a == 1)
                Instantiate(spawner,
                    new Vector3(Random.Range(player.min.position.x - offset, player.max.position.x + offset),
                        player.max.position.y + offset, 0), Quaternion.identity); //위
            else if (a == 2)
                Instantiate(spawner,
                    new Vector3(player.max.position.x + offset,
                        Random.Range(player.min.position.y -offset, player.max.position.y + offset), 0),
                    Quaternion.identity); //오른
            else
                Instantiate(spawner,
                    new Vector3(player.min.position.x - offset,
                        Random.Range(player.min.position.y - offset, player.max.position.y + offset), 0),
                    Quaternion.identity); //왼
            //spawner.transform.SetParent(parent.transform);

            yield return new WaitForSeconds(waitTime);
        } //시간따라 스포너증가
    }

    IEnumerator spawn()
    {
        for (i = 0; i < zombiecount.Length; i++) //끝나고 i++
        {
            if(once==false)
            {
                once = true;
                yield return new WaitForSeconds(0.00001f);
            Time.timeScale = 0; //시간 멈추고 상점소환
            gameover.canexit = false; //esc못하게
            canpause = false; //pause못하게
            shop.gameObject.SetActive(true); //상점소환
            reroll.SetActive(true);
            this.abil1.SetActive(true);
            this.abil2.SetActive(true);
            ability abil1 = this.abil1.GetComponent<ability>();
            ability abil2 = this.abil2.GetComponent<ability>();
            abil1.setability();
            abil2.setability();
            yield return new WaitUntil(() => isnext == true); //isnext가 true가 될때까지 딜레이
            gameover.canexit = true; //esc할수있게
            canpause = true; //pause할수있게
            isnext = false;
            reroll.SetActive(false);
            this.abil1.SetActive(false);
            this.abil2.SetActive(false);
        }



        savedcount = zombiecount[i];
            if (wave % 5 == 0) //웨이브5번째마다 보스출현
            {
                Instantiate(Boss[bossNumber],new Vector3(transform.position.x,transform.position.y+25,transform.position.z),Quaternion.identity);
                if (wave % 20 == 0||wave%25==0)
                {
                    Instantiate(Boss[bossNumber],new Vector3(transform.position.x,transform.position.y+25,transform.position.z),Quaternion.identity);
                }
                bossNumber++;
                player.moveforce += player.bossstrong;
            }
            yield return new WaitUntil(() => zombiecount[i] <= 0);
            isdelay = true;
            currentzombie = 0; //현재좀비수 초기화
            if(wave>=1)
            {
                nextwave.SetActive(true);
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return)); //엔터입력까지 딜레이
                nextwave.SetActive(false);
                Time.timeScale = 0; //시간 멈추고 상점소환
                gameover.canexit = false; //esc못하게
                canpause = false;//pause못하게
                shop.gameObject.SetActive(true); //상점소환
                if (wave % 3 == 0) //3스테이지마다 어빌리티 획득
                {
                    reroll.SetActive(true);
                    this.abil1.SetActive(true);
                    this.abil2.SetActive(true);
                    ability abil1 = this.abil1.GetComponent<ability>();
                    ability abil2 = this.abil2.GetComponent<ability>();
                    abil1.setability();
                    abil2.setability();
                }
                yield return new WaitUntil(() => isnext == true); //isnext가 true가 될때까지 딜레이
                gameover.canexit = true; //esc할수있게
                canpause = true;//pause할수있게
                isnext = false;
                reroll.SetActive(false);
                this.abil1.SetActive(false);
                this.abil2.SetActive(false);
            }
            player.audiosource.pitch += 0.035f;
            wave++;
            save.savedwave = wave;
            save.savedkill = gameover.zombiecount;
            Debug.Log("웨이브 "+ wave);
            isdelay = false;
        }
    }
}
