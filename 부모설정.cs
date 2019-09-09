using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 부모설정 : MonoBehaviour
{
    public Transform parent;
    public GameObject child;
    
    void Start()
    {
        gameObject.transform.parent.GetComponent<찾고자하는 변수가 존재하는 스크립트명>().변수명
        save save = GameObject.Find("save").GetComponent<save>(); //참조
        GameObject Object = Instantiate(child, parent);//lockimg생성과 동시에 parent를 부모로 설정
        Object.transform.position = new Vector3(parent.transform.position.x, parent.transform.position.y, parent.transform.position.z); //부모와 포지션을 같게 설정
        child.transform.SetParent(parent.transform);//child의 부모를 parent로 설정
    }
}
