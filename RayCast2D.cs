using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCast2D : MonoBehaviour
{
    public float playerSpeed;
    public float RaycastLength; //쏠 레이저의 길이
    public LayerMask layer;
    void Update()
    {
        //hit 이라는 RaycastHit2D 레이저를 쏜다.
        //첫 번째 인자값 : 중심점
        //두 번쨰 인자값 : 방향
        //세 번째 인자값 : 쏠 레이저의 길이
        //transform.position을 중심으로 하면 피벗을 중심으로 중심점이 정해진다.
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, RaycastLength); //아래쪽으로 발사
        if (hit.collider.gameObject.CompareTag("Ground"))//만약 레이저에 닿은 콜라이더의 태그가 Groun라면
        {
            print("땅에 닿음!");
        }

        Vector2 start = transform.position; //캐릭터의 현재 위치 값
        //캐릭터의 x값에 자신이 다음 이동할 거리를 더함. 즉, 자신이 다음에 이동할 위치를 저장
        Vector2 end = start + new Vector2(start.x + playerSpeed * Time.deltaTime, 0);
        GetComponent<BoxCollider2D>().enabled = false; //잠깐 자기 자신을 계산에서 제외
        hit = Physics2D.Linecast(start, end, layer); //layer마스크 제외하고 start부터 end까지 레이저를 쏨
        GetComponent<BoxCollider2D>().enabled = false; //다시 활성화
        if(hit.transform==null)
            print("레이저에 닿은 것이 없습니다!");
    }
}
