using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoad : MonoBehaviour
{
    private void Start()
    {
       GameObject p=Instantiate(Resources.Load<GameObject>("characters/Player") , transform.position, Quaternion.identity);
        // AssetResources폴더 안의 characters폴더에 있는 게임오브젝트 타입의 Player란 이름의 리소스 가져옴, Sprite형이나 AudioClip형도 가능!
    }
}
