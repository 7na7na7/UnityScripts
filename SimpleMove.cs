using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
     private Rigidbody2D rigid;
        public float speed;
        private void Start()
        {
            rigid = GetComponent<Rigidbody2D>();
        }
    
        void Update()
        {
            rigid.velocity=new Vector2(Input.GetAxisRaw("Horizontal")*speed,Input.GetAxisRaw("Vertical")*speed);
        }
}
