using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class 플레이어따라가는카메라_soft: MonoBehaviour
{
    public GameObject player; //여기에다가 따라갈거 넣는다.
    Transform AT;
    void Start()
    {
        AT = player.transform;
    }
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, AT.position, 2f * Time.deltaTime); //Vector3.Lerp()를 쓰면 부드럽게 움직인다.
        transform.Translate(0, 0, -10); //카메라를 원래 z축으로 이동
    }
}
