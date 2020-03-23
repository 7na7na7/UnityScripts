using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ScrollScript : ScrollRect
{
  ScrollManager SM;
  private ScrollRect parentScrollRect;
  private bool forParent;
  protected override void Start()
  {
    SM = GameObject.FindWithTag("ScrollManager").GetComponent<ScrollManager>();
    parentScrollRect = GameObject.FindWithTag("ScrollManager").GetComponent<ScrollRect>();
  }

  public override void OnBeginDrag(PointerEventData eventData)
  {
    //드래그 시작하는 순간 수평이동이 크면 부모가 드래그, 수직이 크면 자식이 드래그 시작한 것!
    forParent = Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y);

    if (forParent) {
      SM.OnBeginDrag(eventData);
      parentScrollRect.OnBeginDrag(eventData); 
    }
    else 
      base.OnBeginDrag(eventData);
  }

  public override void OnDrag(PointerEventData eventData)
  {
    if (forParent) {
      SM.OnDrag(eventData);
      parentScrollRect.OnDrag(eventData); 
    }
    else
      base.OnDrag(eventData);
  }

  public override void OnEndDrag(PointerEventData eventData)
  {
    if (forParent) {
      SM.OnEndDrag(eventData);
      parentScrollRect.OnEndDrag(eventData); 
    }
    else
      base.OnEndDrag(eventData);
  }
}
