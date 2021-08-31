using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//이거 두개 잇어야 함
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceProviders;


public class AddressableAsset : MonoBehaviour
{
    GameObject player = null;

    public string serverAddress;
    public string spriteName;
    public string prefabName;
    public string sceneName;
    bool isLoaded = false;
    public AssetReference PrefabReference;
    GameObject TempObj;

    public Image Image;
    AsyncOperationHandle Handle;
    SceneInstance LoadedScene;


    private void Start()
    {
        //주소를 가지고 와 로드와 동시에 생성
        PrefabReference.InstantiateAsync(transform.position, Quaternion.identity).Completed +=
        (AsyncOperationHandle<GameObject> obj) => //제대로 에셋을 로드하였을 경우 처리
        {
            TempObj = obj.Result;
            Invoke("ReleaseDestroy", 3f); //3초 후 메모리 할당 해제
        };
        
    }
    //시간차 해제
    void ReleaseDestroy()
    {
        PrefabReference.ReleaseInstance(TempObj);
        //해제와 함꼐 오브젝트 삭제
    }


    public void ClickLoad()
    {
        //Sprite타입의 NyarukoSprite라는 어드레서블 에셋을 로드해 추가함
        Addressables.LoadAssetAsync<Sprite>(spriteName).Completed +=
           (AsyncOperationHandle<Sprite> Obj) => //제대로 에셋을 로드하였을 경우 처리
           {
               Handle = Obj;
               Image.sprite = Obj.Result;
           };
    }

    public void ClickUnLoad()
    {
        //Release로 제대로 해제해 주지 않으면 계속 남아있는다!
        Addressables.Release(Handle); //레퍼런스 카운트 내려감
        Image.sprite = null;
    }

    public void ClickPrefab()
    {
        Addressables.InstantiateAsync(prefabName, transform.position, Quaternion.identity);
    }

    public void ClickLoadScene()
    {
        if (!isLoaded)
            Addressables.LoadSceneAsync(sceneName, UnityEngine.SceneManagement.LoadSceneMode.Additive).Completed += OnSceneLoaded; //모드를 Additive로 하여 서브씬 형태로 현재 씬에 합쳐지게 함
        else
            Addressables.UnloadSceneAsync(LoadedScene).Completed += OnSceneUnLoaded;
    }

    void OnSceneLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        if(obj.Status==AsyncOperationStatus.Succeeded) //제대로 로드됐다면
        {
            LoadedScene = obj.Result; //씬인스턴스를 저장해 놓음, 나중에 언로드할 때 사
            isLoaded = true;
        }
        else
        {
            print("로드 실패!");
        }
    }

    void OnSceneUnLoaded(AsyncOperationHandle<SceneInstance> obj)
    {
        if (obj.Status == AsyncOperationStatus.Succeeded)
        {
            isLoaded = false;
            LoadedScene = new SceneInstance();
        }
        else
        {
            print("언로드 실패!");
        }
    }

    public void ClickSound() //서버로드 함수 
    {
        if(player!=null)
        {
            Addressables.ReleaseInstance(player); 
            player = null;
        }
        else//serverAddress
        {
            //serverAddress라는 이름의 어드레서블 에셋을 하나만 불러옴과 동시에 생성
            Addressables.InstantiateAsync(serverAddress, new Vector3(0, 0, 0), Quaternion.identity).Completed +=
              (AsyncOperationHandle<GameObject> obj) =>
              {
                  player = obj.Result;
              };
        }
    }
}
