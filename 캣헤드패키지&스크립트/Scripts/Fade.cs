using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public float speed;
    void Update()
    {
        Color color = GetComponent<Image>().color;
        color.a -=Time.deltaTime*speed;
        GetComponent<Image>().color = color;
    }
}
