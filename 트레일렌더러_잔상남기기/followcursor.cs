using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class followcursor : MonoBehaviour
{
    //private TrailRenderer trail;
    private void Start()
    {
        //trail = GetComponent<TrailRenderer>();
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //trail.startColor = Color.green;
            //trail.endColor=Color.cyan;
            //trail.endWidth = 3;
        }
        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = pos;
    }
}
