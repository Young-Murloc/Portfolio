using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

// 유저 인터페이스 매니저
public class UIManager : MonoBehaviour
{
    private CharacterStat cs; // 캐릭터 스탯

    public Text Gold, Gem; // 골드, 보석 텍스트

    public void Start() // 유니티 호출 시작 함수
    {
        cs = new CharacterStat(); // 캐릭터 스탯 객체 생성
        Load(); // 불러오기
        Gold.text = Convert.ToString(cs.gold); // 골드 텍스트에 값 넣기
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
}
