using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 스탯 클래스
public class Stat
{
    public int atk; // 공격력
    public int def; // 방어력
    public int hp; // 체력
    public int gold; // 골드

    public Stat() // 생성자
    { // 0으로 초기화
        atk = 0;
        def = 0;
        hp = 0;
        gold = 0;
    }
}

// 설계상 작성한 캐릭터 스탯 클래스
public class CharacterStat : Stat // 스탯 클래스 상속받음
{
    // 생성자
    public CharacterStat() : base() // 부모 생성자 호출
    {
    }
}

// 설계상 작성한 몹 스탯 클래스
public class MobStat : Stat // 스탯 클래스 상속받음
{
    // 생성자
    public MobStat() : base() // 부모 생성자 호출
    {

    }
}
