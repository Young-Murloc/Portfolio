using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCharacter : MonoBehaviour
{
    public struct BaseCharacterProperty
    {
        private string _name;
        private float _atk;
        private float _def;
        private float _hp;
        private float _mp;
        private float _criRate;
        private float _evaRate;
        private string _skill;
        private float _skillMp;

        public void SetName(string name) { _name = name; }
        public string GetName() { return _name; }

        public void SetAtk(float atk) { _atk = atk; }
        public float GetAtk() { return _atk; }

        public void SetDef(float def) { _def = def; }
        public float GetDef() { return _def; }

        public void SetHp(float hp) { _hp = hp; }
        public float GetHp() { return _hp; }

        public void SetMp(float mp) { _mp = mp; }
        public float GetMp() { return _mp; }

        public void SetCriRate(float crirate) { _criRate = crirate; }
        public float GetCriRate() { return _criRate; }

        public void SetEvaRate(float evarate) { _evaRate = evarate; }
        public float GetEvaRate() { return _evaRate; }

        public void SetSkill(string skill) { _skill = skill; }
        public string GetSkill() { return _skill; }

        public void SetSkillMp(float skillMp) { _skillMp = skillMp; }
        public float GetSkillMp() { return _skillMp; }
    }

    public BaseCharacterProperty _bcp;

    public BaseCharacterProperty GetBCP()
    {
        return _bcp;
    }

    public void SetBCP(BaseCharacterProperty bcp)
    {
        _bcp.SetName(bcp.GetName());
        _bcp.SetAtk(bcp.GetAtk());
        _bcp.SetDef(bcp.GetDef());
        _bcp.SetHp(bcp.GetHp());
        _bcp.SetMp(bcp.GetMp());
        _bcp.SetCriRate(bcp.GetCriRate());
        _bcp.SetEvaRate(bcp.GetEvaRate());
        _bcp.SetSkill(bcp.GetSkill());
    }

    /*
    public void SetProperty( BaseCharacterProperty tmp )
    {
        _bcp = tmp;
    }
    
    /*
    public BaseCharacterProperty BCP
    { 
        get { return _bcp; }
        set { _bcp = value;  }
    }
    */

    public virtual void Attack(BaseCharacter other)
    {

    }

    public virtual void Defend()
    {

    }

    public virtual void Skill(BaseCharacter other)
    {

    }
    
    public virtual void UseItem()
    {

    }

    public virtual void Run()
    {

    }
}
