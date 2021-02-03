using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManagerInBattleScene : MonoBehaviour
{
    public BattleManager battleManager;

    //텍스트 변수들
    public Text _characterName;
    public Text _characterHp;
    public Text _characterDef;
    public Text _characterMp;
    public Text _characterSkill;

    public Text _enemyName;
    public Text _enemyHp;
    public Text _enemyDef;
    public Text _enemyMp;

    public Text _turn;

    /*
    //행동 버튼 변수들
    public Button _AtkBtn;
    public Button _DefBtn;
    public Button _SkillBtn;
    public Button _UseItemBtn;
    public Button _RunBtn;
    */

    // Start is called before the first frame update
    void Start()
    {
        //텍스트 변수 접근
        _characterName = GameObject.Find("CharacterName").GetComponent<Text>();
        _characterHp = GameObject.Find("CharacterHP").GetComponent<Text>();
        _characterDef = GameObject.Find("CharacterDEF").GetComponent<Text>();
        _characterMp = GameObject.Find("CharacterMP").GetComponent<Text>();
        _characterSkill = GameObject.Find("skillText").GetComponent<Text>();

        _enemyName = GameObject.Find("EnemyName").GetComponent<Text>();
        _enemyHp = GameObject.Find("EnemyHP").GetComponent<Text>();
        _enemyDef = GameObject.Find("EnemyDEF").GetComponent<Text>();
        _enemyMp = GameObject.Find("EnemyMP").GetComponent<Text>();

        _turn = GameObject.Find("Turn").GetComponent<Text>();

        _turn.text = "player";

        /*
        _AtkBtn.onClick.AddListener(battleManager.Attack);
        _DefBtn.onClick.AddListener(battleManager.Defende);
        _SkillBtn.onClick.AddListener(battleManager.Skill);
        _UseItemBtn.onClick.AddListener(battleManager.UseItem);
        _RunBtn.onClick.AddListener(battleManager.Run);
        */
    }

    public void UpdateEnemyUI(BaseCharacter.BaseCharacterProperty _property)
    {
        _enemyName.text = _property.GetName();
        _enemyHp.text = _property.GetHp().ToString();
        _enemyDef.text = _property.GetDef().ToString();
        _enemyMp.text = _property.GetMp().ToString();
    }

    public void UpdateCharacterUI(BaseCharacter.BaseCharacterProperty _property)
    {
        _characterName.text = _property.GetName();
        _characterHp.text = _property.GetHp().ToString();
        _characterDef.text = _property.GetDef().ToString();
        _characterMp.text = _property.GetMp().ToString();
        _characterSkill.text = _property.GetSkill();
    }

    public void UpdateTurnUI()
    {
        if(_turn.text.Equals("player"))
        {
            _turn.text = "enemy";
        }
        else
        {
            _turn.text = "player";
        }
    }
}
