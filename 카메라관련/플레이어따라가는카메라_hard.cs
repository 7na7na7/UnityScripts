using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class 플레이어따라가는카메라_hard: MonoBehaviour
{
    public GameObject player;  //여기다 따라갈거 넣는다.
    Transform AT;
    void Start()
    {
        AT = player.transform;
    }
    void LateUpdate()
    {
        transform.position = new Vector3(AT.position.x, AT.position.y, transform.position.z);
    }
}
