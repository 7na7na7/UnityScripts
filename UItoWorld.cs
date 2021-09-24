using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UItoWorld : MonoBehaviour
{
    public Image img;
    void Start()
    {
        Vector3 pos_Obj = Camera.main.WorldToViewportPoint(UI가 이동을원하는 오브젝트포지션);
        Vector2 pos_UI = Camera.main.ViewportToWorldPoint(pos_Obj); 
        img.transform.position = pos_UI;
    }

}
