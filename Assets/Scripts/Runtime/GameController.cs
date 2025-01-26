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
    /// 게임 제어 신호 종류입니다.
    /// </summary>
    /// <remarks>
    /// Start : 게임 시작 신호입니다.
    /// Pause : 게임 중지 신호입니다.
    /// Resume : 게임 재개 신호입니다.
    /// GameOver : 게임 종료 신호입니다.
    /// </remarks>
    public enum Signal
    {
        Start,
        Pause,
        Resume,
        GameOver,
    }


    /// <summary>
    /// 플레이 씬 내의 새 오브젝트 컨트롤러입니다.
    /// </summary>
    private BirdController _birdController;

    /// <summary>
    /// 플레이 씬 내에 GetReady UI 오브젝트입니다.
    /// </summary>
    private GameObject _getReadyUI;

    /// <summary>
    /// 플레이 씬 내에 Instructions UI 오브젝트입니다.
    /// </summary>
    private GameObject _instructionsUI;

    /// <summary>
    /// 제어해야 할 대상 오브젝트의 참조를 초기화합니다.
    /// </summary>
    private void Awake()
    {
        _birdController = GameObject.Find("Bird").GetComponent<BirdController>();
        _getReadyUI = GameObject.Find("GetReady");
        _instructionsUI = GameObject.Find("Instructions");
    }

    /// <summary>
    /// 게임 컨트롤러에 게임 시그널을 전송합니다.
    /// </summary>
    /// <param name="signal">전송할 시그널의 종류입니다.</param>
    public void SendGameSignal(Signal signal)
    {

    }
}
