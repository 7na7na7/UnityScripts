using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class 애니메이션 : MonoBehaviour
{
    /*이미지 여러개를 오브젝트에 넣어갓구 애니메이션폴더에 저장한다.
플레이어에 애니메이터(Animator) 를 추가한다.
그 애니메이션을 애니메이터에 넣는다.
이제 애니메이션에 들어가서 블럭같은거있는데 들어간다.
거기서 make transition을 써서 처음상태를 설정하고 연결고리를 만든다.
bool로 true/false로 이동할지 말지를 결정한다.
연결고리의 inspector에서 bool을 설정한다.*/
    Animator PlayerAnim;

    private void Awake()
    {
        PlayerAnim = gameObject.GetComponent<Animator>();
    }
    animator.SetBool("Iswalk", true); //애니메이션을 실행시키길 원하는곳에 이걸넣는다.
}



