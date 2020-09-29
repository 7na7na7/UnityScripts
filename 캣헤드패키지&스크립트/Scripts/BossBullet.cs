using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    public float speed;
    void Start()
    {
    
    }

    public void Set(GameObject target)
    {
        Vector2 dir = target.transform.position - transform.position;
        dir.Normalize();
        GetComponent<Rigidbody2D>().velocity = dir*speed;
    }
   
    void Update()
    {
        //transform.Translate(speed*Time.deltaTime,0,0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Wall")||other.CompareTag("wallsu")||other.CompareTag("Container"))
            Destroy(gameObject);
        if (other.CompareTag("Player"))
            {
                if (!other.GetComponent<PlayerMove>().isSuper)
                    Destroy(gameObject);
            }
    }
}
