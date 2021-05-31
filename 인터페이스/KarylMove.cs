using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KarylMove : MonoBehaviour
{
    void FixedUpdate()
    {
        transform.Translate(Input.GetAxisRaw("Horizontal")*Time.fixedDeltaTime*5,Input.GetAxisRaw("Vertical")*Time.fixedDeltaTime*5,0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        IDamage dmg = other.GetComponent<IDamage>();
        if (dmg != null) //IDamage인터페이스를 상속받은 오브젝트라면
        {
            dmg.Damage(10);
        }
    }
}
