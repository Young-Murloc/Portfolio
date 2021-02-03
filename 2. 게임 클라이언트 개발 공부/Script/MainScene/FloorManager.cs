using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StoreSceneChange()
    {
        SceneManager.LoadScene("StoreScene");
    }

    public void DungeonSceneChange()
    {
        SceneManager.LoadScene("DungeonSelectScene");
    }
}
