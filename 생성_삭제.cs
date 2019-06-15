using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class 생성_삭제: MonoBehaviour
{
    public Gameobject image; //생성할 오브젝트 받음
    private GameObject obj;
    
    obj =  (GameObject)Instantiate(image); //이걸로 생성
    
    Destroy(obj.gameObject);//이걸로 삭제
}
