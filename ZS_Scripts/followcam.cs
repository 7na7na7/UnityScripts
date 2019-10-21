using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcam : MonoBehaviour
{
    public float speed;
    public GameObject player;
    private Vector3 cameraPosition;
    private void LateUpdate()
    {
        cameraPosition =new Vector3(player.transform.position.x,player.transform.position.y,this.transform.position.z); 
        transform.position = Vector3.Lerp(transform.position, cameraPosition, speed * Time.deltaTime);
    }
}
