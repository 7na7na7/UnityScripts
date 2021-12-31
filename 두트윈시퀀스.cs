using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class 두트윈시퀀스 : MonoBehaviour
{
    private Sequence seq;
    private Image img;
    private void Start() //대충 꺼매졌다 투명해졌다 하는 선택중이펙트
    {
        seq = DOTween.Sequence().OnStart(() => img.DOColor(new Vector4(1, 1, 1, 0.25f), 0.25f))
            .Append(img.DOColor(new Vector4(1, 1, 1, 0.5f), 0.5f))
            .Append(img.DOColor(new Vector4(1, 1, 1, 0.25f), 0.5f)).SetLoops(-1).SetAutoKill(false);
        seq.Rewind();
        img.DOColor(new Vector4(1, 1, 1, 0f), 0.25f);
    }
    public void Selected()
    {
            seq.Restart();
    }
    public void UnSelected()
    {
            seq.Rewind();
            img.DOColor(new Vector4(1, 1, 1, 0f), 0.25f);
    }
}
