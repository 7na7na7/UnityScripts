using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class cube : MonoBehaviour //큐브에 들어가는 스크립트
{
    private Rigidbody m_myrigid = null;

    private void OnEnable() //오브젝트가 활성화될 때마다(이 오브젝트가 생성될 때)
    {
        //transform.localScale=new Vector3(transform.localScale.x+Random.Range(-0.9f,20.0f),transform.localScale.y+Random.Range(-0.9f,20.0f),transform.localScale.z+Random.Range(-0.9f,20.0f)); //역시 랜덤은 정말 예뻐
        if (m_myrigid == null)
        {
            m_myrigid = GetComponent<Rigidbody>();
        }
        m_myrigid.velocity=Vector3.zero;
        m_myrigid.AddExplosionForce(1000,transform.position,1f);
        StartCoroutine(Destroycube());
    }

    IEnumerator Destroycube()
    {
        yield return new WaitForSeconds(1);
        ObjectPoolingManager.instance.InsertQueue(gameObject); //삭제하는 대신 큐에 반납
    }
}
