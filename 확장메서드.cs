using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class 확장메서드
{
    //transform.SetPosY(4.5f);
    public static void SetPosY(this Transform tf, float value)
    {
        tf.position = new Vector3(tf.position.x, value, tf.position.z);
    }
    public static void SetPosX(this Transform tf, float value)
    {
        tf.position = new Vector3(value, tf.position.y, tf.position.z);
    }

}
