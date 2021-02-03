using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterYesOrNo : MonoBehaviour
{
    public DungeonSelectUiManager _DUiManager;

    public void BtnYes()
    {
        string[] result = _DUiManager.checkEnter.text.Split(' ');

        if (result[1].Equals("Tutorial?"))
        {
            SceneManager.LoadScene("TutorialScene");
        }
        else if (result[1].Equals("Oregon?"))
        {
            
        }
    }

    public void BtnNo()
    {
        _DUiManager.ButtonSetActiveFalse();
    }
}
