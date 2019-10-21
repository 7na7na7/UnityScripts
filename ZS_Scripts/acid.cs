using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acid : MonoBehaviour
{
    private Level lv;
    private Move1 player;
    private GameObject obj;
    private Transform parent;
    public float speed;
    private Transform target;
    private void Start()
    {
        lv = FindObjectOfType<Level>();
        obj = this.gameObject;
        Destroy(obj, 5f);
        parent = GameObject.Find("BG").GetComponent<Transform>();
        this.transform.SetParent(parent.transform);//child의 부모를 parent로 설정
        
        // 타겟 방향으로 회전함
        Move1 player = GameObject.Find("player").GetComponent<Move1>();
        target = player.transform;
        Vector3 dir = target.position - transform.position; //사이의 거리를 구함
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        for (int i = 0; i < lv.wave / 5; i++) //일단 보스강화, 나중에 없애야지
        {
            speed += speed * 0.2f;
        }
    }
    void Update()
    {
        Move1 player = GameObject.Find("player").GetComponent<Move1>();
        target = player.transform;
        Vector3 dir = target.position - transform.position; //사이의 거리를 구함
        transform.Translate(Vector3.right*speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Move1 player = GameObject.Find("player").GetComponent<Move1>();
            if(player.isdamaged==false) 
                Destroy(obj);
        }
        if(other.CompareTag("object")||other.CompareTag("knife"))
        {
            Destroy(obj);
        }
    }
}
