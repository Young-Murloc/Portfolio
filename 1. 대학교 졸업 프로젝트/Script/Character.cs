using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

// 캐릭터 관리 클래스
public class Character : MonoBehaviour
{
    public GameObject goBm, goMb; // 인스펙터로 주어지는 게임 오브젝트
    
    // goBm, goMb에서 얻는 스크립트 컴포넌트
    private BoardManager bm;
    private Mob mob;

    public CharacterStat cs; // 캐릭터 스탯 클래스

    // 시작시 호출
    public void Start()
    {
        // 스크립트 컴포넌트 얻기
        bm = goBm.GetComponent<BoardManager>();
        mob = goMb.GetComponent<Mob>();
        // 스탯 객체 생성
        cs = new CharacterStat();
        Load(); // 불러오기
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

    // 턴 종료시 보드 매니저에 의해 호출되는 캐릭터 액션
    public void characterAction(List<int> action) //터진 타일에 따른 캐릭터 움직임
    {
        if(action[0] != 0) // 검이 있음, 공격
        {
            if(mob.ms.def != 0) // 방어력이 있음
            {
                mob.ms.hp -= action[0] * cs.atk - mob.ms.def; // 공격력과 몬스터의 방어력을 적용하여 체력 줄이기
            }
            else
            {
                mob.ms.hp -= action[0] * cs.atk; // 공격력을 그대로 적용
            }
            gameObject.GetComponent<Animator>().SetTrigger("Attack"); // 공격 애니메이션 실행
        }
        if(action[1] != 0) // 방패가 있음, 방어
        {
            cs.def += action[1]; // 방어력 증가
        }
        if(action[2] != 0) // 포션이 있음. 회복
        {
            cs.hp += action[2] * 3; // 체력 증가
        }
        if(action[3] != 0) //망치, 강한 공격
        {
            if (mob.ms.def != 0) // 방어력이 있음
            {
                mob.ms.hp -= action[0] * cs.atk * 2 - mob.ms.def;  // 공격력과 몬스터의 방어력을 적용하여 체력 줄이기
            }
            else
            {
                mob.ms.hp -= action[0] * cs.atk * 2; // 공격력을 그대로 적용
            }
            gameObject.GetComponent<Animator>().SetTrigger("Attack"); // 공격 애니메이션 실행
        }
        if(action[4] != 0) //보석, 튼튼한 방어
        {
            cs.def += action[4]*2; // 방어력 증가
        }
        if(action[5] != 0) //하트, 뛰어난 회복
        {
            cs.hp += action[5]*2; // 체력 증가
        }

        if(cs.hp <= 0) // 체력 0 이하면
        {
            gameObject.GetComponent<Animator>().SetBool("Die",true); // 죽기 애니메이션 실행
        }
    }
    
}
