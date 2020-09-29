using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class Title_DoTween : MonoBehaviour
{
    public GameObject[] obs;
    public RectTransform rt;
    public float y;
    public GameObject ob;
    void Start()
    {
        //1초 동안 RectTransform의 Y값을 -300으로 만듬, Elastic효과로 개멋지게
        rt.DOAnchorPosY(y,3).SetEase(Ease.OutBack);

        ob.transform.DOScale(new Vector3(8, 8, 0), 1).SetEase(Ease.OutBack).SetDelay(3);
        StartCoroutine(cor());
    }

    IEnumerator cor()
    {
        yield return new WaitForSeconds(5);
        foreach (GameObject ob in obs)
        {
            Destroy(ob);
        }
    }
}
