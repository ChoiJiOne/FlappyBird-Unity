using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 플레이 씬 내의 설정 값 및 이벤트를 관리합니다.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// 게임의 상태를 정의하는 열거형입니다.
    /// </summary>
    /// <remarks>
    /// None: 초기화가 진행되지 않은 상태입니다.
    /// Ready: 게임을 시작하기 전입니다.
    /// Play: 게임을 플레이하는 상태입니다.
    /// GameOver: 새 오브젝트와 파이프가 충돌한 상태입니다.
    /// Done: 게임이 종료된 상태입니다.
    /// </remarks>
    public enum State
    {
        None,
        Ready,
        Play,
        GameOver,
        Done,
    }

    /// <summary>
    /// 현재의 게임 상태에 대한 프로퍼티입니다.
    /// </summary>
    /// <remarks>
    /// 게임 상태 값을 변경하면 변경 사항에 맞게 전체 게임 상태도 따라서 변경됩니다.
    /// </remarks>
    public State CurrentGameState
    {
        get { return _currentGameState; }
        set
        {
            switch (value)
            {
                case State.Ready:
                    ActiveReadyState();
                    break;

                case State.Play:
                    ActivatePlayState();
                    break;

                case State.GameOver:
                    ActiveGameOverState();
                    break;
            }
        }
    }

    /// <summary>
    /// 게임 내의 이동 속력 값입니다
    /// </summary>
    [SerializeField]
    private float _moveSpeed;

    /// <summary>
    /// 게임 내의 그라운드 오프젝트입니다.
    /// </summary>
    [SerializeField]
    private GameObject _ground;

    /// <summary>
    /// 그라운드의 움직임을 제어합니다.
    /// </summary>
    private GroundController _groundController;

    /// <summary>
    /// 게임 내의 파이프 오브젝트를 관리하는 매니저 오브젝트입니다.
    /// </summary>
    [SerializeField]
    private GameObject _pipeManager;

    /// <summary>
    /// 게임 내의 파이프 오브젝트를 관리하는 매니저 입니다.
    /// </summary>
    /// <remarks>
    /// 이 멤버 변수가 실제로 파이프를 제어합니다.
    /// </remarks>
    private PipeManager _pipeMgr;

    /// <summary>
    /// 게임 내의 플레이어가 제어하는 새 오브젝트입니다.
    /// </summary>
    [SerializeField]
    private GameObject _bird;

    /// <summary>
    /// 게임 내의 새를 제어합니다.
    /// </summary>
    private BirdController _birdController;

    /// <summary>
    /// 인 게임 캔버스 내의 GetReady UI 오브젝트입니다.
    /// </summary>
    [SerializeField]
    private GameObject _getReadyUI;

    /// <summary>
    /// 인 게임 캔버스 내의 Instructions UI 오브젝트입니다.
    /// </summary>
    [SerializeField]
    private GameObject _InstructionsUI;

    /// <summary>
    /// 인 게임 캔버스 내의 스코어를 표시하는 텍스트 UI 오브젝트입니다.
    /// </summary>
    [SerializeField]
    private GameObject _scoreUI;

    /// <summary>
    /// 현재 게임 상태입니다.
    /// </summary>
    private State _currentGameState = State.None;
    
    /// <summary>
    /// 게임 매니저가 관리해야 할 오브젝트를 제어하기 위한 컴포넌트 참조를 초기화합니다.
    /// </summary>
    private void Awake()
    {
        _groundController = _ground.GetComponent<GroundController>();
        _groundController.MoveSpeed = _moveSpeed;

        _pipeMgr = _pipeManager.GetComponent<PipeManager>();
        _pipeMgr.MoveSpeed = _moveSpeed;

        _birdController = _bird.GetComponent<BirdController>();

        this.CurrentGameState = State.Ready;
    }

    /// <summary>
    /// 게임 대기 상태를 활성화합니다.
    /// </summary>
    private void ActiveReadyState()
    {
        // 이미 대기 중인 상태라면 아무 동작도 수행하지 않습니다.
        if (_currentGameState == State.Ready)
        {
            return;
        }

        _scoreUI.SetActive(false);

        _currentGameState = State.Ready;
    }

    /// <summary>
    /// 게임 플레이 상태를 활성화합니다.
    /// </summary>
    private void ActivatePlayState()
    {
        // 이미 플레이 상태 중이거나 게임 오버 상태라면 아무 동작도 수행하지 않습니다.
        if (_currentGameState == State.Play || _currentGameState == State.GameOver)
        {
            return;
        }

        _getReadyUI.SetActive(false);
        _InstructionsUI.SetActive(false);

        _scoreUI.SetActive(true);
        _pipeMgr.Active = true;

        _currentGameState = State.Play;
    }

    /// <summary>
    /// 게임 오버 상태를 활성화합니다.
    /// </summary>
    private void ActiveGameOverState()
    {
        // 이미 게임 오버 상태라면 아무 동작도 수행하지 않습니다.
        if (_currentGameState == State.GameOver)
        {
            return;
        }

        _pipeMgr.Active = false;
        _groundController.Movable = false;

        _currentGameState = State.GameOver;
    }
}
