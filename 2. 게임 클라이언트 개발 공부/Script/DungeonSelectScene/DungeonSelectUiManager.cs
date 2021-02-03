using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DungeonSelectUiManager : MonoBehaviour
{
    public GameObject buttons;
    public Text checkEnter;

    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.Find("EnterYesOrNo");
        checkEnter = GameObject.Find("EnterYesOrNo").GetComponent<Text>();

        buttons.SetActive(false);
    }

    public void OnTutorialCheck()
    {
        checkEnter.text = "Enter Tutorial?";

        buttons.SetActive(true);
    }

    public void OnOregonCheck()
    {
        checkEnter.text = "Enter Oregon?";

        buttons.SetActive(true);
    }

    public void ButtonSetActiveFalse()
    {
        buttons.SetActive(false);
    }
}
