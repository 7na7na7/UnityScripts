using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class critical : MonoBehaviour
{
    private GameObject obj;//오브젝트 삭제용
    
    public float FadeTime = 2f; // Fade효과 재생시간

    //private Image fadeImg; //이미지로 하고싶으면 이거써라
    private float start;

    private float end;

    private float time = 0f;

    private bool isPlaying = false;



    void Awake()

    {
        obj = this.gameObject;
        SpriteRenderer fadeimg = GetComponent<SpriteRenderer>();//스프라이트로 함
        //fadeImg = GetComponent<Image>();  //이미지로 하고싶으면 이거쓰셈

        InStartFadeAnim();

    }

    private void Update()
    {
        SpriteRenderer fadeImg = GetComponent<SpriteRenderer>();
        Color fadecolor = fadeImg.color;
        if (fadecolor.a == 0)
        {
            Debug.Log("삭제된다!");
            Destroy(obj);
        }
    }

    public void OutStartFadeAnim()

    {

        if (isPlaying == true) //중복재생방지

        {

            return;

        }

        start = 1f;

        end = 0f;

        StartCoroutine("fadeoutplay"); //코루틴 실행

    }

    public void InStartFadeAnim()

    {
        if (isPlaying == true) //중복재생방지
        {
            return;
        }
        StartCoroutine("OutStartFadeAnim");
    }

    IEnumerator fadeoutplay()
    {
        SpriteRenderer fadeImg = GetComponent<SpriteRenderer>();//이미지로 하고싶음 이거써라
        isPlaying = true;



        Color fadecolor = fadeImg.color;

        time = 0f;

        fadecolor.a = Mathf.Lerp(start, end, time);


        while (fadecolor.a > 0f)

        {

            time += Time.deltaTime / FadeTime;

            fadecolor.a = Mathf.Lerp(start, end, time);

            fadeImg.color = fadecolor;

            yield return null;

        }

        isPlaying = false;
    }
}
