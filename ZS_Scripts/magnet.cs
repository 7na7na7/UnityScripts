using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magnet : MonoBehaviour
{
    public GameObject player;
    private void Update()
    {
        this.transform.position = player.transform.position;
    }

    public void radiousup()
    {
        CircleCollider2D col = this.GetComponent<CircleCollider2D>();
        col.radius += 1.5f;
    }
}
