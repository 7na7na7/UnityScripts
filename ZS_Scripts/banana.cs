using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class banana : MonoBehaviour
{
    private int snipercount = 0;
    private GameObject obj;
    private Transform parent;
    public float speed;
    private bananagun gun;
    private void Start()
    {
        gun = FindObjectOfType<bananagun>();
        obj = this.gameObject;
        parent = GameObject.Find("BG").GetComponent<Transform>();
        this.transform.SetParent(parent.transform);//child의 부모를 parent로 설정
        if (gun.weapon == "sniper")
        {
            Destroy(obj, 3f);
        }
        else if (gun.weapon == "shotgun"||gun.weapon=="shotgun2")
        {
            Destroy(obj, 0.4f);
        }
        else
        {
            Destroy(obj,1f);
        }
    }
    void Update()
    {
        transform.Translate(Vector3.right*Time.deltaTime*speed);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")&&!other.CompareTag("banana")&&!other.CompareTag("acid"))
        {
            if (gun.weapon != "sniper"&&gun.weapon!="sniper2")
            {
                if(other.CompareTag("zombie")||other.CompareTag("zombieking")) 
                        Destroy(obj);
            }
            else if(gun.weapon=="sniper")
            {
                snipercount++;
                if(snipercount>=6)
                    Destroy(obj);   
            }
            else if(gun.weapon=="sniper2")
            {
                snipercount++;
                if(snipercount>=10)
                    Destroy(obj);   
            }
        }

        if (other.CompareTag("object"))
        {
            Destroy(this.gameObject);
        }
    }
}
