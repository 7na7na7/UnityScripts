using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Missile : MonoBehaviour
{
    private Rigidbody2D rigid;
    private Transform target;

    public float speed; //최고속도
    private float currentSpeed;
    public LayerMask layer;
    //public ParticleSystem particle;

    void SearchEnemy()
    {
        //미사일 기준으로 반경 100이내의 layer를 탐색하여 cols에 넣음
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 100f, layer);

        if (cols.Length > 0)
        {
            //타겟 트랜스폼에 타겟들 중 하나를 랜덤으로 넣음
            target = cols[Random.Range(0, cols.Length)].transform;
        }
    }

    IEnumerator LaunchDelay()
    {
        yield return new WaitUntil(()=>rigid.velocity.y<0f);
        yield return new WaitForSeconds(0.1f);
        SearchEnemy();
        //particle.Play();
        
        //시간지나면 자동으로 삭제
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        StartCoroutine(LaunchDelay());
    }

    void Update()
    {
        if (target != null)
        {
            if (currentSpeed <= speed)
                currentSpeed += speed * Time.deltaTime;

            transform.position += transform.up * currentSpeed * Time.deltaTime;

            Vector3 dir = (target.position - transform.position).normalized; //normalized로 방향만 나오게
            transform.up = Vector3.Lerp(transform.up, dir, 0.25f); //천천히 타겟을 향해 날아감
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.transform.CompareTag("Enemy"))
        {
            print("a");
            //Enemy에 닿으면 Enemy삭제, 미사일도 삭제
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
