using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class AnimBtn : Button {
    public bool isAnim = true;
    Coroutine routineBtnAnim;
    bool isDown = false;

    protected override void OnEnable()
    {
#if !UNITY_EDITOR
        isWait = false;
#endif
        transform.localScale = Vector3.one;
    }

#if UNITY_EDITOR
    public override void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnPointerClick(eventData);
        //AudioManager.Instance.BtnClick();
    }
    public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnPointerDown(eventData);
        isDown = true;
        StartAnim();
    }
    public override void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnPointerUp(eventData);
        isDown = false;
        StartAnim();
    }
    public override void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
    {
        base.OnPointerExit(eventData);
    }
#else
	Vector2 pointV;
	float sensitive = 1000f;
    private Coroutine waitCoroutine;
    private bool isWait = false;
    public override void OnPointerClick(UnityEngine.EventSystems.PointerEventData eventData) {
	}
	public override void OnPointerDown(UnityEngine.EventSystems.PointerEventData eventData) {
		base.OnPointerDown (eventData);
		pointV = eventData.position;
        isDown = true;
        StartAnim();
    }
	public override void OnPointerUp(UnityEngine.EventSystems.PointerEventData eventData) {
        base.OnPointerUp(eventData);
	}
    public override void OnPointerExit(UnityEngine.EventSystems.PointerEventData eventData)
    {
        isDown = false;
        StartAnim();
        if (this.interactable)
        {
            base.OnPointerExit(eventData);
            if (!isWait && !eventData.dragging && (pointV - eventData.position).sqrMagnitude < sensitive)
            {
                if (waitCoroutine != null)
                {
                    StopCoroutine(waitCoroutine);
                }
                waitCoroutine = StartCoroutine(IeCheckTime());

                base.OnPointerClick(eventData);
                //AudioManager.Instance.BtnClick();
            }
        }
    }
    IEnumerator IeCheckTime()
    {
        isWait = true;
        yield return new WaitForSecondsRealtime(0.3f);
        isWait = false;
    }
#endif

    void StartAnim()
    {
        if (!isAnim)
            return;
        if (routineBtnAnim != null)
            StopCoroutine(routineBtnAnim);
        routineBtnAnim = StartCoroutine(IeAnim());
    }

    Vector3 downV = new Vector3(0.94f, 0.94f, 1f);
    IEnumerator IeAnim()
    {
        if (isDown)
        {
            while (transform.localScale.x >= downV.x)
            {
                transform.localScale = Vector3.one * Mathf.Lerp(transform.localScale.x, 0.9f, 0.1f);
                yield return null;
            }
            transform.localScale = downV;
        }
        else
        {
            while (transform.localScale.x <= 1f)
            {
                transform.localScale = Vector3.one * Mathf.Lerp(transform.localScale.x, 1.1f, 0.1f);
                yield return null;
            }
            transform.localScale = Vector3.one;
        }
    }
}
