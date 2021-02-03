using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 액션 표시 클래스
public class ActionManager : MonoBehaviour
{
    // 인스펙터로 주어지는 표시 게임 오브젝트들
    public GameObject sword;
    public GameObject shield;
    public GameObject breakTime;

    // 시작시 호출됨
    public void Start()
    {
        // 중복 표시 방지를 위한 비활성화 및 활성화
        sword.SetActive(false);
        shield.SetActive(false);
        breakTime.SetActive(true);
    }
}
