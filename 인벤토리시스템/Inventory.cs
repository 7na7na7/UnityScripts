using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    //공개
    public List<GameObject> AllSlot; //모든 슬롯을 관리해줄 리스트
    public RectTransform InvenRect; //인벤토리의 Rect
    public GameObject OriginSlot; //오리지널 슬롯

    public float slotSize; //슬롯의 사이즈
    public float slotGap; //슬롯간 간격
    public float slotCountX; //슬롯의 가로 개수
    public float slotCountY; //슬롯의 세로 개수

    //비공개
    private float InvenWidth; //인벤토리 가로길이
    private float InvenHeight; //인벤토리 세로길이
    private float EmptySlot; //빈 슬롯의 개수

    private void Awake()
    {
        //인벤토리 이미지의 가로, 세로 사이즈 셋팅
        InvenWidth = (slotCountX * slotSize) + (slotCountX * slotGap) + slotGap;
        InvenHeight = (slotCountY * slotSize) + (slotCountY * slotGap) + slotGap;

        //셋팅된 사이즈로 크기를 설정
        InvenRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, InvenWidth); //가로
        InvenRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, InvenHeight); //세로

        //슬롯 생성하기
        for (int y = 0; y < slotCountY; y++)
        {
            for (int x = 0; x < slotCountX; x++)
            {
                //슬롯을 복사한다.
                GameObject slot = Instantiate(OriginSlot) as GameObject;
                //슬롯의 RectTransform을 가져온다.
                RectTransform slotRect = slot.GetComponent<RectTransform>();
                //슬롯의 자식인 투명이미지의 RectTransform을 가져온다.
                RectTransform item = slot.transform.GetChild(0).GetComponent<RectTransform>();

                slot.name = "slot_" + y + "_" + x; //슬롯 이름 설정.
                slot.transform.SetParent(transform); //슬롯의 부모를 이 오브젝트로 설정(인벤토리)

                //슬롯이 생성될 위치 설정하기
                slotRect.localPosition = new Vector3((slotSize * x) + (slotGap * (x + 1)),
                    -(slotSize * y) + (slotGap * (-y - 1)),
                    0); //왼쪽 위부터 생성되므로 y값은 아래로 와야 한다. 따라서 - 붙인다!

                //슬롯의 자식인 투명이미지의 사이즈 설정하기
                slotRect.localScale = Vector3.one;
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, slotSize); //가로
                slotRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, slotSize); //세로

                //슬롯의 사이즈 설정하기
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,
                    slotSize - slotSize * 0.3f); //가로
                item.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,
                    slotSize - slotSize * 0.3f); //세로

                //궁금점 : slotSize에서 왜 slotSize*0.3을 뺄까?

                //리스트에 슬롯을 추가
                AllSlot.Add(slot);
            }

            //빈 슬롯 = 슬롯의 숫자
            EmptySlot = AllSlot.Count;
            ///////////////////////////////////////////////////////////////////////
        }
        Invoke("Init",0.01f); //지연을 조금 주고 Init함수 실행
    }

    public bool AddItem(Item item)
    {
        //슬롯의 총 개수
        int slotCount = AllSlot.Count;
        
        //넣기위한 아이템이 슬롯에 존재하는지 검사, 슬롯의 총 개수만큼 반복
        for (int i = 0; i < slotCount; i++)
        {
            //슬롯의 스크립트를 가져온다.
            Slot slot = AllSlot[i].GetComponent<Slot>();
            
            //슬롯이 비어있으면 통과
            if(!slot.isSlots())
                continue;
            
            //슬롯에 존재하는 아이템의 타입과 넣으려는 아이템의 타입이 같고
            //슬롯에 존재하는 아이템의 겹칠 수 있는 최대치가 넘지 않았을 때(true일 때)
            if (slot.ItemReturn().type == item.type && slot.ItemMax(item))
            {
                //슬롯에 아이템을 넣는다.
                slot.SlotAddItem(item);
                return true;
            }
        }
        
        //빈 슬롯에 아이템을 넣기위한 검사
        for (int i = 0; i < slotCount; i++)
        {
            Slot slot = AllSlot[i].GetComponent<Slot>();
            
            //슬롯이 비어있지 않으면 통과
            if (slot.isSlots())
                continue;
            
            slot.SlotAddItem(item);
            return true;
        }
        //위의 조건에 해당되는 것이 없을 때 아이템을 먹지 못함
        return false;
    }
    
    //거리가 가까운 슬롯을 반환
    public Slot NearSlot(Vector3 Pos)
    {
        float Min = 10000f;
        int Index = -1;

        for (int i = 0; i < AllSlot.Count; i++) //슬롯의 개수만큼 반복
        {
            Vector2 sPos = AllSlot[i].transform.GetChild(0).position;
            float Distance = Vector2.Distance(sPos, Pos);

            if (Distance < Min)
            {
                Min = Distance;
                Index = i;
            }
        }

        if (Min > slotSize) //만약 최솟값이 슬롯의 개수보다 많아지면
            return null; //null반환

        return AllSlot[Index].GetComponent<Slot>();
    }
    
    //아이템 옮기기 및 교환
    public void Swap(Slot slot, Vector3 Pos)
    {
        Slot FirstSlot = NearSlot(Pos); //Pos와 가장 가까운 슬롯을 구함
        
        //현재 슬롯과 옮기려는 슬롯이 같으면 함수 종료
        if (slot == FirstSlot || FirstSlot == null)
        {
            slot.UpdateInfo(true,slot.slot.Peek().DefaultImg);
            return;
        }
        
        //가까운 슬롯이 비어있으면 옮기기
        if (!FirstSlot.isSlots())
        {
            Private_Swap(FirstSlot,slot);
        }
        //가까운 슬롯이 비어있지 않으면 교환하기
        else
        {
            int Count = slot.slot.Count;
            Item item = slot.slot.Peek();
            Stack<Item> temp=new Stack<Item>();
            
            for (int i = 0; i < Count; i++) 
            { 
                temp.Push(item);
                slot.slot.Clear();
            }
            
            Private_Swap(slot,FirstSlot);
            Count = temp.Count;
            item = temp.Peek(); 
            
            for(int i=0;i<Count;i++) 
                FirstSlot.slot.Push(item);
            
            FirstSlot.UpdateInfo(true,temp.Peek().DefaultImg);
        }
    }
    
    // 1: 비어있는 슬롯, 2: 비어있지 않은 슬롯
    void Private_Swap(Slot EmptySlot, Slot FilledSlot) //두 슬롯을 바꿈
    {
        int Count = FilledSlot.slot.Count; //슬롯의아이템 개수 세기
        Item item = FilledSlot.slot.Peek(); //슬롯의 아이템 보고 구해오기

        for (int i = 0; i < Count; i++)//아이템의 개수만큼
        {
            if (EmptySlot != null)//첫번째 스택이 비지 않았다면
                EmptySlot.slot.Push(item);//첫번째 스택에 아이템을 FilledSlot의 스택개수(아이템개수)만큼 추가한다.
        }
        
        if (EmptySlot != null)////첫번째 스택이 비지 않았다면
            EmptySlot.UpdateInfo(true, FilledSlot.ItemReturn().DefaultImg); //FilledSlot의 아이템의 이미지로 EmptySlot를 세팅
        
        //이제 EmptySlot에 FilledSlot이 들어감
        FilledSlot.slot.Clear(); //그러니 FilledSlot은 비워줌
        FilledSlot.UpdateInfo(false,FilledSlot.DefaultImg); //isSlot을 false로 바꿔주고, 이미지도 DafultImg로 바꿔준다!
        
    }

    void Init() //로드시 필요, Invoke를 사용하여 지연을 주기 위해서 함수로 만듬
    {
        ItemIO.Load(AllSlot);
    }
    
}
