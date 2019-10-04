using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class DialogueManager : MonoBehaviour, IPointerDownHandler
{
    public Text dialogueText;
    public GameObject nextText;
    public Queue<string> sentences;
    private string currentSentence;
    public float typeSpeed = 0.1f;
    private bool istyping = false;
    public CanvasGroup dialoguegroup;
    public static DialogueManager instance;
    void Start()
    {
     sentences=new Queue<string>();
    }

    private void Awake()
    {
        instance = this;
    }

    public void Ondialogue(string[] lines)
    {
        sentences.Clear();
        foreach (string line in lines)
        {
            sentences.Enqueue(line);
        }

        dialoguegroup.alpha = 1; //다이얼로그 창이 보이도록 설정
        dialoguegroup.blocksRaycasts = true; //blockRaycasts가 true일 때만 마우스이벤트 감지가능
        NextSentence();
    }

    public void NextSentence()
    {
        if (sentences.Count != 0)
        {
            currentSentence = sentences.Dequeue(); //문장에서 디큐를 반환함
            //코루틴
            istyping = true;
            nextText.SetActive(false);
            StartCoroutine(Typing(currentSentence));
        }
        else //큐의 카운트가 0이 되면
        {
            dialoguegroup.alpha = 0; //다이얼로그 창이 안 보이도록 설정
            dialoguegroup.blocksRaycasts =false; //마우스이벤트 감지불가
        }
    }

    IEnumerator Typing(string line) //타이핑하는 듯한 효과
    {
        dialogueText.text = "";
        foreach (char letter in line.ToCharArray()) //line의 글자 하나하나를 letter에 넣어주면서 반복문
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(typeSpeed);
        }
    }

    private void Update()
    {
        //dialogueText == currentSentence이면 대사 한줄 끝
        if (dialogueText.text.Equals(currentSentence))
        {
            istyping = false;
            nextText.SetActive(true);
        }
    }

    //OnPointerDown은 해당 오브젝트에 클릭, 터치가 있을 때 호출딤
    public void OnPointerDown(PointerEventData eventData) 
    {
        if(!istyping) 
            NextSentence();
    }
}
