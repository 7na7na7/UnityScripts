using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCast_BoxCollider : MonoBehaviour
{
    public BoxCollider2D col;
    Vector2 first, second;
    void Start()
    {
        RaycastHit2D[] hit = Physics2D.BoxCastAll((Vector2)transform.position + col.offset, col.size, 0, Vector2.down, 0);
        first = transform.position + (Vector3)col.offset;
        second = col.size;
        foreach (RaycastHit2D c in hit)
        {
            if(c.collider.CompareTag("Player"))
            {
                print("플레이어 감지!");
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;    
        Gizmos.DrawWireCube(first, second);
    }
}
