using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Excel : MonoBehaviour
{
    //엑셀에서 작업한 후 메모장으로 복사-붙여넣기하여 다른 이름으로 저장(영어이름, 유니코드(UTF-8)로 인코딩한다
    public TextAsset txt; //그 txt파일을 여기 넣는다.
    private string[,] Sentence;
    private int lineSize, rowSize;
    void Start()
    {
       textToArray();
       foreach (string str in Sentence)
       {
           print(str);
       }
    }

    public void textToArray()
    {
        //엔터단위와 탭으로 나눠서 배열의 크기 조정
        string currentText = txt.text.Substring(0, txt.text.Length - 1); //마지막 엔터 없애기
        string[] line = currentText.Split('\n'); //엔터로 나눈 값을 배열형식으로 반환(한줄씩)
        lineSize = line.Length; //라인의 갯수
        rowSize = line[0].Split('\t').Length; //탭으로 나눠진 수, [13 45 1]라면 3이 된다.
        Sentence=new string[lineSize,rowSize]; //2차원 배열을 만든다. 
        
        //한 줄에서 탭으로 나눔
        for (int i = 0; i < lineSize; i++)
        {   
            string[] row = line[i].Split('\t');
            for (int j = 0; j < rowSize; j++)
                Sentence[i, j] = row[j]; //2차원 배열에 값을 대입해 준다. 
        }
        //이 과정들이 끝나면 2차원 배열 Sentence에 txt텍스트 파일의 배열이 저장된다.
    }
}
