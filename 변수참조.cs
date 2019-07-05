using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 변수참조 : MonoBehaviour
{
    
    void Start()
    {
        //fire라는 스크립트를 가진 ss라는 이름의 오브젝트를 찾아서 참조
        fire fr = GameObject.Find("ss").GetComponent<fire>();
        
        //blood라는 스크립트를 가진 obj라는 오브젝트를 자식으로 가지는 gameobject에서의 obj참조
        blood bl = transform.Find("obj").GetComponent<blood>();
        
        //water라는 스크립트를 가진 ob라는 오브젝트를 부모로 가지는 gameobject에서의 ob참조
        water wat = transform.parent.GetComponent<chamjo>();
        
        //wood라는 스크립트를 가졌으며 cc라는 이름의 태그를 가진 오브젝트를 찾아서 참조
        fire fr = GameObject.FindWithTag("cc").GetComponent<fire>();
    }
}
