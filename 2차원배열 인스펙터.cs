using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 2차원배열인스펙터 : MonoBehaviour
{
[System.Serializable]  //  MonoBehaviour가 아닌 클래스에 대해 Inspector에 나타내기.
public class MapArray
{
    public GameObject[] data;
}

public class MyScript : MonoBehaviour
{
    public MapArray[] map;
}
//이런 식으로 2차원 게임오브벡트를 인스펙터에 사용할 표시할 수 있다.
}
