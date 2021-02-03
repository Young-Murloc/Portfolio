using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleManager : MonoBehaviour  //배틀에 참가할 캐릭터와 적을 불러오는 역할
{
    public UiManagerInBattleScene uiBattleScene;
    BattleInfoSender battleInfoSender = BattleInfoSender.Instance;      //처음 실행시 init 실행, 두번째 부터는 리턴만
    PrefsSave pSave = new PrefsSave();

    //프리팹 오브젝트
    public GameObject _gobjPlayer;
    public GameObject _gobjEnemy;

    //스크립트 접근 변수
    public BaseCharacter _player;        //player 오브젝트의 스크립트 컴포넌트 접근 player.getComponent<>();
    public BaseCharacter _enemy;         //enemy 오브젝트의 스크립트 컴포넌트 접근 enemy.getComponent<>();

    //hp 체크 변수
    private float _chp;
    private float _ehp;

    //턴 체크 변수
    private enum eTURN
    {
        PLAYER,
        ENEMY,
    }
    eTURN _eCurTurn;
    
    //행동 인덱스 변수
    private enum eACTION
    {
        STAND,
        ATTACK,
        DEFEND,
        SKILL,
        USEITEM,
        RUN,
    }
    eACTION _eCurAction;

    private void Start()
    {
        _eCurTurn = eTURN.PLAYER;
    }

    
    private void CheckHP()      //각 체력들을 검사하고 전투 종료를 확인
    {
        _chp = _player._bcp.GetHp();
        _ehp = _enemy._bcp.GetHp();

        if (_chp <= 0f && _ehp <= 0f)
        {
            Debug.Log("플레이어와 적 죽음");
        }
        else if (_chp <= 0f)
        {
            Debug.Log("플레이어 죽음");
        }
        else if (_ehp <= 0f)
        {
            Debug.Log("적 죽음");
            pSave.Save(_player);
        }
        else
        {
            Debug.Log("아무도 안 죽음");
        }
    }

    void UpdateUI()
    {
        uiBattleScene.UpdateCharacterUI(_player._bcp);
        uiBattleScene.UpdateEnemyUI(_enemy._bcp);
        uiBattleScene.UpdateTurnUI();
    }

    public void Attack()
    {
        _eCurAction = eACTION.ATTACK;

        ProcessTurn();
        Invoke("ProcessTurn", 5f);

        //uiBattleScene.UpdateEnemyUI(_enemy._bcp);
    }

    public void Defende()
    {
        _eCurAction = eACTION.DEFEND;

        ProcessTurn();
        Invoke("ProcessTurn", 5f);

        //uiBattleScene.UpdateCharacterUI(_player._bcp);
    }

    public void Skill()
    {
        _eCurAction = eACTION.SKILL;

        ProcessTurn();
        Invoke("ProcessTurn", 5f);

        CheckHP();

        //uiBattleScene.UpdateEnemyUI(_enemy._bcp);
    }   
    
    public void UseItem()
    {
        _eCurAction = eACTION.USEITEM;

        ProcessTurn();
        Invoke("ProcessTurn", 5f);

        Debug.Log("아이템");
        //player.UseItem();
    }

    public void Run()
    {
        _eCurAction = eACTION.RUN;

        ProcessTurn();
        Invoke("ProcessTurn", 5f);

        Debug.Log("도망");
        //player.Run();
    }

    void changeTurn()
    {
        if(_eCurTurn == eTURN.PLAYER)
        {
            _eCurTurn = eTURN.ENEMY;
        }
        else
        {
            _eCurTurn = eTURN.PLAYER;
        }
    }
    /*
    IEnumerator Delay(int time)
    {
        Debug.Log("5초 후에");
        yield return new WaitForSeconds(time);
        Debug.Log("5초 지남");
    }
    */
    public void ProcessTurn()
    {
        if (_eCurTurn.Equals(eTURN.PLAYER))
        {
            if (_eCurAction.Equals(eACTION.ATTACK))
            {
                _player.Attack(_enemy);
            }
            else if (_eCurAction.Equals(eACTION.DEFEND))
            {
                _player.Defend();
            }
            else if (_eCurAction.Equals(eACTION.SKILL))
            {
                _player.Skill(_enemy);
            }
            else if (_eCurAction.Equals(eACTION.USEITEM))
            {

            }
            else if (_eCurAction.Equals(eACTION.RUN))
            {

            }
        }
        else if (_eCurTurn.Equals(eTURN.ENEMY))
        {
            int enemyAction = Random.Range(0, 3);

            if(enemyAction == 0)
            {
                _enemy.Attack(_player);
            }
            else if(enemyAction == 1)
            {
                _enemy.Defend();
            }
            else
            {
                _enemy.Skill(_player);
            }
        }

        CheckHP();

        changeTurn();
        UpdateUI();
        //Debug.Log(_eCurTurn);
    }
}
