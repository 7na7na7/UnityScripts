using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bananagun : MonoBehaviour
{
    public float fullspeed = 0, lessspeed = 0;
    public float[] savedpitch;
    public float pitchctr=1;
    private SpriteRenderer renderer;
    public string weapon = "pistol";
    private float savedshotdelay, savedsavedshotdelay;
    public float shotdelay = 1;
    private bool canshot = true;
    public AudioSource audiosource;
    public AudioClip bulletsound;//총알소리
    
    private Color color;
    private Move1 player;
    public Transform tr;
    public GameObject[] banana;
    private Vector3 MousePositon;
    public Camera camera;

    private float plusforce,minusforce;
    private void Start()
    {
        minusforce=this.transform.localScale.x * -1;
        plusforce=this.transform.localScale.x;
        renderer = GetComponent<SpriteRenderer>();
        savedshotdelay = shotdelay;
        savedsavedshotdelay = shotdelay;
        player = FindObjectOfType<Move1>();
    }
    void Update()
    {
        if(weapon=="pistol") 
            audiosource.pitch = savedpitch[0];
        else if(weapon=="shotgun") 
            audiosource.pitch = savedpitch[1];
        else if (weapon == "sniper")
            audiosource.pitch = savedpitch[2];
        else
            audiosource.pitch = 2; //나이프
        pitchctr = 0;
        weapon = gameObject.name;
        savedshotdelay = savedsavedshotdelay;
        for (int i = 0; i < player.shotdelaycount; i++) //강화스피드
        {
            pitchctr += 0.2f;
            savedshotdelay *= 0.85f;
        }

        if (player.slider.maxValue - player.slider.value == 0) //풀피일떄
        {
            for (int i = 0; i < fullspeed; i++)
            {
                savedshotdelay *= 0.7f;
            }
        }
        if (player.slider.value<=player.slider.maxValue*0.3f)//현재hp의30%이하일때
        {
            for (int i = 0; i < lessspeed; i++)
            {
                savedshotdelay *= 0.7f;
            }
        }

        if(weapon!="knife") 
            audiosource.pitch += pitchctr;
        shotdelay = savedshotdelay;
        if (player.isflip == true)
        {
            
            if(gameObject.name=="knife") 
                renderer.flipX = true;
            
            transform.localScale = new Vector3(minusforce, this.transform.localScale.y, this.transform.localScale.z); //왼쪽으로 뒤집어짐
               
        }
        else
        {
            if (gameObject.name == "knife")
                renderer.flipX = false;
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
                if (Input.GetMouseButton(0)) 
                {
                    if (canshot == true)
                        {
                            if (weapon== "knife")
                            {
                                knife knife = FindObjectOfType<knife>();
                                StartCoroutine(knife.attackanim());
                            }

                            Instantiate(banana[0], tr);
                            audiosource.PlayOneShot(bulletsound,0.8f);
                            if (weapon == "shotgun")
                            {
                                Instantiate(banana[1], tr);
                                Instantiate(banana[2], tr);
                            }

                            if (weapon == "shotgun2")
                            {
                                Instantiate(banana[1], tr);
                                Instantiate(banana[2], tr);
                                Instantiate(banana[3], tr);
                                Instantiate(banana[4], tr);
                            }

                            StartCoroutine(delay());
                        }
                }
            }
        }
    }

    IEnumerator delay()
    {
        canshot = false;
        yield return new WaitForSeconds(shotdelay);
        canshot = true;
    }
}
