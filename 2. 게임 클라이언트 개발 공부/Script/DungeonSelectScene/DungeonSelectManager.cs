using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonSelectManager : MonoBehaviour
{
    public DungeonSelectUiManager _DUiManager;

    public void OnTutorial()
    {
        _DUiManager.OnTutorialCheck();
        //SceneManager.LoadScene("TutorialScene");
    }

    public void OnOregon()
    {
        _DUiManager.OnOregonCheck();
        //SceneManager.LoadScene("StoreScene");
    }

    public void OnVilla()
    {
        //SceneManager.LoadScene("StoreScene");
    }

    public void OnCoastLine()
    {
        //SceneManager.LoadScene("StoreScene");
    }

    public void OnBorder()
    {
        //SceneManager.LoadScene("StoreScene");
    }
}
