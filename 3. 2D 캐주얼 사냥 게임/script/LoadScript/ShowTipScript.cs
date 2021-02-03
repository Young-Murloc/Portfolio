using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowTipScript : MonoBehaviour
{
    private string[] tip = {"위시(29): 조울증이 있음",
                            "존(35): 자라나라 머리머리",
                            "주인공의 선택에 따라 결과가 달라집니다"};

    int rand;

    // Start is called before the first frame update
    void Start()
    {
        rand = Random.Range(0, 3);

        GameObject.Find("TipText").GetComponent<Text>().text = tip[rand];
    }
}
