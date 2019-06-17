using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class 버튼이미지바꾸기 : MonoBehaviour
{
    public Sprite img; //여기 스프라이트 넣고
    public Button btn; //여기 버튼 넣은 다음에
    
    public void changeimage () { //이걸로 버튼에 연결시켜서 Onclick()으로 실행시키면!
        btn.gameObject.GetComponent<Image>().sprite = img;//이걸로 버튼의 이미지 컴포넌트를 얻어와 그것의 스프라이트를 pubic으로 넣은 img파일로 교체한다!
        }
}
