using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class 스프라이트바꾸기: MonoBehaviour
{
    public Sprite CurrentSprite;//현재스프라이트 넣기
    public Sprite NextSprite; //변경할 스프라이트 넣기
    private SpriteRenderer spriteRenderer; //spriteRenderer에 SpriteRenderer넣기

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = CurrentSprite; //스프라이트를 현재스프라이트로 바꾸기
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))//A키를 누르면
        {
            spriteRenderer.sprite = NextSprite; //다음 스프라이트로 바뀜
        }
    }
}
