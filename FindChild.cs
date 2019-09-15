using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindChild : MonoBehaviour
{
    void Start()
    {
        Debug.Log(transform.GetChild(0).name); //인덱스로 접근하는 방법
        Debug.Log(transform.Find("panel").name); //오브젝트의 이름으로 접근하는 방법
        GameObject child = transform.Find("panel").gameObject;
        child.SetActive(false);
    }
}
