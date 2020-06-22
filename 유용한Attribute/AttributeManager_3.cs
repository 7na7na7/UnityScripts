using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode] //플레이를 안해도 UI를 조정하거나 변수를 조정할 때 실행됨
[RequireComponent(typeof(Rigidbody2D))] //해당 컴포넌트를 무조건 필요로 해서 스크립트를 붙이면 무조건 같이 붙음, 없애려고 하면 오류남
[DisallowMultipleComponent] //똑같은 컴포넌트 중복 추가 불가능
public class AttributeManager_3 : MonoBehaviour
{
    public Transform heos;
    public float r;

    public Node node;
    
    [System.NonSerialized] //직렬화를 풀어버린다. 그래서 public변수가 인스펙터 창에 뜨지 않게 된다.
    public int publicValue; 
    void Update()
    {
        print(Time.deltaTime); 
        heos.Rotate(0,0,r);
    }
    
    [System.Serializable] //직렬화시켜서 인스펙터창에 띄워 준다.
    public class Node
    {
        public int A, B, C;
    }
}
