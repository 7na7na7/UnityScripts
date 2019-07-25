using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddForce : MonoBehaviour
{
    private void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(20, 0));
    }
}