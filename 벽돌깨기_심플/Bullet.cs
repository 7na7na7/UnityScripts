using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public Paddle paddle;

    void OnEnable()
    {
        transform.position = new Vector2(paddle.paddleX + (CompareTag("Odd") ? 0.242f : -0.242f), -3.549f);
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * 0.05f);
        Invoke("ActiveFalse", 2);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        switch (col.name)
        {
            case "Block":
            case "HardBlock0":
            case "HardBlock1":
            case "HardBlock2":
                GameObject Col = col.gameObject;
                paddle.BlockBreak(Col);
                ActiveFalse();
                break;
            case "Background":
                ActiveFalse();
                break;
        }
    }

    void ActiveFalse() { gameObject.SetActive(false); }
}
