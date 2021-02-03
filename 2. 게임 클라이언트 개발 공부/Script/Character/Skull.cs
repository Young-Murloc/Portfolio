﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : BaseCharacter
{ 
    private void Start()
    {
        _bcp.SetName("skull");
        _bcp.SetAtk(3f);
        _bcp.SetDef(2f);
        _bcp.SetHp(30f);
        _bcp.SetMp(5f);
        _bcp.SetSkill("Swing");
        _bcp.SetSkillMp(3f);
        _bcp.SetCriRate(1f);
        _bcp.SetEvaRate(1f);
        
        //Debug.Log(name + GetAtk());
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

            float atk;          //몬스터 공격력

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
    
    public override void Defend()
    {
        float _def = 1f;
        _bcp.SetDef(_bcp.GetDef() + _def);
    }

    public override void Skill(BaseCharacter other)
    {
        float mp = _bcp.GetMp();

        if (mp < _bcp.GetSkillMp())
        {
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

    public override void Run()
    {
        base.Run();
    }
}