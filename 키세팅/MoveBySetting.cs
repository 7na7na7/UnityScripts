using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBySetting : MonoBehaviour
{
    private Vector2 dir;
    void Update()
    {
        dir=Vector2.zero;
        if(Input.GetKey(SetKey.keys[Keys.UP])) 
            dir.y += 1;
        if(Input.GetKey(SetKey.keys[Keys.DOWN])) 
            dir.y -= 1;
        if(Input.GetKey(SetKey.keys[Keys.LEFT])) 
            dir.x -= 1;
        if(Input.GetKey(SetKey.keys[Keys.RIGHT])) 
            dir.x += 1;
        
        transform.Translate(dir.normalized*Time.deltaTime*5);
    }
}
