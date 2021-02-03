﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMoveInDungeon : MonoBehaviour
{
    UiManagerInDungeon uiManagerInDungeon;

    public bool isControl = true;

    //갈수 있는곳 확인값 저장 변수
    bool isF;
    bool isB;
    bool isR;
    bool isL;

    Vector3 dirF;
    Vector3 dirB;
    Vector3 dirR;
    Vector3 dirL;

    Vector3 curPosition;

    GameObject Nirvana;

    // Start is called before the first frame update
    void Start()
    {
        isF = false;
        isB = false;
        isR = false;
        isL = false;

        dirF = new Vector3(-1, -1, 0);
        dirB = new Vector3(1, -1, 0);
        dirR = new Vector3(0, -1, 1);
        dirL = new Vector3(0, -1, -1);

        curPosition = transform.position;

        Nirvana = GameObject.Find("Nirvana");
    }

    void checkMoveAbleTile()
    {
        curPosition = transform.position;

        //레이캐스트로 갈수 있는곳 확인

        //Debug.DrawRay(curPosition, dirR, Color.blue, 3f);

        if (Physics.Raycast(curPosition, dirF, 3))
        {
            isF = true;
        }

        if (Physics.Raycast(curPosition, dirB, 3))
        {
            isB = true;
        }

        if (Physics.Raycast(curPosition, dirR, 3))
        {
            isR = true;
        }

        if (Physics.Raycast(curPosition, dirL, 3))
        {
            isL = true;
        }
    }

    void InputKey()
    {
        if (isControl == false)
            return;

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isR)
            {
                transform.Translate(0, 0, 1);
            }
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            if (isL)
            {
                transform.Translate(0, 0, -1);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (isB)
            {
                transform.Translate(1, 0, 0);
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (isF)
            {
                transform.Translate(-1, 0, 0);
            }
        }
    }

    void ResetRaycast()
    {
        isF = false;
        isB = false;
        isR = false;
        isL = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            BaseCharacter character = gameObject.GetComponent<BaseCharacter>();

            BaseCharacter enemy = other.gameObject.GetComponent<BaseCharacter>();

            BattleInfoSender battleInfoSender = BattleInfoSender.Instance;

            battleInfoSender.SetCharacter(character);
            battleInfoSender.SetEnemy(enemy);

            SceneManager.LoadScene("BattleScene");
            //Debug.Log("충돌됨");
        }
    }

    // Update is called once per frame
    void Update()
    {
        ResetRaycast();

        //레이캐스트로 갈수 있는곳 확인

        //Debug.DrawRay(curPosition, dirR, Color.blue, 3f);

        checkMoveAbleTile();

        InputKey();

    }
}