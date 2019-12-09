using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class 플레이어이동soft: MonoBehaviour
{
    public Transform tr; //플레이어의 위치
    public float speed = 300.0f; //플레이어의 스피드
    float h; //좌, 우 (Horizontal)
    float v; //위, 아래 (Vertical)
    public Rigidbody2D rb; //rigidbody 받아오기
    void Update()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        Vector2 dir = new Vector2(h, v);
        rb.velocity = dir * speed * Time.deltaTime;     
    }
}
