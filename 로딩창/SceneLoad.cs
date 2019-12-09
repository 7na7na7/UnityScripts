using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class SceneLoad : MonoBehaviour
{
    public Slider progressbar;
    public Text loadtext;
    IEnumerator LoadScene()
    {
        yield return null;
        AsyncOperation operation = SceneManager.LoadSceneAsync("Play"); //씬 Play를 비동기식으로 불러옴
        //AsyncOperation의 속성들
        //operation.isDone 작업의 완료 유무를 참, 거짓으로 반환
        //operation.progress 작업의 진행정도를 flaot형 0,1로 반환
        //operation.allowSceneActivation true면 로딩이 완료되면 바로 씬을 넘기고, true면 progress가 0.9에서 멈춤
        operation.allowSceneActivation = false; //로딩이 끝나도 멈추게 만듬
        while (!operation.isDone)
        {
            yield return null;
            if (progressbar.value < 0.9f)
                progressbar.value = Mathf.MoveTowards(progressbar.value, 0.9f, Time.deltaTime);
            else if(operation.progress>=0.9f)
                progressbar.value = Mathf.MoveTowards(progressbar.value, 1f, Time.deltaTime);
            if(progressbar.value>=1f)
                loadtext.text = "Press Space";

            if (Input.GetKeyDown(KeyCode.Space)&&progressbar.value>=1f&&operation.progress>=0.9f)
                operation.allowSceneActivation = true; //true로 만들어 씬을 넘김
        }
    }

    private void Start()
    {
        StartCoroutine(LoadScene());
    }
}
