using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class 점점투명_코루틴: MonoBehaviour
{
    SpriteRenderer spr = GetComponent<SpriteRenderer>();
    Color color = spr.color;
    void Start()
    {
        StartCoroutine(transparent());
    }
    IEnumerator transparent()
    {
        while (true)//무한반복
        {
            SpriteRenderer spr = GetComponent<SpriteRenderer>();
            Color color = spr.color;
            color.a -= 0.1f;
            spr.color = color;
            yield return new WaitForSeconds(0.2f); //0.2초의 간격을 두고 실행됨  
        }
    }
}
