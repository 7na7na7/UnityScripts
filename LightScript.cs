using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    /*
    Light에는 4가지 타입이 있다.
    Spoㅅ - 스포트라이트처럼 쭉 뻗어 있다. 
    Derectional - 현실 세계의 태양과 같다. 모든 오브젝트에게 동일한 빛을 동일한 각도에서 내리쬔다.
    Point - 일반 전구처럼 동그랗게 빛이 퍼져 나간다.
    Area(bake only) - 약간의 직사각형 모양의 텍스쳐에서 빛을 발함
    
    Color - 빛의 색을 바꿀 수 있다.
    Mode - 모드, Realtime은 매 프레임마다 광원을 계산해 어느 위치에 그림자를 하는지 계산한다. 최적화를 위해 Baked를 쓰면 그림자가 처음 상태에서 안움직인다.
    
    Baked : 물체에 Static에서 Baked할 물체를 Lightmap Static으로 굽는다. 그러면 움직이는 객체는 빛의 영향을 받지 않게 된다.
    해결을 위해 빈 게임오브젝트에 Light Probe Group을 만들어 준다. 이 그룹 안에 속하는 물체는 그림자를 제외한 빛의 영향을 받을 수 있게 된다.
    그림자 문제를 해결하려면 또 빛을 하나 만들고 Culling Mask를 이용해 예외처리를 해주면 될 것 같다.
    Window - Rendering - Lightening Settings에서 Bake를 조절할 수 있다.
    Progressive는 Bake과정을 보여준다. 이게 신기술이라 더 좋다고 한다.
    Direct Samples는 직접광의 퀄리티 조절, 높을수록 베이크 시간 오래 걸림
    Indirect Samples는 간접광의 퀄리티
    Bounced는 반사광이 튕기는 정도
    LightMap Resolution - 그림자의 퀄리티 조절, 높을수록 좋아짐
    
    Intensity - 빛의 세기이다.
    Indirect Multiplier - 빛이 잘 반사되는 정도
                
    Shadow type - No shadow : 그림자 없음, Hard shadow : 딱딱한 그림자, Soft shadow : 부드러운 그림자(기본값)
    Strength - 그림자의 투명도 조절 가능
    Resolution - 그림자의 퀄리티
    
    Coockie - 그림자를 방해하는 요소, Size로 크기 조절 가능
    
    Draw hale - 후광 설정 가능
    Flare - 카메라로 태양을 바라볼 때 플레어 발생, Create - Lens flare로 생성 가능 
    Render Mode - Important : 좋은 조명, Not Important : 안좋아도 상관없음
    Culling Mask - 조명에 영향을 미칠 레이어를 설정함, Everything이 기본값 
    */

    private Light light;
    private float targetIntensity;
    private float currentIntensity;
    void Start()
    {
        light = GetComponent<Light>();
        currentIntensity = light.intensity; //빛의 세기 넣어줌
        targetIntensity = Random.Range(0.4f, 1f);
    }
    
    //Point로 빛을 지정한다.
    void Update() //수명이 닳은 전구처럼 꺼질락 말락하게 깜박이는 연출을 줄 수 있다.
    {
        if (Mathf.Abs(targetIntensity - currentIntensity) >= 0.01f) //두 값이 같은 수가 아니라면
        {
            if (targetIntensity - currentIntensity >= 0) // currentIntensity가 targetIntensity보다 작다면
                currentIntensity += Time.deltaTime*3; //currentIntensity값 증가
            else
                currentIntensity -= Time.deltaTime*3; //currentIntensity값 감소

            light.intensity = currentIntensity; //라이트 
            light.range = currentIntensity + 10; //Point일 때 빛의 범위 지정
        }
        else //두 값이 같은 수라면
        {
            targetIntensity = Random.Range(0.4f, 1f); //targetIntensity를 재설정
        }
    }
}
