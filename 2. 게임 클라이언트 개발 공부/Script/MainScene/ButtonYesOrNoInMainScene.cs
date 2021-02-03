using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonYesOrNoInMainScene : MonoBehaviour
{
    void btnStoreYes()
    {
        GameObject.Find("floor").GetComponent<FloorManager>().StoreSceneChange();
    }

    void btnStoreNo()
    {
        
    }

    void btnDungeonYes()
    {
        GameObject.Find("floor").GetComponent<FloorManager>().DungeonSceneChange();
    }

    void btnDungeonNo()
    {

    }
}
