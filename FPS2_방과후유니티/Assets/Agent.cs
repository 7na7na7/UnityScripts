using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Agent : MonoBehaviour
{
    //타겟을 설정
    public GameObject target;
    NavMeshAgent agent;
    public Animator anim;

    //체력바를 표시하겠다. 총알에 맞으면 체력 1 감소
    //최대체력
    public float maxHP=2.0f;
    //현재체력
    public float currentHP;
    //슬라이드UI
    public Slider slider;

    //상태전환 : Run : 타겟으로 이동, 거리가 2m이내라면 Attack으로 전환
    //상태전환 : Attack : 타겟을 공격, 거리가 2m초과하면 Run으로 전환
    public enum State
    {
        Run,
        Attack
    }
    public State state;


    void Start()
    {
        agent=GetComponent<NavMeshAgent>();
        //현재체력은 최대체력으로 시작하겠다
        currentHP = maxHP;
        slider.maxValue = maxHP;
        slider.value = currentHP;
        state = State.Run;
    }

    // Update is called once per frame
    void Update()
    {
        target = GameObject.Find("Player");
        agent.destination = target.transform.position;
        if (state == State.Run)
        {
            UpdateRun();
        }
        else
        {
            UpdateAttack();
        }
    }

    private void UpdateAttack()
    {
        agent.speed = 0;
    }

    public float attackDist;
    float dist;
    private void UpdateRun()
    {
        //속도
        agent.speed = 3.5f;
        //거리가 2m이내면 공격전환
        dist = Vector3.Distance(transform.position, target.transform.position);
        if (dist <= attackDist)
        {
            state = State.Attack;
            anim.SetTrigger("Attack");
        }
    }
}
