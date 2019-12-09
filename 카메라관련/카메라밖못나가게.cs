using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class 카메라밖엔못나간다: MonoBehaviour
{
    public Transform tr;
    public float offset = 0.4f;
    float size = Camera.main.orthographicSize;
    float screenRation = (float)Screen.width / (float)Screen.height;
    float wSize = Camera.main.orthographicSize * screenRation;
    void Update()
    {
        if (tr.position.y >= size - offset)
        {
            tr.position = new Vector3(tr.position.x, size - offset, 0);//위

        }
        if (tr.position.y <= -size + offset)
        {
            tr.position = new Vector3(tr.position.x, -(size - offset), 0);//아래

        }
        if (tr.position.x >= wSize - offset)
        {
            tr.position = new Vector3(wSize - offset, tr.position.y, 0);//오른쪽
        }
        if (tr.position.x <= -wSize + offset)
        {
            tr.position = new Vector3(-wSize + offset, tr.position.y, 0);//왼쪽
        }
    }
}
