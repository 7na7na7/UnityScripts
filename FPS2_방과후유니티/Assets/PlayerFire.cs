using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    //파이어2를 누르면 총알을 발사한다
    //총알 공장
    public GameObject bulletFactory;
    //총알 위치
    public Transform firePos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //파이어2를 누르면 
        if (Input.GetButtonDown("Fire2"))
        {
            //총알공장에서 총알을 만든후
            GameObject bullet= Instantiate(bulletFactory);
            //위치를 잡아준다
            bullet.transform.position = firePos.position;
            bullet.transform.forward = firePos.forward;

        }


    }
}
