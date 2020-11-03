using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

[CreateAssetMenu(fileName = "Zombie Data",menuName = "Scriptable Object/Zombie Data",order = int.MaxValue)]
public class ZombieData : ScriptableObject
{
    //프로퍼티로 읽기전용으로 변경
    [SerializeField] private string zombieName; //이름
    public string ZombieName { get { return zombieName; } } 

    [SerializeField] private int hp; //체력
    public int Hp { get { return hp; } }

    [SerializeField] private int damage; //데미지
    public int Damage { get { return damage; } }

    [SerializeField] private float sightRange; //시야반경
    public float SightRange { get { return sightRange; } }

    [SerializeField] private float moveSpeed; //이동속도
    public float MoveSpeed { get { return moveSpeed; } }
}
