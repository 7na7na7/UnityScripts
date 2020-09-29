using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class Btn : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler
{
    private bool isonce = true;
    public AudioSource audio;
    public AudioClip ready;
    public AudioClip start;
    private bool isBtnDown = false;
    public string goSceneName;
    private Vector2 firstPos;

    private void Start()
    {
        firstPos = transform.position;
    }

    private void Update()
    {
        if (isBtnDown) {
            GetComponent<Text>().color = Color.black;
            transform.Translate(Random.Range(-0.025f,0.025f),Random.Range(-0.01f,0.01f),0);
        }
        else
        {
            GetComponent<Text>().color = new Color(0.6f, 0.6f, 0.6f);
            transform.position = firstPos;
        }
        transform.position=new Vector2(Mathf.Clamp(transform.position.x,firstPos.x-0.05f,firstPos.x+0.05f),Mathf.Clamp(transform.position.y,firstPos.y-0.1f,firstPos.y+0.1f));
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        isBtnDown = true;
        audio.PlayOneShot(ready,1f);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isBtnDown = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isonce)
        {
            isonce = false;
            StartCoroutine(delayChange());
        }

    }

   

    IEnumerator delayChange()
    {
        if (goSceneName == "Exit")
        {
            Application.Quit();
        }
        else
        {
            audio.PlayOneShot(start, 1f);
            yield return new WaitForSeconds(0.5f);
            SceneManager.LoadScene(goSceneName);
        }
    }

  
}
