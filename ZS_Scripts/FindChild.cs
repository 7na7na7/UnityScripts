using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindChild : MonoBehaviour
{
    private void Update()
    {
        Level lv = FindObjectOfType<Level>();
        if(lv.canpause)
        {
            if (Input.GetKeyDown(KeyCode.P))
            {
                if (Time.timeScale != 0)
                {
                    pauseon();
                }
                else
                {
                    pauseoff();
                }
            }
        }
    }

    public void pauseon()
    {
        GameObject child = transform.Find("panel").gameObject;
        child.SetActive(true);
        Time.timeScale = 0;
    }

    public void pauseoff()
    {
        GameObject child = transform.Find("panel").gameObject;
        child.SetActive(false);
        Time.timeScale = 1;
    }
}
