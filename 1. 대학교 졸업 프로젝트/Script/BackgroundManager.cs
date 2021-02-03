using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 백그라운드 이동 모션 관리 클래스
public class BackgroundManager : MonoBehaviour
{
    public GameObject[] BGList; // 백그라운드 객체 배열
    Vector3 offset; // 옮길 때 쓸 기준 백그라운드 위치
    float speed = 0.7f; // 이동 속도

    // 매 프레임마다 호출
    void FixedUpdate()
    {
        // 백그라운드 객체마다 적용
        for (int i = 0; i < BGList.Length; i++)
        {
            BGList[i].transform.position += Vector3.left * speed * Time.deltaTime; // 이동시키기

            // 백그라운드를 이동시키며 계속해서 보여주어야 하므로 하나가 화면에서 벗어나면 다시 위치를 조정해준다.
            if (BGList[i].transform.position.x < -29.0f) // 화면을 벗어나서 보이지 않으면
            {
                if(i==0) // 0번 백그라운드 일 경우
                {
                    offset = BGList[i + 1].transform.position; // 1번 백그라운드를 기준으로
                }
                else // 1번 백그라운드 일 경우
                {
                    offset = BGList[i - 1].transform.position; // 0번 백그라운드를 기준으로
                }
                BGList[i].transform.position = new Vector3(49.6f + offset.x, -0.5f, 0.0f); // 위치 이동
            }
        }
    }
}