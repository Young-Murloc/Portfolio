using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Store : MonoBehaviour
{
    private CharacterStat cs; // 캐릭터 스탯

    public void Start()
    {
        cs = new CharacterStat(); // 캐릭터 스탯 객체 생성
        Load(); // 파일에서 불러오기
    }

    // 불러오기
    public void Load()
    {
        // SaveStream을 이용하여 불러오기
        SaveStream SS = SaveStream.GetInstance(); // 싱글톤 인스턴스 얻기
        SS.openRead(); // 읽기 시작
        cs.atk = Convert.ToInt32(SS.Read("atk")); // atk 값 읽어오기
        cs.def = Convert.ToInt32(SS.Read("def")); // def 값 읽어오기
        cs.hp = Convert.ToInt32(SS.Read("hp")); // hp 값 읽어오기
        cs.gold = Convert.ToInt32(SS.Read("gold")); // gold 값 읽어오기
        SS.closeRead(); // 읽기 끝
    }

    // 저장하기
    public void Save()
    {
        // SaveStream을 이용하여 저장하기
        SaveStream SS = SaveStream.GetInstance(); // 싱글톤 인스턴스 얻기
        SS.openWrite(); // 쓰기 시작
        SS.Write("atk", Convert.ToString(cs.atk)); // atk 쓰기
        SS.Write("def", Convert.ToString(cs.def)); // def 쓰기
        SS.Write("hp", Convert.ToString(cs.hp)); // hp 쓰기
        SS.Write("gold", Convert.ToString(cs.gold)); // gold 쓰기
        SS.closeWrite(); // 쓰기 종료
    }

    // 공격력 레벨 업
    public void atkLevelUp()
    {
        if (cs.gold >= 100) // 골드가 100 이상이면
        {
            cs.atk++; // 공격력 1 증가
            cs.gold -= 100; // 100 골드 감소
            Save(); // 저장
        }
        else
        {
            Debug.Log("돈없당!"); // 디버깅 로그
        }
    }
    
    // 방어력 레벨 업
    public void defLevelUp()
    {
        cs.def++; // 방어력 1 증가
        Save();// 저장
    }

    // 체력 레벨 업
    public void hpLevelUp()
    {
        cs.hp+=15; // 체력 15 증가
        Save(); // 저장
    }
}
