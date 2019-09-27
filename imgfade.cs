using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class imgfade : MonoBehaviour
{
    private GameObject obj;
    public float speed;
    private Image img;
    private Color fadecolor;

    private void Start()
    {
        obj = this.gameObject;
        img = GetComponent<Image>();
        StartCoroutine(fade());
    }

    IEnumerator fade()
    {
        while (true)
        {
            fadecolor = img.color;
            fadecolor.a -= 0.1f;
            yield return new WaitForSeconds(speed);
            img.color = fadecolor;
            if(img.color.a<=0)
                Destroy(obj);
        }
    }
}
