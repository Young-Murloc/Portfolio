using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCharacterAndEnemy : MonoBehaviour
{
    public BattleManager bm;
    BattleInfoSender bis = BattleInfoSender.Instance;
    public UiManagerInBattleScene uiBattleScene;

    //프리팹용 변수
    public GameObject _nirvana;
    public GameObject _skull;

    //위치 변경용 변수
    public GameObject _playerPOS;
    public GameObject _enemyPOS;

    // Start is called before the first frame update
    void Start()
    {
        //프리팹 생성
        if (bis._playerProperty.GetName().Equals("nirvana"))
        {

            bm._gobjPlayer = GameObject.Instantiate(_nirvana);
            bm._player = bm._gobjPlayer.GetComponent<Nirvana>();
            bm._player.SetBCP(bis._player.GetBCP());
        }

        if (bis._enemyProperty.GetName().Equals("skull"))
        {
            bm._gobjEnemy = GameObject.Instantiate(_skull);
            bm._enemy = bm._gobjEnemy.GetComponent<Skull>();
            bm._enemy.SetBCP(bis._enemy.GetBCP());
        }

        //battleinfosender에서 받아와서 확인 

        bm._gobjPlayer.transform.position = _playerPOS.transform.position;
        bm._gobjEnemy.transform.position = _enemyPOS.transform.position;

        uiBattleScene.UpdateCharacterUI(bm._player._bcp);
        uiBattleScene.UpdateEnemyUI(bm._enemy._bcp);
    }

    /*
    // Update is called once per frame
    void Update()
    {
        uiBattleScene.UpdateCharacterUI(bis._characterProperty);
        uiBattleScene.UpdateEnemyUI(bis._enemyProperty);
    }
    */
}
