using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class button : MonoBehaviour
{
    private Move1 player;
    private magnet mag;
    private bananagun gun;
    private zombieclass zombieclass;
    public int enhancesaving = 20;
    public GameObject rerollobj;
    public GameObject abil1, abil2;
    public GameObject lackobj;
    public Text leveltext,foodbtn,enhancebtn;
    public int levelcount = 20;
    public int enhancecount=15;
    private int foodcount = 5;
    private int a;
    private int currentweapon = 0;
    public Canvas canvas;
    private GoldManager gold;
    private Level lv;
    private void Start()
    {
        player = FindObjectOfType<Move1>();
        mag = FindObjectOfType<magnet>();
        gun = FindObjectOfType<bananagun>();
        zombieclass = FindObjectOfType<zombieclass>();
        gold = FindObjectOfType<GoldManager>();
        lv = FindObjectOfType<Level>();
        leveltext.text = "레벨 업 - " + levelcount + "G";
        foodbtn.text = "체력 회복 - " + foodcount + "G";
        enhancebtn.text = "무기 강화 - " + enhancecount + "G";
    }

    public void enhance()
    {
        if (enhancecount<159)
        {
            if (gold.gold >= enhancecount)
            {
                gold.gold -= enhancecount;
                enhancecount += enhancesaving;
                enhancesaving += 15;
                player.shotdelaycount++;
                player.damagecount++;
                enhancebtn.text = "무기 강화 - " + enhancecount + "G";
                if (enhancecount>159) //160보다 높아지면 최대레벨로
                    enhancebtn.text = "최대 레벨입니다.";
                //스페셜강화효과 넣기
            }
            else
            {
                goldlack();
            }
        }
    }
    

    public void gatcha()
    {
        if (gold.gold >= 20)
        {
            gold.gold -= 20;
            while (true)
            {
                if(player.level==1) 
                    a = Random.Range(0, 4);
                else if(player.level==2) 
                    a = Random.Range(0, 7);
                else if(player.level==3) 
                    a = Random.Range(0, 7);
                else if(player.level==4) 
                    a = Random.Range(0, 7);
                if (currentweapon != a)
                {
                    currentweapon = a;
                    break;
                }
            }
            player.weaponselect(a);
        }
        else
        {
            goldlack();
        }
    }
    public void heal()
    {
        if (gold.gold >= foodcount)
        {
            gold.gold -= foodcount;
            foodcount += 7;
            player.slider.value += 20;
            player.audiosource.PlayOneShot(player.healsound, 0.7f);
            foodbtn.text = "체력 회복 - " + foodcount + "G";
        }
        else
        {
            goldlack();
        }
    }

    public void levelup()
    {
        if (player.level != 4)
        {
            if (gold.gold >= levelcount)
            {
                gold.gold -= levelcount;
                player.level++;
                levelcount *= 2;
                leveltext.text = "레벨 업 - " + levelcount + "G";
                if (player.level == 4)
                    leveltext.text = "최대 레벨입니다.";
            }
            else
            {
                goldlack();
            }
        }
    }
    public void set()
    {
        Time.timeScale = 1;
        lv.isnext = true;
        canvas.gameObject.SetActive(false);
    }

    public void reroll()
    {
        if (gold.gold >= 10)
        {
            ability abil1 = this.abil1.GetComponent<ability>();
            ability abil2 = this.abil2.GetComponent<ability>();
            gold.gold -= 10;
            abil1.setability();
            abil2.setability();
        }
        else
        {
            goldlack();
        }
    }
    void goldlack()
    {
        Debug.Log("골드가 부족합니다.");
    }

    #region onestar
    public void healplus() //회복량증가
    {
        Debug.Log("회복량증가!");
        player.healvalue += 10;
    }
    public void hpplus() //최대 hp증가
    {
        Debug.Log("최대체력 증가!");
        player.slider.maxValue += 20;
        player.slider.value += 20;
    }
    public void criticalpercent() //치명타 확률 증가
    {
        Debug.Log("치명타 확률 증가!");
        player.criticalpercent -= 4;
    }
    public void criticaldeal() //치명타 데미지 증가
    {
        player.criticaldamage += 2;
        Debug.Log("치명타 데미지 증가!");
    }
    public void staminaplus() //최대 스테미너 증가
    {
        Debug.Log("최대 스테미너 증가!");
        player.stamina.maxValue += 30;
        player.stamina.value += 30;
    }
    public void staminaheal() //스테미너 회복속도 증가
    {
        Debug.Log("스테미너 회복속도 증가!");
        player.staminahealvalue += 0.05f;
    }
    public void fastmoving() //이동속도증가
    {
        Debug.Log("이동속도 증가!");
        player.moveforce += player.moveforce * 0.15f;
    }

    public void heartpercent() //하트획득확률증가
    {
        Debug.Log("하트 획득확률 증가!");
        player.heartpercent-=4;
    }
    #endregion

    #region twostar

    public void attackup()
    {
        Debug.Log("공격력 증가!");
        player.damagecount += 1;
    }
    public void dashtime()
    {
        Debug.Log("대쉬시간증가!");
        player.dashtime += player.dashtime * 0.5f;
    }
    public void dashspeed()
    {
        Debug.Log("대쉬스피드증가!");
        player.dashforce += player.dashforce * 0.75f;
    }
    public void fullattack()
    {
        Debug.Log("풀피에서공격력증가!");
        zombieclass.fullattack++;
    }
    public void fullspeed()
    {
        Debug.Log("풀피에서공속증가!"); 
        gun.fullspeed++;
    }
    public void lessattack()
    {
        Debug.Log("딸피에서공격력증가!");
        zombieclass.fullattack++;
    }
    public void lessspeed()
    {
        Debug.Log("딸피에서공속증가!");
        gun.lessspeed++;
    }
    #endregion

    #region threestar
    public void strongboss()
    {
        Debug.Log("보스 상대로 강해짐!");
        player.bossstrong += 2f;
    }
    public void standheal()
    {
        Debug.Log("가만히 있으면 체력회복!");
        player.standheal += 0.02f;
    }
    public void magnet()
    {
        Debug.Log("자석으로 골드 끌어옴!");
        player.goldspeed += 1f;
        mag.radiousup();
    }

    public void criticalheal()
    {
        Debug.Log("치명타 시 체력 회복!");
        player.criticalheal += 5;
    }
    #endregion

    #region fourstar
    public void weaponupgrade()
    {
        Debug.Log("현재 등급 이상의 무기로 변환\n(강화 유지)");
        while (true)
        {
            if(player.level==1) 
                a = Random.Range(0, 7);
            else if(player.level==2) 
                a = Random.Range(4, 7);
            else if(player.level==3) 
                a = Random.Range(0, 7);//
            else if(player.level==4) 
                a = Random.Range(0, 7);//
            if (currentweapon != a)
            {
                currentweapon = a;
                break;
            }
        }
        player.weaponupgrade(a);
    }
    #endregion
    
    public void ability1change()
    {
        ability abil1 = this.abil1.GetComponent<ability>();
        if(abil1.abilityname=="치명타 데미지 증가")
            criticaldeal();
        else if(abil1.abilityname=="치명타 확률 증가")
            criticalpercent();
        else if(abil1.abilityname=="이동 속도 증가")
            fastmoving();
        else if(abil1.abilityname=="회복량 증가")
            healplus();
        else if(abil1.abilityname=="하트 획득 확률 증가")
            heartpercent();
        else if(abil1.abilityname=="최대 체력 증가")
            hpplus();
        else if(abil1.abilityname=="스테미나 회복량 증가")
            staminaheal();
        else if(abil1.abilityname=="최대 스테미나 증가")
            staminaplus();
        else if (abil1.abilityname == "공격력 증가")////////2
            attackup();
        else if(abil1.abilityname=="대쉬 시간 증가")
            dashtime();
        else if(abil1.abilityname=="대쉬 속도 증가")
            dashspeed();
        else if(abil1.abilityname=="풀피에서 공격력 증가")
            fullattack();
        else if(abil1.abilityname=="풀피에서 공속 증가")
            fullspeed();
        else if(abil1.abilityname=="딸피에서 공격력 증가")
            lessattack();
        else if(abil1.abilityname=="딸피에서 공속 증가")
            lessspeed();
        else if(abil1.abilityname=="보스전에서 강해짐")///////3
            strongboss();
        else if (abil1.abilityname == "치명타 시 회복")
            criticalheal();
        else if(abil1.abilityname=="동전들을 끌어옴")
            magnet();
        else if(abil1.abilityname=="가만히 있으면 체력 회복")
            standheal();
        else if (abil1.abilityname == "현재 등급 이상의 무기로 변환\n(강화 유지)") /////4
            weaponupgrade();
        
        
        abil1.gameObject.SetActive(false);
        abil2.gameObject.SetActive(false);
        rerollobj.gameObject.SetActive(false);
    }
    public void ability2change()
    {
        ability abil2 = this.abil2.GetComponent<ability>();
       
        if(abil2.abilityname=="치명타 데미지 증가")
            criticaldeal();
        else if(abil2.abilityname=="치명타 확률 증가")
            criticalpercent();
        else if(abil2.abilityname=="이동 속도 증가")
            fastmoving();
        else if(abil2.abilityname=="회복량 증가")
            healplus();
        else if(abil2.abilityname=="하트 획득 확률 증가")
            heartpercent();
        else if(abil2.abilityname=="최대 체력 증가")
            hpplus();
        else if(abil2.abilityname=="스테미나 회복량 증가")
            staminaheal();
        else if(abil2.abilityname=="최대 스테미나 증가")
            staminaplus();
        else if (abil2.abilityname == "공격력 증가")////////2
            attackup();
        else if(abil2.abilityname=="대쉬 시간 증가")
            dashtime();
        else if(abil2.abilityname=="대쉬 속도 증가")
            dashspeed();
        else if(abil2.abilityname=="풀피에서 공격력 증가")
            fullattack();
        else if(abil2.abilityname=="풀피에서 공속 증가")
            fullspeed();
        else if(abil2.abilityname=="딸피에서 공격력 증가")
            lessattack();
        else if(abil2.abilityname=="딸피에서 공속 증가")
            lessspeed();
        else if(abil2.abilityname=="보스전에서 강해짐")///////3
            strongboss();
        else if (abil2.abilityname == "치명타 시 회복")
            criticalheal();
        else if(abil2.abilityname=="동전들을 끌어옴")
            magnet();
        else if(abil2.abilityname=="가만히 있으면 체력 회복")
            standheal();
        else if (abil2.abilityname == "현재 등급 이상의 무기로 변환\n(강화 유지)") /////4
            weaponupgrade();

        
        abil1.gameObject.SetActive(false);
        abil2.gameObject.SetActive(false);
        rerollobj.gameObject.SetActive(false);
    }
}
