using UnityEngine;
using UnityEngine.UI;

public class ItemDrag : MonoBehaviour
{
    private Transform Img; //빈 이미지 객체

    private Image EmptyImg; //빈 이미지
    private Slot slot; //현재 슬롯의 스크립트를 얻어오는 용도
    private Inventory inven; //인벤토리 스크립트 받아오는 용도
    
    private void Start()
    {
        inven = FindObjectOfType<Inventory>(); //인벤토리 스크립트 가져옴
        //현재 슬롯의 스크립트를 가져온다.
        slot = GetComponent<Slot>();
        //빈 이미지 객체를 태그를 이용하여 가져온다.
        Img = GameObject.FindGameObjectWithTag("DragImg").transform;
        //빈 이미지 객체가 가진 Image컴포넌트를 가져온다.
        EmptyImg = Img.GetComponent<Image>();
    }

    public void Down()
    {
        //슬롯에 아이템이 없으면 함수 종료
        if (!slot.isSlots())
            return;
        //아이템 사용시
        if (Input.GetMouseButtonDown(1))
        {
            slot.ItemUse();
            return;
        }
        
        //빈 이미지 객체를 활성화시킨다.
        Img.gameObject.SetActive(true);
        
        //빈 이미지의 사이즈를 변경한다.(해상도가 바뀔경우를 대비, 슬롯의 크기와 같게 변경)
        float Sizex = slot.transform.GetComponent<RectTransform>().sizeDelta.x; //슬롯의 x값을 받아옴
        EmptyImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal,Sizex);
        float Sizey = slot.transform.GetComponent<RectTransform>().sizeDelta.y; //슬롯의 y값을 받아옴
        EmptyImg.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,Sizey);
        
        //빈 이미지의 스프라이트를 슬롯의 스프라이트로 변경한다.
        EmptyImg.sprite = slot.ItemReturn().DefaultImg;
        //빈 이미지의 위치를 마우스 위로 가져온다.
        Img.transform.position = Input.mousePosition;
        //슬롯의 아이템 이미지를 없애준다.
        slot.UpdateInfo(true,slot.DefaultImg);
        //슬롯의 텍스트 숫자를 없애준다.
        slot.text.text = "";
    }

    public void Drag()
    {
        if (Input.GetMouseButton(1))
            return;
        
        //isSlot플래그가 false면 슬롯에 이미지가 존재하지 않는 것이므로 함수 종료
        if (!slot.isSlots()) 
            return;

        Img.transform.position = Input.mousePosition; //이미지의 위치를 마우스와 같게 만듬
    }

    public void DragEnd()
    {
        if (Input.GetMouseButton(1))
            return;
        
        //isImg플래그가 false이면 슬롯에 아이템이 존재하지 않는 것이므로 함수 종료
        if (!slot.isSlots())
            return;
        
        //인벤토리의 스왑 함수를 호출(현재 슬롯, 빈 이미지의 현재 위치)
        inven.Swap(slot, Img.transform.position);
        //slot=null;
    } 
    
    /*
왜 마우스를 뗐을 때 발생하는 이벤트도 필요할까?
마우스를 뗐을 때의 이벤트는 필요 없을것 같지만 필요하다.
빈 이미지 객체의 비활성화 및 슬롯의 이미지 업데이트에 필요하다.
빈 이미지 객체의 비활성화의 경우 드래그가 끝났을 때 수행해도 되지만,
아이템을 눌렀을 때 마우스를 움직이지 않으면 DragEnd함수는 호출되지 않는다.
그렇기 때문에 빈 이미지 객체의 활성화 조정을 이곳에서 할 필요가 있으며,
마찬가지로 없애주었던 이미지의 복구 또한 이곳에서 해 주어야 한다.
[짧게 말해, 드래그 안하고 그냥 클릭하면 DragEnd가 실해이 안되니까 Up을 사용한다는 뜻]
 */
    public void Up()
    {
        //isImg플래그가 false이면 슬롯에 아이템이 존재하지 않는 것이므로 함수 종료
        if (!slot.isSlots())
            return;
        
        //빈 이미지 객체 비활성화
        Img.gameObject.SetActive(false);
        //슬롯의 아이템 이미지를 복구시킨다
        slot.UpdateInfo(true,slot.slot.Peek().DefaultImg);
    }
}
