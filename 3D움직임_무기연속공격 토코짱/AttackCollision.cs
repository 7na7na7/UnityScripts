using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollision : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    void OnTriggerEnter(Collider other)
    {
        //Enemy의 TakeDamage함수 발동
        if (other.CompareTag("Enemy"))
        {
            other.GetComponent<EnemyCtrl>().TakeDamage(10);
        }
    }

    IEnumerator AutoDisable()
    {
        //0.1초 후 비활성화
        yield return new WaitForSeconds(0.1f);
        gameObject.SetActive(false);
    }
}
