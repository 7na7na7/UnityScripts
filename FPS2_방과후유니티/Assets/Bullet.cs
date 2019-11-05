using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{//화살이 중력을 받으면서 날아가겠다
    Rigidbody rb;
    int speed = 30;
    //총알에 닿으면 파괴하겠다
    private void OnCollisionEnter(Collision collision)
    {
        //나죽고
        Destroy(gameObject);
        //에너미라면 너죽고
        if (collision.gameObject.name.Contains("Enemy"))
        {
            //컴포넌트 갖고오기
            Agent agent= collision.gameObject.GetComponent<Agent>();
            //체력을 1감소
            agent.currentHP -= 1;
            //슬라이더에 체력넣기
            agent.slider.value = agent.currentHP;
            //체력이 0이면 파괴
            if (agent.currentHP == 0)
            {
                Destroy(collision.gameObject);

            }
        }

        
    }
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        //등속도 운동= 방향*크기(속력)
        rb.velocity = transform.forward * speed;
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = rb.velocity;
    }
}
