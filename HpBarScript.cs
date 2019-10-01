using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpBarScript : MonoBehaviour
{
    [SerializeField] private GameObject m_goPrefab = null; //SerializeField를 사용했는데 그냥 public써도된다.
    List<Transform> m_objectList=new List<Transform>(); //몬스터 위치가 담긴 리스트 선언
    List<GameObject> m_hpBarList= new List<GameObject>(); //Hp바 리스트 선언

    private Camera m_cam = null;
    void Start()
    {
        m_cam=Camera.main; //Camera.main이란 MainCamera로 태그된 카메라를 말한다.

        GameObject[] t_objects = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < t_objects.Length; i++)
        {
            
            m_objectList.Add(t_objects[i].transform);
            //몬스터 위치에 HP바 프리팹 생성
            GameObject t_hpbar = Instantiate(m_goPrefab, t_objects[i].transform.position, Quaternion.identity,transform);
            //생성된 객체는 hp바 리스트에 추가
            m_hpBarList.Add(t_hpbar);
        }
    }
    
    void Update()
    {
        for (int i = 0; i < m_objectList.Count; i++)
        {
            //hp바가 몬스터 머리 위로 따라다니게 설정
            m_hpBarList[i].transform.position = 
                m_cam.WorldToScreenPoint(m_objectList[i].position+new Vector3(0,1.15f,0));
        }
    }
}
