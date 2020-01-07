using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
public class Capsule : MonoBehaviour
{
    public AssetReference Ref;
    private GameObject TempObj;
    void Start()
    {
        //위치를 넣어 주어 생성
        Ref.InstantiateAsync(new Vector3(1, 1, 0), Quaternion.identity).Completed+=
            (AsyncOperationHandle<GameObject> obj) =>
            {
                TempObj=obj.Result;
                
                Invoke("releaseDestroy",3f);
            };
    }

    private void releaseDestroy()
    {
        //레퍼런스카운트도 내려가서 사라짐
        Ref.ReleaseInstance(TempObj);
    }
}
