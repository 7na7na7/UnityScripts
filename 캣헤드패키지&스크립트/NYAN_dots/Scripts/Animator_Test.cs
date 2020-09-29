using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NYAN_dots
{
	public class Animator_Test : MonoBehaviour
	{
		public int walkSpd = 5;
		public int runSpd = 10;
		public float spd = 0f;
		Rigidbody2D rb2;
		Animator amt;

		void Start()
		{
			rb2 = GetComponent<Rigidbody2D>();
			amt = GetComponent<Animator>();
		}

		void Update()
		{
			//移動処理(Movement processing)

			//移動キー	※押してる間
			float inputX = Input.GetAxisRaw("Horizontal");
			float inputY = Input.GetAxisRaw("Vertical");
			bool inputSpc = Input.GetButton("Fire1");

			//速度を追加
			rb2.velocity = new Vector2(spd * inputX, spd * inputY);


			//アニメ処理(Animation processing)

			//待機
			if (inputX == 0 && inputY == 0)
			{
				amt.SetBool("walk", false);
				amt.SetBool("run", false);
			}
			else
			{   //入力をアニメに伝える
				amt.SetFloat("dirX", inputX);
				amt.SetFloat("dirY", inputY);

				//歩行
				amt.SetBool("walk", true);
				amt.SetBool("run", false);
				spd = walkSpd;

				//走行
				if (inputSpc)
				{
					amt.SetBool("run", true);
					amt.SetBool("walk", false);
					spd = runSpd;
				}
			}
		}

		void OnTriggerEnter2D(Collider2D other)
		{
			amt.SetTrigger("blink");
		}
	}
}
