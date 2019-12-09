using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Experimental.XR;

public class ObjectPoolingManager : MonoBehaviour //MainCamera에 들어감
{
    public static ObjectPoolingManager instance;
    public GameObject m_goPrefab = null;//생성할 오브젝트
    public Queue<GameObject> m_queue= new Queue<GameObject>();//게임오브젝트를 담을 큐
    void Start()
    {
        instance = this;
        for (int i = 0; i < 500; i++)//게임오브젝트 500개를 미리 생성해 놓음
        {
            GameObject t_object = Instantiate(m_goPrefab, Vector3.zero, Quaternion.identity);
            m_queue.Enqueue(t_object);
            t_object.SetActive(false);
        }
    }

    public void InsertQueue(GameObject p_object) //생성한 객체를 반납하는 함수
    {
        m_queue.Enqueue(p_object);
        p_object.SetActive(false);
    }

    public GameObject GetQueue() //큐에서 객체를 꺼내오는 함수
    {
        GameObject t_object = m_queue.Dequeue();
        t_object.SetActive(true);
        return t_object;
    }
}
