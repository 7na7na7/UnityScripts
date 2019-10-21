using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    private Transform parent;
    public float delay = 0.5f;
    void Start()
    {
        parent = GameObject.Find("BG").GetComponent<Transform>();
        this.transform.SetParent(parent.transform);//child의 부모를 parent로 설정
        Destroy(this.gameObject,delay);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("object"))
            Destroy(this.gameObject);
    }
}
