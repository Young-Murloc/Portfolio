using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleInfoSender : SingletonGOB<BattleInfoSender>
{
    //public UiManagerInBattleScene uiBattleScene;

    public BaseCharacter.BaseCharacterProperty _enemyProperty;
    public BaseCharacter.BaseCharacterProperty _playerProperty;

    public BaseCharacter _enemy;
    public BaseCharacter _player;

    protected override void Init()      //스크립트 실행시 먼저 실행되는 부분
    {
        _enemyProperty = new BaseCharacter.BaseCharacterProperty();
        _playerProperty = new BaseCharacter.BaseCharacterProperty();
    }

    //전달해줄 적의 정보
    public void SetEnemy(BaseCharacter b)
    {
        _enemy = b;
        _enemyProperty = b._bcp;
    }

    public void SetCharacter(BaseCharacter b)
    {
        _player = b;
        _playerProperty = b._bcp;
    }
    
    /*
    public void CreateEnemy()       //battleScene에서 호출
    {
        //분기에 따른 프리팹
        //uiBattleScene.UpdateCharacterUI(_characterProperty);

        //uiBattleScene.UpdateEnemyUI(_enemyProperty);
    }
     */
}
