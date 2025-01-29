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
    /// Ready: 게임을 시작하기 전입니다.
    /// Play: 게임을 플레이하는 상태입니다.
    /// GameOver: 게임이 종료된 상태입니다.
    /// </remarks>
    public enum State
    {
        Ready,
        Play,
        GameOver,
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
    /// 현재 게임 상태입니다.
    /// </summary>
    private State _currentGameState = State.Ready;

    /// <summary>
    /// 게임의 준비 (State.Ready) 상태일 때의 오브젝트 목록입니다.
    /// </summary>
    [SerializeField]
    private GameObject[] _readyStateObjects;
    
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
    }
}
