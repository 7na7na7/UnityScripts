using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamage
{
    void Damage(int damage); //이 인터페이스를 상속밭은 클래스에서 구현해줘야 한다. 가상함수같은 느낌?
    //스크립트가 Enemy1, Enemy2, Enemy3처럼 서로 달라도 공통적인건 이렇게 넣도록 할수있다! 쓸모있다.
    //Damage를 따로 다르게 설정해줄 수도 있어서 좋은거같다.
}

