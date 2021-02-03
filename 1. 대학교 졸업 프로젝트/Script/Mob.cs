using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 몬스터 관리 클래스
public class Mob : MonoBehaviour
{
    private int movement; // 몬스터 행동 코드
    
    public GameObject goBm, goAm, goCrt; // 인스펙터로 얻어오는 게임 오브젝트
    
    private BoardManager bm; // 보드매니저
    private ActionManager am; // 액션매니저
    private Character crt; // 상대 캐릭터

    public MobStat ms; // 몬스터 스탯
    private void Start()
    {
        // 스크립트 컴포넌트 가져오기
        bm = goBm.GetComponent<BoardManager>();
        am = goAm.GetComponent<ActionManager>();
        crt = goCrt.GetComponent<Character>();

        movement = 2; // 첫 턴엔 쉬기
        ms = new MobStat(); // 몬스터 스탯 객체 생성

        ms.atk = 10; // 공격력
        ms.def = 5; // 방어력
        ms.hp = 200; // 체력
    }

    public void monsterAction()            //타일을 움직일때마다 몹이 행동을 취한다
    {
        //0-공격, 1-방어, 2-쉬기, 3-특수능력
        if (movement == 0)                  //공격
        {
            if (ms.atk > crt.cs.def) // 몬스터 공격력이 캐릭터 방어력보다 높으면
            {
                crt.cs.hp -= ms.atk - crt.cs.def; // 몬스터 공격력 - 캐릭터 방어력만큼 캐릭터 체력을 줄인다.
                crt.cs.def = 0; // 캐릭터 방어력은 0
            }
            else
            {
                crt.cs.def -= ms.atk; // 캐릭터의 방어력에서 몬스터의 공격력을 줄인다.
            }
            gameObject.GetComponent<Animator>().SetTrigger("Attack"); // 공격 모션 실행
        }
        else if(movement == 1)              //방어도
        {
            ms.def += 5 + Random.Range(0,5); // 몬스터 방어력 5 + 0~5 증가
        }
        else if(movement == 2)              //쉬는거
        {
        }
        else
        {

        }

        movement = Random.Range(0, 3); // 다음 행동 랜덤 설정
        changeAction(movement); // 다음에 할 행동 표시하기

        if (ms.hp <= 0) // 체력이 0보다 작으면
        { 
            gameObject.GetComponent<Animator>().SetBool("Die", true); // 죽는 모션 실행
        }
    }

    public void changeAction(int a)                 //몹 머리위에 떠있는 행동을 표시해주는 장치
    {
        if (a == 0) // 공격
        { // 검 활성화, 나머지 비활성화
            am.sword.SetActive(true);
            am.shield.SetActive(false);
            am.breakTime.SetActive(false);
        }
        else if (a == 1) // 방어
        { // 방어 활성화, 나머지 비활성화
            am.sword.SetActive(false);
            am.shield.SetActive(true);
            am.breakTime.SetActive(false);
        }
        else if(a == 2) // 아무것도 안 함
        { // x 표시 활성화, 나머지 비활성화
            am.sword.SetActive(false);
            am.shield.SetActive(false);
            am.breakTime.SetActive(true);
            //Debug.Log("111");
        }
    }
}
