using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class 점프: MonoBehaviour
{
    public float jumpPower = 1f;
    public Rigidbody2D rigid;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigid.velocity = Vector2.zero;
            Vector2 jumpVelocity = new Vector2(0, jumpPower); 
            rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
        }
    }
}
