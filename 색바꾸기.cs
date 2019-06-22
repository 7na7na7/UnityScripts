using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//using UnityEngine.Random
public class 색바꾸기: MonoBehaviour
{
    public float colorchange=0.05f;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            normal();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            red();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            blue();
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            green();
        }

    }
    //0 normal
    void normal() 
    {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        Color color = spr.color;
        color.r += colorchange;
        color.g += colorchange;
        color.b += colorchange;
        color.a += colorchange;
        spr.color = color;
    }

//1 red
    void red()
    { 
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        Color color = spr.color;
        if (color.r<255)
        {
            color.r += colorchange;
            color.g = c;
            color.b = c;
            color.a += colorchange;
            spr.color = color; 
        }
    }

//2 blue
    void blue()
    {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        Color color = spr.color;
        if (color.b<255)
        {
            color.r = c;
            color.g = c;
            color.b +=colorchange;
            color.a += colorchange;
            spr.color = color;
        }
    }

//3 green
    void green()
    {
        SpriteRenderer spr = GetComponent<SpriteRenderer>();
        Color color = spr.color;
        if (color.g<255)
        {
            color.r = c;
            color.g += colorchange;
            color.b = c;
            color.a += colorchange;
            spr.color = color;
        }
    }
}
