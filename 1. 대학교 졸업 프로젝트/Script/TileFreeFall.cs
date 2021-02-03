using UnityEngine;
using UnityEditor;

// 타일의 자유 낙하 모션을 계산해주는 클래스
public class TileFreeFall
{
    private Transform Tf; // 유니티 변환 객체
    private Vector3 Velocity; // 선속도 벡터
    private float AngularVelocity; // 각속도
    private Vector3 Gravity; // 중력 벡터

    public TileFreeFall(Transform _Tf)
    {
        Tf = _Tf; // 트랜스폼 설정
        Gravity = new Vector3(0, -9.8f, 0); // 중력 설정
    }

    // 자유 낙하 시작
    public void StartFreeFall(Vector3 _Velocity, float _AngularVelocity)
    {
        Velocity = _Velocity; // 선속도 벡터 지정
        AngularVelocity = _AngularVelocity; // 각속도 벡터 지정
    }

    // 자유 낙하시 매 프레임 호출됨
    public void Update(float _DeltaTime)
    {
        Velocity += Gravity * _DeltaTime; // 속도에 중력에 의한 가속도 적용
        Tf.position += Velocity * _DeltaTime; // 위치에 속도 적용
        Tf.localScale += new Vector3(-Tf.position.z * _DeltaTime, -Tf.position.z * _DeltaTime, 0); // 스케일을 늘려 가까이 다가오는 것 처럼 묘사
        Tf.Rotate(new Vector3(0, 0, 1), AngularVelocity * _DeltaTime); // z축 회전 적용
    }
}