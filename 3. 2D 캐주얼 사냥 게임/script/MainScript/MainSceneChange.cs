using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainSceneChange : MonoBehaviour
{
    void SceneChange()
    {
        LoadingSceneManager.LoadScene("FieldScene");
    }
}
