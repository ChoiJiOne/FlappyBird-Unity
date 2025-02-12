using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 난이도입니다.
/// </summary>
/// <remarks>
/// Easy: 쉬움
/// Normal: 보통
/// Hard: 어려움
/// </remarks>
[Serializable]
public enum Level
{
    Easy   = 0,
    Normal = 1,
    Hard   = 2,
}


[Serializable]
public struct GameLevelOption
{
    /// <summary>
    /// 게임 레벨입니다.
    /// </summary>
    public Level level;

    /// <summary>
    /// 게임 내의 파이프와 바닥의 이동 속력입니다.
    /// </summary>
    public float moveSpeed;

    /// <summary>
    /// 파이프의 활성화 시간입니다.
    /// </summary>
    public float pipeActiveTime;
}

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
    /// Pause: 게임 중지 상태입니다.
    /// GameOver: 새 오브젝트와 파이프가 충돌한 상태입니다.
    /// Done: 게임이 종료된 상태입니다.
    /// </remarks>
    public enum State
    {
        None,
        Ready,
        Play,
        Pause,
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

                case State.Done:
                    ActiveDoneState();
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
    /// 게임을 중지시키는 버튼 UI 오브젝트입니다.
    /// </summary>
    [SerializeField]
    private GameObject _pauseButtonUI;

    /// <summary>
    /// 중지된 게임을 다시 재개시키는 버튼 UI 오브젝트입니다.
    /// </summary>
    [SerializeField]
    private GameObject _resumeButtonUI;

    /// <summary>
    /// 인 게임 캔버스 내의 스코어를 표시하는 텍스트 UI 오브젝트입니다.
    /// </summary>
    [SerializeField]
    private GameObject _scoreUI;

    /// <summary>
    /// 게임을 종료하고 플레이어가 획득한 점수, 최고 기록, 획득 메달을 표시하는 UI 오브젝트입니다.
    /// </summary>
    [SerializeField]
    private GameObject _scoreBoardUI;

    /// <summary>
    /// 스코어 UI를 제어합니다.
    /// </summary>
    private ScoreUIController _scoreUIController;

    /// <summary>
    /// 플레이어의 레벨 키 값입니다.
    /// </summary>
    /// <remarks>
    /// EASY: 0
    /// NORMAL: 1
    /// HARD: 2
    /// </remarks>
    static string s_playerLevelKey = "Level";

    /// <summary>
    /// 현재 플레이 난이도입니다.
    /// </summary>
    private Level _currentLevel = Level.Easy;
    
    /// <summary>
    /// 현재 게임의 난이도에 따른 옵션입니다.
    /// </summary>
    [SerializeField]
    private GameLevelOption[] _gameLevelOptions;

    /// <summary>
    /// 현재 게임 상태입니다.
    /// </summary>
    private State _currentGameState = State.None;
    
    /// <summary>
    /// 게임 매니저가 관리해야 할 오브젝트를 제어하기 위한 컴포넌트 참조를 초기화합니다.
    /// </summary>
    private void Awake()
    {
        if (PlayerPrefs.HasKey(s_playerLevelKey))
        {
            _currentLevel = (Level)(PlayerPrefs.GetInt(s_playerLevelKey));
        }

        _groundController = _ground.GetComponent<GroundController>();
        _pipeMgr = _pipeManager.GetComponent<PipeManager>();
        _birdController = _bird.GetComponent<BirdController>();
        _scoreUIController = _scoreBoardUI.GetComponent<ScoreUIController>();

        ApplyGameLevelOption(_currentLevel);

        this.CurrentGameState = State.Ready;
    }

    private void ApplyGameLevelOption(Level level)
    {
        int gameLevelOptionIndex = (int)(level);

        _groundController.MoveSpeed = _gameLevelOptions[gameLevelOptionIndex].moveSpeed;
        _pipeMgr.MoveSpeed = _gameLevelOptions[gameLevelOptionIndex].moveSpeed;
        _pipeMgr.ActivePipeTime = _gameLevelOptions[gameLevelOptionIndex].pipeActiveTime;
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

        _pauseButtonUI.SetActive(false);
        _resumeButtonUI.SetActive(false);
        _scoreUI.SetActive(false);
        _scoreBoardUI.SetActive(false);

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

        _pauseButtonUI.SetActive(true);
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

        _pauseButtonUI.SetActive(false);
        _resumeButtonUI.SetActive(false);

        _pipeMgr.Active = false;
        _groundController.Movable = false;

        _currentGameState = State.GameOver;
    }

    /// <summary>
    /// 게임 종료 상태를 활성화합니다.
    /// </summary>
    private void ActiveDoneState()
    {
        // 이미 게임 종료 상태라면 아무 동작도 수행하지 않습니다.
        if (_currentGameState == State.Done)
        {
            return;
        }

        _scoreUI.SetActive(false);
        _scoreBoardUI.SetActive(true);

        int score = _birdController.Score;
        _scoreUIController.PlayerScore = score;

        _currentGameState = State.Done;
    }

    /// <summary>
    /// 게임 중지 버튼을 클릭했을 때 실행할 이벤트입니다.
    /// </summary>
    public void OnClickPauseButton()
    {
        SetActiveMovableObjects(false);
        _currentGameState = State.Pause;
    }

    /// <summary>
    /// 게임 재개 버튼을 클릭했을 때 실행할 이벤트입니다.
    /// </summary>
    public void OnClickResumeButton()
    {
        SetActiveMovableObjects(true);
        _currentGameState = State.Play;
    }

    /// <summary>
    /// 움직임이 있는 오브젝트들의 활성화 여부를 설정합니다.
    /// </summary>
    /// <param name="bIsActive">움직임 활성화 여부입니다.</param>
    private void SetActiveMovableObjects(bool bIsActive)
    {
        _groundController.Movable = bIsActive;
        _pipeMgr.Active = bIsActive;
        _birdController.Movable = bIsActive;
        _birdController.Gravity = bIsActive;
        _birdController.Animation = bIsActive;

        _pauseButtonUI.SetActive(bIsActive);
        _resumeButtonUI.SetActive(!bIsActive);
    }
}
