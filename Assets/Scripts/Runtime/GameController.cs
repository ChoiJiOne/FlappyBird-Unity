using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임을 제어(시작, 중지, 종료)합니다.
/// </summary>
/// <remarks>
/// 이 스크립트는 플레이 씬 내의 GameController 오브젝트와 함께 동작합니다.
/// </remarks>
public class GameController : MonoBehaviour
{
    /// <summary>
    /// 플레이 씬 내의 새 오브젝트 컨트롤러입니다.
    /// </summary>
    private BirdController _birdController;

    /// <summary>
    /// 플레이 씬 내의 바닥 움직임을 제어합니다.
    /// </summary>
    private GroundScroller _groundScroller;

    /// <summary>
    /// 플레이 씬 내에 GetReady UI 오브젝트입니다.
    /// </summary>
    private GameObject _getReadyUI;

    /// <summary>
    /// 플레이 씬 내에 Instructions UI 오브젝트입니다.
    /// </summary>
    private GameObject _instructionsUI;

    /// <summary>
    /// 플레이 씬 내에 PauseButton UI 오브젝트입니다.
    /// </summary>
    private GameObject _pauseButtonUI;

    /// <summary>
    /// 플레이 씬 내에 ResumeButton UI 오브젝트입니다.
    /// </summary>
    private GameObject _resumeButtonUI;

    /// <summary>
    /// 플레이 씬 내의 파이프 스케줄러입니다.
    /// </summary>
    /// <remarks>
    /// 파이프 관련 제어를 수행하기 위해서는 이 오브젝트를 이용해야 합니다.
    /// </remarks>
    private PipeScheduler _pipeScheduler;

    /// <summary>
    /// 제어해야 할 대상 오브젝트의 참조를 초기화합니다.
    /// </summary>
    private void Awake()
    {
        _birdController = GameObject.Find("Bird").GetComponent<BirdController>();
        _groundScroller = GameObject.Find("Ground").GetComponent<GroundScroller>();
        _pipeScheduler = GameObject.Find("PipeScheduler").GetComponent<PipeScheduler>();
        _getReadyUI = GameObject.Find("GetReady");
        _instructionsUI = GameObject.Find("Instructions");
        _pauseButtonUI = GameObject.Find("PauseButton");
        _resumeButtonUI = GameObject.Find("ResumeButton");

        _pauseButtonUI.SetActive(false);
        _resumeButtonUI.SetActive(false);
    }

    /// <summary>
    /// 게임 시작 시그널에 맞는 동작을 수행합니다.
    /// </summary>
    public void OnProcessStartGameSignal()
    {
        _getReadyUI.SetActive(false);
        _instructionsUI.SetActive(false);
        _pauseButtonUI.SetActive(true);

        _pipeScheduler.BeginScheduling();
    }

    /// <summary>
    /// 게임 중지 시그널에 맞는 동작을 수행합니다.
    /// </summary>
    public void OnProcessPauseGameSignal()
    {
        _pauseButtonUI.SetActive(false);
        _resumeButtonUI.SetActive(true);

        _groundScroller.Movable = false;
        _birdController.Movable = false;
    }

    /// <summary>
    /// 게임 재개 시그널에 맞는 동작을 수행합니다.
    /// </summary>
    public void OnProcessResumeGameSignal()
    {
        _pauseButtonUI.SetActive(true);
        _resumeButtonUI.SetActive(false);

        _groundScroller.Movable = true;
        _birdController.Movable = true;
    }

    /// <summary>
    /// 게임 오버 시그널에 맞는 동작을 수행합니다.
    /// </summary>
    public void OnProcessGameOverSignal()
    {
        _pauseButtonUI.SetActive(false);
        _resumeButtonUI.SetActive(false);

        _groundScroller.Movable = false;
        _birdController.Movable = false;
    }
}
