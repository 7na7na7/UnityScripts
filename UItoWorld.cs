using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItoWorld : MonoBehaviour
{
    public Image img;
    void Start()
    {
        Vector3 pos_Obj = Camera.main.WorldToViewportPoint(UI�� �̵������ϴ� ������Ʈ������);
        Vector2 pos_UI = Camera.main.ViewportToWorldPoint(pos_Obj); 
        img.transform.position = pos_UI;
    }

}
