using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject goPrefab = null; //포물선으로 날아갈 화살의 프리팹
    public Transform ArrowTr = null; //화살의 위치
    public Transform ShotTr; //화살이 생성될 위치
    public float arrowForce; //화살발사 세기
    private Camera cam = null; //카메라선언
    void Start()
    {
        cam=Camera.main;
    }

    void LookAtMouse()
    {
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition); //스크린상의 마우스 좌표를 게임상의 2D좌표로 치환
        Vector2 direction=new Vector2(mousePos.x-ArrowTr.position.x,
                                      mousePos.y-ArrowTr.position.y); //활 좌표 - 월드 상의 마우스 좌표 = 바라볼 방향

        ArrowTr.right = direction; //오른쪽 벡터를 direction으로 바꿈
    }

    void TryFire()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject arrow = Instantiate(goPrefab, ShotTr.position, ShotTr.rotation); //ArrowTr의 위치와 회전값에 화살 프리팹 생성
            arrow.GetComponent<Rigidbody2D>().velocity = arrow.transform.right * arrowForce; //가속도 오른쪽으로 줌
        }
    }
    void Update()
    {
        LookAtMouse(); //이걸로 해도되고
        /*
        Vector2 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.eulerAngles = new Vector3(0, 0,
            -getAngle(transform.position.x, transform.position.y, mousePos.x, mousePos.y)+90); //이렇게 해도된다.
        */
        TryFire();
        
        Debug.Log(ShotTr.transform.rotation);
        
        //한번 만들어본거...  분수 ㅋㅋ
        if (gameObject.name == "Fountain") //오브젝트 이름이 분수라면
        {
            GameObject arrow = Instantiate(goPrefab, ShotTr.position, new Quaternion(ShotTr.transform.rotation.x, ShotTr.transform.rotation.y,
                Random.Range(0.0f,1.0f),Random.Range(0.0f,1.0f))); //ArrowTr의 위치와 회전값에 화살 프리팹 생성
            
            arrow.GetComponent<Rigidbody2D>().velocity = arrow.transform.right * arrowForce; //가속도 오른쪽으로 줌
        }
    }
    private float getAngle(float x1, float y1, float x2, float y2) //Vector값을 넘겨받고 회전값을 넘겨줌
    {
        float dx = x2 - x1;
        float dy = y2 - y1;

        float rad = Mathf.Atan2(dx, dy);
        float degree = rad * Mathf.Rad2Deg;
        
        return degree;
    }
}
