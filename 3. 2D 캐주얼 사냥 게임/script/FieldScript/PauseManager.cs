using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject MainCanvas;

    private int MainCanvasCC = 0;

    private GameObject tempObj;

    public void PauseAndShow()
    {
        MainCanvasCC = MainCanvas.transform.childCount;

        for (int i = 0; i < MainCanvasCC; i++)
        {
            tempObj = MainCanvas.transform.GetChild(i).gameObject;
            if (tempObj.name == "Pause")
            {
                tempObj.SetActive(true);
            }
            else
            {
                tempObj.SetActive(false);
            }
        }

        Time.timeScale = 0;
    }

    public void UnPauseAndDis()
    {
        MainCanvasCC = MainCanvas.transform.childCount;

        for (int i = 0; i < MainCanvasCC; i++)
        {
            if (tempObj.name == "Pause")
            {
                tempObj.SetActive(false);
            }
            else
            {
                tempObj.SetActive(true);
            }
        }

        Time.timeScale = 1;
    }

    public void Pause()
    {
        Time.timeScale = 0;
    }

    public void UnPause()
    {
        Time.timeScale = 1;
    }
}
