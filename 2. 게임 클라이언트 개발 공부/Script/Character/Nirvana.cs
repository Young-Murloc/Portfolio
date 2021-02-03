using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nirvana : BaseCharacter
{
    PrefsSave pSave = new PrefsSave();  //로드

    private bool _isSave;

    private void Start()
    {
        _isSave = PlayerPrefs.HasKey("saved_name");

        if (!_isSave)
        {
            Debug.Log("저장된 데이터가 없습니다.");
            _bcp.SetName("nirvana");
            _bcp.SetAtk(5f);
            _bcp.SetDef(5f);
            _bcp.SetHp(100f);
            _bcp.SetMp(30f);
            _bcp.SetCriRate(10f);
            _bcp.SetEvaRate(10f);
            _bcp.SetSkill("Bash");
            _bcp.SetSkillMp(3f);
        }
        else
        {
            Debug.Log("저장된 데이터가 있습니다.");
            pSave.Load(ref _bcp);
        }

    }

    public override void Attack(BaseCharacter other)
    {
        float _criRandom = Random.Range(0f, 100f);
        float _evaRandom = Random.Range(0f, 100f);

        if (_evaRandom <= other._bcp.GetEvaRate())
        {
            Debug.Log("회피함");
        }
        else
        {
            float hp = other._bcp.GetHp();      //적 체력
            float def = other._bcp.GetDef();    //적 방어력

            float atk;          //플레이어 공격력

            if (_criRandom <= _bcp.GetCriRate())
            {
                Debug.Log("크리티컬");
                atk = _bcp.GetAtk() * 2;
            }
            else
            {
                Debug.Log("크리티컬 실패");
                atk = _bcp.GetAtk();
            }

            if(def != 0)
            {
                atk = atk - def;
                other._bcp.SetDef(0f);
            }

            if(atk != 0)
            {
                hp = hp - atk;
                other._bcp.SetHp(hp);
            }
        }
    }

    public override void Defend()
    {
        float _def = 3f;
        _bcp.SetDef(_bcp.GetDef() + _def);
    }

    public override void Skill(BaseCharacter other)       //bash
    {
        float mp = _bcp.GetMp();

        if(mp < _bcp.GetSkillMp())
        {
            Debug.Log("마나가 부족합니다");
            Debug.Log("마나를 충전합니다");
            mp = mp + 10f;
            _bcp.SetMp(mp);
        }
        else
        {
            mp = mp - _bcp.GetSkillMp();
            _bcp.SetMp(mp);

            float hp = other._bcp.GetHp();
            float def = other._bcp.GetDef();

            float atk = _bcp.GetAtk() * 2;

            if (def != 0)
            {
                atk = atk - def;
                other._bcp.SetDef(0f);
            }

            if (atk != 0)
            {
                hp = hp - atk;
                other._bcp.SetHp(hp);
            }
        }
    }

    public override void UseItem()
    {

    }

    public override void Run()
    {
        
    }

}