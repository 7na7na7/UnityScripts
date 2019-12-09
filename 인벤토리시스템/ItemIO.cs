using System.Collections.Generic;
using UnityEngine;
using System.Xml;

//Xml 사용

//sealed를 사용하여 다른 클래스가 상속되지 못하도록 함.
public sealed class ItemIO : MonoBehaviour
{
  private static Inventory inven; //인벤토리 스크립트 받아오는 용도

  private void Awake()
  {
    inven = FindObjectOfType<Inventory>();
  }

  public static void SaveData()
  {
    //인벤토리에서 슬롯을 관리해주는 리스트를 받아온다.
    List<GameObject> item = inven.AllSlot;

    XmlDocument XmlDoc = new XmlDocument(); //XML문서 XmlDoc 생성
    XmlElement XmlEl = XmlDoc.CreateElement("ItemDB"); //요소 XmlEl 생성
    XmlDoc.AppendChild(XmlEl); //요소 XmlEl 를 XML문서 XmlDoc 에 첨부

    //리스트의 총 크기(슬롯의 개수)
    int Count = item.Count;

    for (int i = 0; i < Count; i++) //슬롯의 개수만큼 반복
    {
      //슬롯 리스트에서 슬롯을 하나씩 꺼내온다.
      Slot itemInfo = item[i].GetComponent<Slot>();

      //슬롯이 비어 있다면 저장할 필요가 없으므로 다음 반복문으로 넘긴다.
      if (!itemInfo.isSlots()) //슬롯이 비었으면
        continue; //넘기기

      //필드(요소)를 생성
      XmlElement ElementSetting = XmlDoc.CreateElement("Item");

      //필드(요소)의 내용을 셋팅

      //n번째 슬롯의 번호 저장
      ElementSetting.SetAttribute("SlotNumber", i.ToString());
      //아이템의 이름 저장
      ElementSetting.SetAttribute("Name", itemInfo.ItemReturn().Name);
      //아이템의 개수 저장
      ElementSetting.SetAttribute("Count", itemInfo.slot.Count.ToString());
      //아이템을 겹칠 수 있는 한계
      ElementSetting.SetAttribute("MaxCount", itemInfo.ItemReturn().MaxCount.ToString());
      //아이템 스프라이트
      ElementSetting.SetAttribute("Sprite",
        itemInfo.ItemReturn().DefaultImg.ToString()
          .Substring(0, itemInfo.ItemReturn().DefaultImg.ToString().IndexOf(" (")));
      //아이템 타입
      ElementSetting.SetAttribute("Type", itemInfo.ItemReturn().type.ToString());
      //ItemDB요소에 위의 셋팅한 요소를 문서에 첨부
      XmlEl.AppendChild(ElementSetting);
    }

    // XML 문서로 내보낸다. 인자로는 문서를 내보낼 경로이다.
    //Application.dataPath는 유니티 프로젝트의 Assets폴더까지의 경로를 반환해 준다.
    XmlDoc.Save(Application.dataPath + "/Save/InventoryData.xml"); //Asset폴더의 Save폴더에 InventoryData.xml 생성
  }

  public static List<GameObject> Load(List<GameObject> SlotList) //오브젝트 List를 받아 List를 반환
  {
    //만약 아래의 경로에 파일이 존재하지 않는다면
    if (!System.IO.File.Exists(Application.dataPath + "/Save/InventoryData.xml"))
      return SlotList; //그냥 반환하고 종료

    XmlDocument XmlDoc = new XmlDocument(); //문서를 만듬
    XmlDoc.Load(Application.dataPath + "/Save/InventoryData.xml"); //경로상의 XML파일을 로드
    XmlElement Xmlel = XmlDoc["ItemDB"]; //속성 ItemDB에 접속

    foreach (XmlElement ItemElement in Xmlel.ChildNodes)
    {
      //슬롯의 n번째 스크립트를 가져온다.
      Slot slot = SlotList[System.Convert.ToInt32(ItemElement.GetAttribute("SlotNumber"))].GetComponent<Slot>();
      
      //아이템 생성
      Item item = new Item();
      
      //아이템의 정보를 셋팅한다.
      string Name = ItemElement.GetAttribute("Name");                                   //아이템 이름을 가져옴
      int MaxCount = System.Convert.ToInt32(ItemElement.GetAttribute("MaxCount"));      //겹칠 수 있는 한계
      item.Init(Name,MaxCount);                                                               //위의 가져온 정보로 아이템의 정보를 초기화
      item.DefaultImg=Resources.Load<Sprite>(ItemElement.GetAttribute("Sprite")); //스프라이트 받아오기
      switch (ItemElement.GetAttribute("Type"))
      {
        case "HP":
          item.type = Item.TYPE.HP;
          break;
        case "MP":
          item.type = Item.TYPE.MP;
          break;
        case "SpeedBuff":
          item.type = Item.TYPE.SpeedBuff;
          break;
      }
      int Count = System.Convert.ToInt32(ItemElement.GetAttribute("Count")); //슬롯에 아이템을 n개 집어넣기 위해서 개수를 가져옴
      for (int i = 0; i < Count; i++) 
        slot.SlotAddItem(item);
      }

    return SlotList;
  }
}