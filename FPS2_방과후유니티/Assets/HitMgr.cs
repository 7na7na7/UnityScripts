using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitMgr : MonoBehaviour
{
    // 타격을 입으면 붉은화면이 0.1초간 깜박거린다
    //이미지 히트
    public GameObject imageHit;
    //싱글톤-딱1개인것, 플레이어, 무기, 보스
    public static HitMgr instance;
    private void Awake()
    {
        HitMgr.instance = this;
    }

    public void RedHit()
    {
        //코루틴시작
        StopCoroutine("RedHitAuto");
        StartCoroutine(RedHitAuto());
    }

    IEnumerator RedHitAuto()
    {
        imageHit.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        imageHit.SetActive(false);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
