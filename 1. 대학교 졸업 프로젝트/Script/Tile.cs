using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 타일 개인 관리 클래스
public class Tile : MonoBehaviour
{
    public enum TILE_STATE
    {
        STOP, // 정지
        MOVEMENT, // 이동
        FREEFALL // 자유낙하
    };

    private BoardManager Bm; // 담당 보드매니저
    private int BoardX, BoardY; // 보드 위 좌표
    private bool isMatched; // 3개 이상 연속인지 매치 체크

    private int CharacterCode; // 캐릭터 코드

    private TILE_STATE State; // 타일 상태, 기본 정지
    
    private bool IsFalling, IsNewFallingTile; // 떨어지고 있는지, 새로 떨어지는 타일인지
    private float SpawnLinePosY; // 스폰된 타일이 그 다음 스폰을 요청할 경계선
    private int FallToX, FallToY; // 떨어지는 목표 위치

    public static bool IsSwapping = false; // 스왑되고 있는 상태인지
    private Tile SwapTarget; // 스왑할 대상 타일

    private float MovementSpeed; // 이동 속도
    private TileMovement Tm; // 이동 계산
    private TileFreeFall Tff; // 자유낙하 계산

    // 유니티가 매 프레임 호출
    void Update()
    {
        if (State == TILE_STATE.MOVEMENT) // 이동 상태면
        {
            Tm.AddTime(MovementSpeed * Time.deltaTime); // 시간 더하기
            Tm.Update(); // 내부값 업데이트
            if (IsNewFallingTile == true &&
                transform.position.y < SpawnLinePosY) // 새로 떨어지는 타일인데 다음 스폰을 요청해야 한다면
            {
                Bm.RequestSpawnNextTile(FallToX, FallToY + 1); // 다음 스폰 요청
                IsNewFallingTile = false; // 더 이상 새로 떨어지는 타일이 아님
            }
            if (Tm.IsEnd()) // 이동이 끝났다면
            {
                if (IsFalling == true) // 떨어지고 있다면
                {
                    State = TILE_STATE.STOP; // 상태를 멈춤으로
                    IsFalling = false; // 떨어지지 않는 상태
                    Bm.RequestFallTile(this, FallToX, FallToY); // 모션이 완료되었고 내부값 정정 요청
                }

                if (SwapTarget != null) // 스왑할 대상이 있다면
                {
                    State = TILE_STATE.STOP; // 멈추기
                    SwapTarget.Tm.SetTime(1.0f); // 대상의 TileMovement도 강제 끝맺음 처리
                    SwapTarget.Tm.Update(); // 대상 업데이트
                    SwapTarget.State = TILE_STATE.STOP; // 대상도 멈추기
                    Bm.RequestSwapTile(this, SwapTarget); // 모션이 완료되었고 내부값 정정 요청
                    SwapTarget.SwapTarget = null; // 대상의 스왑 대상은 더 이상 없음
                    SwapTarget = null; // 스왑 대상은 더 이상 없음
                    IsSwapping = false; // 스왑 상태 아님
                    
                    // 스왑 끝 매치 확인
                    Bm.FindMatch();
                    Bm.ClearMatch();
                }
            }
        } else if (State == TILE_STATE.FREEFALL) // 자유낙하
        {
            Tff.Update(Time.deltaTime); // 업데이트
            if (transform.position.y <= -10) // 화면에 안 보이는 저 아래로 떨어졌다면
            {
                Bm.RequestRecycleTile(this); // 타일 재활용 요청
            }
        }
    }

    // 상태 초기화 메서드
    public void ResetState()
    {
        State = TILE_STATE.STOP; // 멈춤
        isMatched = false; // 매치되지 않음
        IsFalling = false; // 떨어지지 않음
        IsNewFallingTile = false; // 새로 떨어지는 타일 아님
        SwapTarget = null; // 스왑 대상 없음

        if (Tm == null) // 객체 없으면 생성
            Tm = new TileMovement(transform);
        if (Tff == null) // 객체 없으면 생성
            Tff = new TileFreeFall(transform);
    }

    // 담당 보드 매니저 지정
    public void SetBoardManager(BoardManager _Bm, int _BoardX, int _BoardY)
    {
        Bm = _Bm; // 보드 매니저 지정
        BoardX = _BoardX; // 보드 위의 좌표 설정
        BoardY = _BoardY;
        ResetState(); // 상태 초기화
    }

    // 캐릭터 코드 및 그에 맞는 스프라이트 지정
    public void SetCharacter(int _CharacterCode, Sprite _CharacterSprite)
    {
        CharacterCode = _CharacterCode; // 캐릭터 코드 지정
        GetComponent<SpriteRenderer>().sprite = _CharacterSprite; // 해당 스프라이트 넣기
    }

    // 상태 리턴 메서드
    public TILE_STATE GetState()
    {
        return State;
    }

    // 보드상의 위치 재지정
    public void Replace(int _BoardX, int _BoardY)
    {
        BoardX = _BoardX; // 재배치된 위치 지정
        BoardY = _BoardY;
    }

    // 보드 좌표 x 리턴
    public int GetBoardX()
    {
        return BoardX;
    }

    // 보드 좌표 y 리턴
    public int GetBoardY()
    {
        return BoardY;
    }

    // 캐릭터 코드 리턴
    public int GetCharacterCode()
    {
        return CharacterCode;
    }

    // 매치 체크 표시하기
    public void SetMatched()
    {
        isMatched = true;
    }

    // 매치 체크되었는지 확인하기
    public bool IsMatched()
    {
        return isMatched;
    }

    // 주어진 타일과 인접했는지 확인
    public bool IsAdjacent(Tile Target) // 인접 확인
    {
        int DifX = BoardX - Target.BoardX; // x 차이
        int DifY = BoardY - Target.BoardY; // y 차이
        if ( ((DifX == 1 || DifX == -1) && DifY == 0) ||
            ((DifY == 1 || DifY == -1) && DifX == 0)) // 상하좌우 중 한 곳에 위치하는가
            return true; // 인접함
        return false; // 인접 안 함
    }

    // 스왑 모션 실행
    public void PlaySwapMotion(Tile Target)
    {
        if (!IsSwapping) // 스왑중이 아니라면
        {
            // 정지상태 확인
            if (State != TILE_STATE.STOP || Target.GetState() != TILE_STATE.STOP)
                return; // 아니면 취소

            IsSwapping = true; // 스왑 상태로 설정
            MovementSpeed = 5.0f; // 스왑 모션 속도 지정
            Target.MovementSpeed = 5.0f; // 스왑 대상도 스왑 모션 속도 지정

            SwapTarget = Target; // 스왑 대상 지정
            Target.SwapTarget = this; // 스왑 대상의 스왑 대상도 지정

            State = TILE_STATE.MOVEMENT; // 이동 상태로 설정
            Tm.StartMovement(transform.position, Target.transform.position); // 이동 시작

            Target.State = TILE_STATE.MOVEMENT; // 스왑 대상도 이동 상태로 설정
            Target.Tm.StartMovement(Target.transform.position, transform.position); // 스왑 대상도 이동 시작
        }
    }

    // 타일들을 매치시켜 터트릴 때 쓸 자유 낙하 모션 실행
    public void Drop()
    {
        BoardX = -1; // 탈락되어 보드 상에 좌표 배치되지 않음
        BoardY = -1;

        // 속도, 각속도 값 정하기
        float DirX = Random.Range(1, 2); // 오른쪽으로 던짐
        if (transform.position.x > 0)
            DirX *= -1; // 타일이 오른쪽에 있으면 왼쪽으로 던지기

        Vector3 Velocity = new Vector3(DirX, 5, -0.3f); // 선속도 벡터
        float AngularVelocity = 360; // 각속도
        if (Random.Range(-1, 1) < 0)
            AngularVelocity *= -1; // 회전 방향 랜덤 부여

        // 자유 낙하 상태로 바꾸기
        State = TILE_STATE.FREEFALL; // 자유 낙하 상태
        Tff.StartFreeFall(Velocity, AngularVelocity); // 자유 낙하 시작
    }

    // 밑에 타일이 비어있어서 떨어지는 추락 모션 실행
    public void Fall(int _NewBoardX, int _NewBoardY, Vector3 _NewPosition)
    {
        IsFalling = true; // 떨어지는 중

        float Len = BoardY - _NewBoardY + 0.01f; // 추락 거리
        MovementSpeed = 5.0f / Len; // 선형 보간을 이용하므로 속도를 늦춰서 같이 떨어지는 것 처럼 보이게 만든다.

        FallToX = _NewBoardX; // 떨어질 곳 위치
        FallToY = _NewBoardY;

        State = TILE_STATE.MOVEMENT; // 이동 상태로
        Tm.StartMovement(transform.position, _NewPosition); // 이동 모션 실행
    }

    // 타일 스폰시 줄줄이 다음 타일도 생성하기 위한 이벤트 설치
    public void SetSpawnEventByFalling(float _SpawnLinePosY)
    {
        if (IsFalling) // 떨어지는 중이라면
        {
            IsNewFallingTile = true; // 새로 떨어지는 타일임을 명시
            SpawnLinePosY = _SpawnLinePosY; // 다음 스폰을 발생시키는 경계선 지정
        }
    }

    // 타일 위에서 마우스 누름
    private void OnMouseDown()
    {
        Bm.ReportTileDown(this); // 보드매니저에 신고
    }

    // 타일 위에서 마우스 뗌
    private void OnMouseUp()
    {
        Bm.ReportTileUp(this); // 보드매니저에 신고
    }

    // 마우스가 타일에 접근함
    private void OnMouseEnter()
    {
        Bm.ReportTileEnter(this); // 보드 매니저에 신고
    }
}
