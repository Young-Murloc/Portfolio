using UnityEngine;
using UnityEditor;

// 타일의 이동 모션을 계산해주는 클래스, 선형 보간 이용
public class TileMovement
{
    private Transform Tf; // 유니티 변환 객체
    private Vector3 StartPosition, EndPosition; // 시작 위치 끝 위치
    private float Time; // 0 ~ 1로 고정 됨

    public TileMovement(Transform _Tf)
    {
        Tf = _Tf; // 트랜스폼 지정
    }

    // 이동 모션 시작
    public void StartMovement(Vector3 _StartPosition, Vector3 _EndPosition)
    {
        StartPosition = _StartPosition; // 시작 위치
        EndPosition = _EndPosition; // 끝 위치
        Time = 0; // 시간 0
    }

    // 이동 모션시 매 프레임 호출되는 메서드
    public void Update()
    {
        Tf.position = GetPosition(); // 위치 얻어서 적용
    }
    
    // 이동이 끝났는지
    public bool IsEnd()
    {
        return Time >= 1; // 시간이 1 이상이면 끝났다고 리턴
    }

    // 시간 설정
    public void SetTime(float _Time)
    {
        Time = _Time; // 시간 적용
        // 0 ~ 1 사이의 값으로 구속
        if (Time < 0.0f)
            Time = 0.0f;
        if (Time > 1.0f)
            Time = 1.0f;
    }

    // 시간 더하기
    public void AddTime(float _Time)
    {
        Time += _Time; // 시간 더하기
        // 0 ~ 1 사이의 값으로 구속
        if (Time < 0.0f)
            Time = 0.0f;
        if (Time > 1.0f)
            Time = 1.0f;
    }

    // 선형 보간으로 위치 얻기
    public Vector3 GetPosition()
    {
        return StartPosition * (1 - Time) + EndPosition * Time; // 위치 계산 후 리턴
    }
}