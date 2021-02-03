using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogMoveManager : MonoBehaviour
{
    public GameObject[] FGList; // 안개 객체 배열
    Vector3 offset; // 옮길 때 쓸 기준 백그라운드 위치
    public float _speed = 10f; // 이동 속도

    // 매 프레임마다 호출
    void Update()
    {
        for(int i=0; i<FGList.Length; i++)
        {
            FGList[i].transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
    }
}
