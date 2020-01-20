using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 스프라이트사이즈 : MonoBehaviour
{
    private void Start()
    {
        print(GetSpriteSize(gameObject));
    }

    public Vector3 GetSpriteSize(GameObject _target)
    {
        Vector3 worldSize = Vector3.zero;
        if(_target.GetComponent<SpriteRenderer>())
        {
            Vector2 spriteSize = _target.GetComponent<SpriteRenderer>().sprite.rect.size;
            Vector2 localSpriteSize = spriteSize / _target.GetComponent<SpriteRenderer>().sprite.pixelsPerUnit;
            worldSize = localSpriteSize;
            worldSize.x *= _target.transform.lossyScale.x;
            worldSize.y *= _target.transform.lossyScale.y;
        }
        else
        {
            Debug.Log ("SpriteRenderer Null");
        }
        return worldSize;
    }
}
