using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManagerInDungeon : MonoBehaviour
{
    public void ChangeBattleScene()
    {
        SceneManager.LoadScene("BattleScene");
    }
}
