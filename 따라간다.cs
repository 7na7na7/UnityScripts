using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 따라간다 : MonoBehaviour
{
    public Transform target;
    float moveSpeed;
    float rotSpeed;
 
    void Start(){
        moveSpeed = Random.Range(5,20);
        rotSpeed = Random.Range(5,10);
    }
    void Update(){
        Vector3 vec = target.position - transform.position;
        Quaternion q = Quaternion.LookRotation(vec);
        Quaternion s = Quaternion.Slerp(transform.rotation, q, rotSpeed*Time.deltaTime);
        transform.rotation = s;
        transform.Translate(new Vector3(0,0,1) * moveSpeed * Time.deltaTime);
    }
}
