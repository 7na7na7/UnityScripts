using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMove2 : MonoBehaviour
{
    private Vector2 moveDirection;
     private Rigidbody2D rigid;
        public float speed;
        private void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }
    
        void Update()
        {
            Move();
        }

        void Move()
        {
            float moveX = Input.GetAxisRaw("Horizontal");
            float moveY = Input.GetAxisRaw("Vertical");

            moveDirection = new Vector2(moveX, moveY).normalized; //대각선 이동 정규화
            rigid.velocity=new Vector2(moveDirection.x*speed,moveDirection.y*speed);
        }
}
