using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button[] CellBtn;
    public Button PreviousBtn, NextBtn;
    public List<string> myList = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15", "16", "17", "18" };

    int currentPage = 1, maxPage, multiple; //각각 현재페이지, 최대페이지, 각 페이지 대표 수(가장앞에있는수)


    void Start()
    { 
        // 최대페이지
        maxPage = (myList.Count % CellBtn.Length == 0) ? myList.Count / CellBtn.Length : myList.Count / CellBtn.Length + 1; //18이 9로 나누어떨어지므로 2페이지, 20은 9로 나누어떨어지지 않으므로 3페이지 

        // 이전, 다음버튼
        PreviousBtn.interactable = (currentPage <= 1) ? false : true; //현재 페이지가 1이하라면 이전으로 갈수없게  PreviousBtn.interactable을 끔
        NextBtn.interactable = (currentPage >= maxPage) ? false : true; //현재 페이지가 최대 페이지 이상이라면 다음으로 못가게 NextBtn.interactable끔

        // 페이지에 맞는 리스트 대입
        multiple = (currentPage - 1) * CellBtn.Length; //각 페이지 첫 번째 인자
        for (int i = 0; i < CellBtn.Length; i++)
        {
            //multiple + i 를 하면 각각의 인자를 얻을 수 있다.
            CellBtn[i].interactable = (multiple + i < myList.Count) ? true : false; //만약 수가 14까지 있는데 myList는 18까지 있을 경우, 15,16,17,18은 비활성화시켜 주어야 한다.
            CellBtn[i].GetComponentInChildren<Text>().text = (multiple + i < myList.Count) ? myList[multiple + i] : "";//만약 수가 14까지 있는데 myList는 18까지 있을 경우, 15,16,17,18은 텍스트를 없대 준다. 아니면 myList의 텍스트를 넣어 준다.
        }
    }


    // ◀버튼 -2 , ▶버튼 -1 , 셀 숫자
    public void BtnClick(int num) 
    {
        if (num == -2) --currentPage;
        else if (num == -1) ++currentPage;
        else print(myList[multiple + num]);

        Start(); //다시 갱신
    }

    
    [ContextMenu("리스트추가")]
    void ListAdd() { myList.Add("뚝배기"); Start(); }


    [ContextMenu("리스트제거")]
    void ListRemove() { myList.RemoveAt(0); Start(); }
}
