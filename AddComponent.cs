using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddComponent : MonoBehaviour
{
    public string ComponentName; //어떤 컴포넌트를 받을지 선택
    void Start () {

        switch (ComponentName)
        {
            case "rigidbody2d": //ComponentName이 rigidbody2d일 경우
                this.gameObject.AddComponent<Rigidbody2D>(); //Rigidbody2D컴포넌트를 추가해 줌
                break;
        }

        StartCoroutine(delete()); //컴포넌트 삭제 코루틴 실행
    }

    IEnumerator delete() //1초 후에 컴포넌트 삭제
    {
        yield return new WaitForSeconds(1f);
        Destroy(GetComponent<Rigidbody2D>());
    }
}
