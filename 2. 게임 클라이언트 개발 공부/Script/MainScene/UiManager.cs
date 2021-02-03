using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    PlayerControllerInMainScene _player;
    FloorManager _floorManager;

    public GameObject StoreArea;
    public GameObject DungeonArea;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("player").GetComponent<PlayerControllerInMainScene>();
        _floorManager = GameObject.Find("Floor").GetComponent<FloorManager>();

        StoreArea = GameObject.Find("StoreArea");
        DungeonArea = GameObject.Find("DungeonArea");

        StoreArea.SetActive(false);
        DungeonArea.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StoreAreaTrue()
    {
        StoreArea.SetActive(true);
    }
    public void StoreAreaFalse()
    {
        StoreArea.SetActive(false);
    }

    public void DungeonAreaTrue()
    {
        DungeonArea.SetActive(true);
    }
    public void DungeonAreaFalse()
    {
        DungeonArea.SetActive(false);
    }

    public void btnStoreYes()
    {
        _floorManager.StoreSceneChange();
    }

    public void btnStoreNo()
    {
        _player.GoBack();
    }

    public void btnDungeonYes()
    {
        _floorManager.DungeonSceneChange();
    }

    public void btnDungeonNo()
    {
        _player.GoBack();
    }
}
