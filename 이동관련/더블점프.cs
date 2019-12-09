using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class 더블점프: MonoBehaviour
{
    public int jumpcount = 2;
    public float jumpPower = 1f;
    public Rigidbody2D rigid;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jumpcount > 0)
            {
                rigid.velocity = Vector2.zero;
                Vector2 jumpVelocity = new Vector2(0, jumpPower);
                rigid.AddForce(jumpVelocity, ForceMode2D.Impulse);
                jumpcount--;
            }
        }
    }

    IEnumerator OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.CompareTag("ground")) //땅 닿을시 점프카운트 초기화
        {
            jumpcount = 2;
        }
    }
}
