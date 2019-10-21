using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;
public class ability : MonoBehaviour
{
    public GameObject abil1, abil2;
    public string abilityname;
    private Move1 player;
    private int a;
    public int star = 1;
    public int[] abilLV;
    public Text name;
    public string type;
    public Sprite[] img; //여기 스프라이트 넣고
    private Button btn; //여기 버튼 넣은 다음에
    private Image sourceimg;

    private void Awake()
    {
        player = FindObjectOfType<Move1>();
    }
    public void setability()
    {
        sourceimg = GetComponent<Image>();
        Debug.Log("셋어빌리티!!!");
        star = 0;
        a = 0;
        for (int i = 0; i < player.level; i++)
        {
            a += abilLV[i];
        }
        int r = UnityEngine.Random.Range(0, a);
        btn = GetComponent<Button>();
        btn.gameObject.GetComponent<Image>().sprite = img[r];
        type = sourceimg.sprite.name;
        string[] split = type.Split('_');
        if (split[0] == "one") //몇성인지 star에 저장
            star = 1;
        else if (split[0] == "two")
            star = 2;
        else if (split[0] == "three")
            star = 3;
        else if (split[0] == "four")
            star = 4;
        
            if (split[1] == "criticaldamage")
            abilityname = "치명타 데미지 증가";
        else if (split[1] == "criticalpercent")
            abilityname = "치명타 확률 증가";
        else if (split[1] == "dashplus")
            abilityname = "이동 속도 증가";
        else if (split[1] == "hpplus")
            abilityname = "회복량 증가";
        else if (split[1] == "hppercent")
            abilityname = "하트 획득 확률 증가";
            else if (split[1] == "hpslider")
            abilityname = "최대 체력 증가";
        else if (split[1] == "staminaheal")
            abilityname = "스테미나 회복량 증가";
        else if (split[1] == "staminaplus")
            abilityname = "최대 스테미나 증가";
        else if (split[1] == "attackplus")
            abilityname = "공격력 증가";//////////////////2
        else if (split[1] == "dashtime")
            abilityname = "대쉬 시간 증가";
        else if (split[1] == "fastdash")
            abilityname = "대쉬 속도 증가";
        else if (split[1] == "fullhpattack")
            abilityname = "풀피에서 공격력 증가";
        else if (split[1] == "fullhpspeed")
            abilityname = "풀피에서 공속 증가";
        else if (split[1] == "losehpattack")
            abilityname = "딸피에서 공격력 증가";
        else if (split[1] == "losehpspeed")
            abilityname = "딸피에서 공속 증가";
        else if (split[1] == "bossfight")
            abilityname = "보스전에서 강해짐";//////////////3
        else if (split[1] == "criticalheal")
            abilityname = "치명타 시 회복";
        else if (split[1] == "magnet")
            abilityname = "동전들을 끌어옴";
        else if (split[1] == "standheal")
            abilityname = "가만히 있으면 체력 회복";
        else if (split[1] == "changeweapon")
            abilityname = "현재 등급 이상의 무기로 변환\n(강화 유지)";//////////////4
        //else if (split[1] == "revival")
            //abilityname = "한 번 부활할 수 있음";
            
            ability abil1 = this.abil1.GetComponent<ability>();
            ability abil2 = this.abil2.GetComponent<ability>();
            while (abil2.abilityname == abil1.abilityname)
            {
                abil2.setability();
            }
            name.text = abilityname;
    }
}