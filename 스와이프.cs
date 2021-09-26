using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class �������� : MonoBehaviour
{
    public Text outputText;
    private Vector2 startTouchPosition;
    private Vector2 currentPosition;
    Vector2 endTouchPosition;
    bool stopTouch = false;

    public float swipeRange=50; //���������ߴٰ� �Ǵ��� �Ÿ�
    public float tapRange=10; //���ߴٰ� �Ǵ��� �Ÿ�

    private void Update()
    {
        Swipe();
    }

    void Swipe()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            currentPosition = Input.GetTouch(0).position;
            Vector2 Distance = currentPosition - startTouchPosition;

            if (!stopTouch)
            {
                if (Distance.x < -swipeRange)
                {
                    outputText.text="����!";
                    stopTouch = true;
                }
                else if (Distance.x > swipeRange)
                {
                    outputText.text = "������!";
                    stopTouch = true;
                }
                else if (Distance.y > swipeRange)
                {
                    outputText.text = "��!";
                    stopTouch = true;
                }
                else if (Distance.y < -swipeRange)
                {
                    outputText.text = "�Ʒ�!";
                    stopTouch = true;
                }
            }
        }

        if(Input.touchCount>0&&Input.GetTouch(0).phase==TouchPhase.Ended)
        {
            stopTouch = false;
            endTouchPosition = Input.GetTouch(0).position;
            Vector2 Distance = endTouchPosition - startTouchPosition;
            if(Mathf.Abs(Distance.x)<tapRange&&Mathf.Abs(Distance.y)<tapRange)
            {
                outputText.text = "��!";
            }
        }
    }
}

