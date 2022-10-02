using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UGS;
public class GoogleSheetDataManager : MonoBehaviour
{
    public InputField intValueInput;
    public InputField strValueInput;
    void Awake()
    {
        TestTable.Data.Load();
        //TestTable의 로컬 데이터 불러오기!
        // UnityGoogleSheet.LoadAllData(); 
        // or UnityGoogleSheet.Load<TestTable.Data.Load>(); it's same!
        // or call TestTable.Data.Load(); it's same!
    }

    public void LocalLoad()
    {
        //리스트 형식으로 불러오기!
        Debug.LogError("로컬 로드!");
        foreach (var value in TestTable.Data.DataList)
        {
            Debug.Log(value.index + "," + value.intValue + "," + value.strValue);
        }

        //딕셔너리 형식으로 불러오기!
        var dataFromMap = TestTable.Data.DataMap[0];
        //Debug.Log("dataFromMap : " + dataFromMap.index + ", " + dataFromMap.intValue + "," + dataFromMap.strValue);
    }
    public void LiveLoad()
    {
        Debug.LogError("라이브 로드!");
        //한달에 오만번인가? 서버 API는 횟수 제약있음
        UnityGoogleSheet.LoadFromGoogle<int, TestTable.Data>((list, map) =>
        {
            //살짝 불러오기 딜레이 걸리고...
            list.ForEach(x =>
            {
                Debug.Log(x.intValue + ", " + x.strValue);
            });
        }, true);
    }
    public void LiveSave()
    {
        Debug.LogError("라이브 세이브");
        //새로운 데이터 추가
        var newData = new TestTable.Data();
        newData.index = TestTable.Data.DataList.Count;
        newData.intValue = int.Parse(intValueInput.text);
        newData.strValue = strValueInput.text;

        UnityGoogleSheet.Write<TestTable.Data>(newData);
    }
}
