using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject MapCanvas;

    public void MapBtn()
    {
        MainUIsetActive(false);
        MapUIsetActive(true);
        GameObject.Find("PauseManager").GetComponent<PauseManager>().Pause();
    }

    public void MainBtn()
    {
        MainUIsetActive(true);
        MapUIsetActive(false);
        GameObject.Find("PauseManager").GetComponent<PauseManager>().UnPause();
    }

    private void MainUIsetActive(bool TF)
    {
        MainCanvas.SetActive(TF);
    }
    
    private void MapUIsetActive(bool TF)
    {
        MapCanvas.SetActive(TF);
    }

    private void Start()
    {
        MainBtn();
        MainUIsetActive(true);
        MapUIsetActive(false);
    }
}
