using System.Collections;
using System.Collections.Generic;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine;
using UnityEngine.UI;

public class Adressable : MonoBehaviour
{
    public Image mIMG;
    private AsyncOperationHandle Handle;

    public void _ClickLoad()
    {
        Addressables.LoadAssetAsync<Sprite>("해피나루").Completed +=
            (AsyncOperationHandle<Sprite> Obj) =>
            {
                Handle = Obj;
                mIMG.sprite = Obj.Result;
            };
    }

    public void _ClickUnload()
    {
        Addressables.Release(Handle);
        mIMG.sprite = null;
    }
}
