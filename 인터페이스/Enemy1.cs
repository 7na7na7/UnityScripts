using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour, IDamage
{
    public int hp = 10;
    public void Damage(int damage)
    {
        hp -= damage;
        if(hp<=0)
            Destroy(gameObject);
    }
}
