using UnityEngine;

public class Item : MonoBehaviour
{
    public enum TYPE{HP, MP, SpeedBuff}

    public TYPE type; //아이템의 타입
    public Sprite DefaultImg; //기본 이미지
    public int MaxCount; //겹칠 수 있는 최대 숫자
    public string Name;
    
    private Inventory inven; //인벤토리에 접근하기 위한 변수
    private void Awake()
    {
        Name = gameObject.name;
        inven = FindObjectOfType<Inventory>(); //inven에 인벤토리를 넣어줌
    }

    void AddItem()
    {
        //아이템 획득 실패할 경우.
        if(!inven.AddItem(this))
            Debug.Log("아이템이 가득 찼습니다.");
        else //아이템 획득에 성공할 경우
            gameObject.SetActive(false); //아이템을 비활성화시켜준다.
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //플레이어와 충돌하면
        if(col.CompareTag("Player"))
            AddItem();
    }

    public void Init(string _name, int _maxcount)
    {
        Name = _name;
        MaxCount = _maxcount;
    }
}
