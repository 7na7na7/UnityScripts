using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateByDir : MonoBehaviour
{
    public Vector2 dir;
  
    void Start()
    {
        float rot = Mathf.Atan2(dir.x,dir.y) * Mathf.Rad2Deg;
        Vector3 currentRotation=new Vector3(0,0,rot); //이미지에따라 rot에 -90, 위를보고있는상태가 기본이면 안해도된다
        transform.rotation=Quaternion.Euler(currentRotation);
    }
}
