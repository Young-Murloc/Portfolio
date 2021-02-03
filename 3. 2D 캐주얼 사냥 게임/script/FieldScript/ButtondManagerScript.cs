using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtondManagerScript : MonoBehaviour
{
    public void ShootButtonDown()
    {

    }

    public void ShootButtonUp()
    {
        
    }

    public void ReloadButtonDown()
    {
        
    }

    public void ReloadButtonUp()
    {
        
    }

    public void PauseBtn()
    {
        GameObject.Find("PauseManager").GetComponent<PauseManager>().PauseAndShow();
    }

    public void UnPauseBtn()
    {
        GameObject.Find("PauseManager").GetComponent<PauseManager>().UnPauseAndDis();
    }
}
