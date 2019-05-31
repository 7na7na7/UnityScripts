using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class 리스폰_코루틴: MonoBehaviour
{
    public GameObject obj; //생성할 오브젝트
    public Transform tr; //오브젝트를 생성할 위치
    void Start()
    {
        StartCoroutine(Respawn());
        //Invoke("Respawn", 2.0f); //2초 후 Respawn함수를 호출
        //Invoke("Respawn", 1.0f, 3.0f); //1초 후부터 3초마다 함수를 계속 호출
    }
    IEnumerator Respawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.7f);//0.7초의 딜레이
            Instantiate(obj, tr.position, Quaternion.identity);
        }
    }
}
