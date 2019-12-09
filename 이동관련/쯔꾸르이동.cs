using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 쯔꾸르이동 : MonoBehaviour
{
    public float speed; //이동속도
    public float runspeed; //달릴 때의 이동 속도  증가값
    public int walkCount; //픽셀 단위 이동 시 이 값이 크면 더 많은 픽셀을 한번에 건너뜀


    private Vector3 vector; //벡터값 저장
    private float applyRunSpeed; 
    private int currentWalkCount; 
    private bool canMove = true;
    private bool applyRunFlag = false;
    private Animator animator;
    private float animatorspeed;
    void Start()
    {
        animator = GetComponent<Animator>(); //애니메이터 컴포넌트 받아옴
        animatorspeed = animator.speed;
    }

    IEnumerator MoveCoroutine() //플레이어를 움직이게 하는 함수, 픽셀 단위 움직임을 구현하기 위해 딜레이를 넣어야 하여 코루틴으로 만들었다.
    {
        while (Input.GetAxisRaw("Vertical") != 0 || Input.GetAxisRaw("Horizontal") != 0)
        {
            if (Input.GetKey(KeyCode.LeftShift)) //왼쪽 시프트 키를 누를 시 달리기
            {
                animator.speed = animator.speed + animator.speed * runspeed;
                applyRunSpeed = speed * runspeed;
                applyRunFlag=true;
            }
            else
            {
                animator.speed = animatorspeed;
                applyRunSpeed = 0;
                applyRunFlag = false;
            }
        
            vector.Set(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), transform.position.z); //vector.Set을 이용하여 vector의 X에 Horizontal값, Y에 Vertical값을 넣어 주고 있다.

            if (vector.x != 0) //아래로 걷고 있을 때 방향전환되는 버그 수정
                vector.y = 0;
            
            animator.SetFloat("DirX",vector.x); //파라미터 DirX에 vector.x값을 넣음
            animator.SetFloat("DirY",vector.y); //파라미터 DirY에 vector.y값을 넣음
            animator.SetBool("Walking",true); //Walking을 true로 변경
            while (currentWalkCount < walkCount)
            {
                if (vector.x != 0)
                {
                    transform.Translate(vector.x*(speed+applyRunSpeed),0,0);
                }
                else if (vector.y != 0)
                {
                    transform.Translate(0,vector.y*(speed+applyRunSpeed),0);
                }
                if (applyRunFlag)
                    currentWalkCount++;
                currentWalkCount++;
                yield return new WaitForSeconds(0.01f);
            }
            currentWalkCount = 0;
            animator.speed = animatorspeed;
        }
        canMove = true;
    }
    void Update()
    {
        if (canMove)
        {
            if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }
            else
            {
                animator.SetBool("Walking",false); //Walking을 false로 변경
            }
        }
    }
}
