using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMgr : MonoBehaviour
{
    // 일정시간마다 에너미를 생성
    //생성시간
    public float creatTime = 2.0f;
    //경과시간
    float currentTime;
    //에너미공장
    public GameObject enemyFactory;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > creatTime)
        {
            //공장에서 만들고
            GameObject enemy= Instantiate(enemyFactory);
            //위치
            enemy.transform.position = transform.position;
            //경과시간 초기화
            currentTime = 0;
        }
        
    }
}
