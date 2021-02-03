using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConsoleControl : MonoBehaviour
{
    public Text LogText = null;

    public ScrollRect Scroll_Rect = null;

    //public InputField InputText = null;

    public Text InputText = null;

    // Start is called before the first frame update
    void Start()
    {
        LogText = GameObject.Find("Log_Text").GetComponent<Text>();
        Scroll_Rect = GameObject.Find("Scroll View").GetComponent<ScrollRect>();
        InputText = GameObject.Find("InputText").GetComponent<Text>();

        if(LogText != null)
        {
            LogText.text += " Waiting Command...." + "\n";
            //LogText.text += "/HELP";
        }
    }

    // Update is called once per frame
    void Update()
    {
        Scroll_Rect.verticalNormalizedPosition = 0.0f;
    }

    public void OnEnter()
    {
        LogText.text = LogText.text + " " + InputText.text + "\n" + " ";

        CheckCommand(InputText.text);

        //Scroll_Rect.verticalNormalizedPosition = 0.0f;
    }

    public void CheckCommand(string command)
    {
        string[] result = command.Split(' ');

        if (result[0].Equals("/help"))
        {
            LogText.text += "buy @ : Buy Something \n ";
            LogText.text += "show stat : Show Your Character Stat \n";
        }

        if (result[0].Equals("buy"))
        {
            LogText.text += "buy " + result[1] + " complete\n ";
        }

        //커맨드 입력시 처리 작성하기

        //Scroll_Rect.verticalNormalizedPosition = 0.0f;
    }
}
