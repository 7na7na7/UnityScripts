using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class 웨이브시스템 : MonoBehaviour
{
    public Text wavetext, lefttext;
    public GameObject nextwave; //"Enter to Next Wave"라는 텍스트를 게임오브젝트로 넣어준다.
    public int[] zombiecount;
    
    private bool once = false; //맨 처음 스폰을 시작하도록 해주는 bool변수, 한번만 쓰임
    private int currentzombie = 0;
    private int i = 0; //for문용 변수
    private int wave = 1;
   
    void Start()
    {
        StartCoroutine(spawn()); //코루틴 실행
    }

    private void Update()
    {
        lefttext.text = "Left Zombie : " + currentzombie;
        wavetext.text = "Wave " + wave;
    }

    IEnumerator spawn()
    {
        for (i = 0; i < zombiecount.Length; i++) //끝나고 i++
        {
            if(once==false)
            {
                once = true;
                yield return new WaitForSeconds(0.001f); //내가 왜넣은건진 모르겠당 ㅎ
            }
            yield return new WaitUntil(() => zombiecount[i] <= 0); //zombiecount[i]가 0이 될 때까지 기다림(현재 웨이브의 좀비가 다 죽을 때까지)
            currentzombie = 0; //현재좀비수 초기화
            if(wave>=1)
            {
                nextwave.SetActive(true); //Enter to Next Wave라는 텍스트가 보이게 된다.
                yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Return)); //엔터입력까지 딜레이
                nextwave.SetActive(false); //다시 텍스트가 안 보이게 된다.
            }
            wave++;
        }
    }
}