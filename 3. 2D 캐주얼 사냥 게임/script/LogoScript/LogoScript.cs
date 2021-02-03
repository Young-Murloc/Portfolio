using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogoScript : MonoBehaviour
{
    void logoSceneChange()
    {
        //SceneManager.LoadScene("MainScene");
        LoadingSceneManager.LoadScene("MainScene");
    }
    public void fieldSceneChange()
    {
        //SceneManager.LoadScene("MainScene");
        LoadingSceneManager.LoadScene("FieldScene");
    }
}
