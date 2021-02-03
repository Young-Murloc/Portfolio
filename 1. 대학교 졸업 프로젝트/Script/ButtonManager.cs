using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// 버튼을 누를 경우 호출되는 이벤트 메서드들을 모아놓은 클래스
public class ButtonManager : MonoBehaviour
{
    // 플레이 버튼
    public void ClickPlay()
    {
        SceneManager.LoadScene("Main"); // 메인 씬으로
    }

    // 시작 버튼
    public void ClickStart()
    {
        SceneManager.LoadScene("Game"); // 게임 씬으로
    }

    // 설정 버튼
    public void ClickSetting()
    {
        SceneManager.LoadScene("Setting"); // 설정 씬으로
    }

    // 상점 버튼
    public void ClickStore()
    {
        SceneManager.LoadScene("Store"); // 상점 씬으로
    }

    // 선물 버튼
    public void ClickGift()
    {
        SceneManager.LoadScene("Gift"); // 선물 씬으로
    }
}
