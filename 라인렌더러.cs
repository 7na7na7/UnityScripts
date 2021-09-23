using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]
public class 라인렌더러 : MonoBehaviour
{
    private LineRenderer lineRenderer;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.SetColors(Color.red, Color.yellow);
        lineRenderer.SetWidth(0.1f, 0.1f);

        //라인렌더러 시작위치, 끝위치 설정
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.position + new Vector3(0,3, 0));
    }
}
