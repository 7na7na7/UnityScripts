using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class hardcam: MonoBehaviour
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
