using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int dir;
    public bool isCollide = false;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall") || other.CompareTag("Slime")|| other.CompareTag("BossSlime")||other.CompareTag("wallsu")||other.CompareTag("Container"))
        {
            GetComponent<longBullet>().canLong = false;
            Destroy(gameObject,0.01f);
        }
        else
        {
            if ((other.name.Substring(0, 7) == "Player1" && name.Substring(0, 7) == "Bullet2"))
            {
                if (!other.GetComponent<PlayerMove>().isSuper)
                {
                    GetComponent<longBullet>().canLong = false;
                    Destroy(gameObject,0.01f);
                }
            }
            else if(other.name.Substring(0, 7) == "Player2" && name.Substring(0, 7) == "Bullet1")
            {
                if (!other.GetComponent<PlayerMove>().isSuper)
                {
                    GetComponent<longBullet>().canLong = false; 
                    Destroy(gameObject,0.01f);
                }
            }
        }
    }
}
