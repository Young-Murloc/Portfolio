using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefsSave
{ 
    public void Save(BaseCharacter b)
    {
        PlayerPrefs.SetString("saved_name", b._bcp.GetName());
        PlayerPrefs.SetFloat("saved_atk", b._bcp.GetAtk());
        PlayerPrefs.SetFloat("saved_def", b._bcp.GetDef());
        PlayerPrefs.SetFloat("saved_hp", b._bcp.GetHp());
        PlayerPrefs.SetFloat("saved_mp", b._bcp.GetMp());
        PlayerPrefs.SetFloat("saved_crirate", b._bcp.GetCriRate());
        PlayerPrefs.SetFloat("saved_evarate", b._bcp.GetEvaRate());
        PlayerPrefs.SetString("saved_skill", b._bcp.GetSkill());
        PlayerPrefs.SetFloat("saved_skill_mp", b._bcp.GetSkillMp());

        PlayerPrefs.Save();

        Debug.Log("저장완료");
    }

    public void Load(ref BaseCharacter.BaseCharacterProperty _bcp)
    {
        _bcp.SetName(PlayerPrefs.GetString("saved_name"));
        _bcp.SetAtk(PlayerPrefs.GetFloat("saved_atk"));
        _bcp.SetDef(PlayerPrefs.GetFloat("saved_def"));
        _bcp.SetHp(PlayerPrefs.GetFloat("saved_hp"));
        _bcp.SetMp(PlayerPrefs.GetFloat("saved_mp"));
        _bcp.SetCriRate(PlayerPrefs.GetFloat("saved_crirate"));
        _bcp.SetEvaRate(PlayerPrefs.GetFloat("saved_evarate"));
        _bcp.SetSkill(PlayerPrefs.GetString("saved_skill"));
        _bcp.SetSkillMp(PlayerPrefs.GetFloat("saved_skill_mp"));
    }

    public void DeleteSaveData()
    {
        PlayerPrefs.DeleteAll();
    }
}
