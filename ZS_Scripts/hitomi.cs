using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitomi : MonoBehaviour
{
    private SpriteRenderer renderer;
    private Color color;
    private Move1 player;
    public Transform tr;
    private Vector3 MousePositon;
    public Camera camera;

    private float plusforce,minusforce;
    private void Start()
    {
        minusforce=this.transform.localScale.x * -1;
        plusforce=this.transform.localScale.x;
        renderer = GetComponent<SpriteRenderer>();
        player = FindObjectOfType<Move1>();
    }
    void Update()
    {
        if (player.isflip == true)
        {
            transform.localScale = new Vector3(minusforce, this.transform.localScale.y, this.transform.localScale.z); //왼쪽으로 뒤집어짐
               
        }
        else
        {
            transform.localScale = new Vector3(plusforce, this.transform.localScale.y, this.transform.localScale.z);//오른쪽으로 뒤집어짐
        }
        if (Time.timeScale != 0)
        {
            if (player.isdead == true)
            {
                SpriteRenderer sprite = GetComponent<SpriteRenderer>(); //스프라이트로 함
                color.r = 255;
                color.g = 255;
                color.b = 255; 
                color.a = 0.0f;
                sprite.color = color;
            }
            else
            {
                MousePositon = Input.mousePosition;
                MousePositon =
                    camera.ScreenToWorldPoint(MousePositon) - player.transform.position; //플레이어포지션을 빼줘야한다!!!!!!!!!!!
                //월드포지션은 절대, 카메라와 플레이어 포지션은 변할 수 있다!!!!!!!
                
                MousePositon.y -= 0.25f; //오차조정을 위한 코드

                float angle = Mathf.Atan2(MousePositon.y, MousePositon.x) * Mathf.Rad2Deg;
                float x = 0f;
                if (Mathf.Abs(angle) > 90)
                {
                    x = 180f;
                    angle *= -1f;
                }

                transform.rotation = Quaternion.Euler(x, 0f, angle);
            }
        }
    }
}
