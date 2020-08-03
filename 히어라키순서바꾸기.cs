using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 히어라키순서바꾸기 : MonoBehaviour
{
    void Start()
    {
        transform.SetAsFirstSibling(); //히어라키에서 처음으로 순서 변경
        transform.SetAsLastSibling(); //마지막으로 순서 변경
        transform.SetSiblingIndex(4); //4번째에 위치하도록 순서 변경
        print(transform.GetSiblingIndex()); //순서 반환
    }
}
