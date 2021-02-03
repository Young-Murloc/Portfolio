using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPopup : MonoBehaviour
{
    private GameObject loadMenu;
    private GameObject newMenu;
    private GameObject settingMenu;

    void Start()
    {
        loadMenu = GameObject.Find("LoadMenu");
        newMenu = GameObject.Find("NewMenu");
        settingMenu = GameObject.Find("SettingMenu");

        loadMenu.gameObject.SetActive(false);
        newMenu.gameObject.SetActive(false);
        settingMenu.gameObject.SetActive(false);
    }

    public void loadBtn()
    {
        loadMenu.gameObject.SetActive(true);
    }

    public void newBtn()
    {
        newMenu.gameObject.SetActive(true);
    }

    public void settingBtn()
    {
        settingMenu.gameObject.SetActive(true);
    }
    public void goBack()
    {
        loadMenu.gameObject.SetActive(false);
        newMenu.gameObject.SetActive(false);
        settingMenu.gameObject.SetActive(false);
    }
    
    public void soundOnOFF()
    {
        string sound = GameObject.Find("SoundText").GetComponent<Text>().text;
        if(sound == "ON")
        {
            GameObject.Find("SoundText").GetComponent<Text>().text = "OFF";
        }
        else
        {
            GameObject.Find("SoundText").GetComponent<Text>().text = "ON";
        }
    }
}
