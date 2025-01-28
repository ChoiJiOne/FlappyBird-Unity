using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 플레이 씬 내의 파이프 오브젝트를 제어합니다.
/// </summary>
public class PipeController : MonoBehaviour
{
    /// <summary>
    /// 파이프의 이동 속력을 설정하는 프로퍼티입니다.
    /// </summary>
    public float MoveSpeed
    {
        get { return _moveSpeed;  }
        set { _moveSpeed = value; }
    }

    /// <summary>
    /// 파이프 끝 위치의 X좌표 값을 설정하는 프로퍼티입니다.
    /// </summary>
    public float EndXPosition
    {
        get { return _endXPosition; }
        set { _endXPosition = value; }
    }

    /// <summary>
    /// 파이프의 움직임 여부를 설정하는 프로퍼티입니다.
    /// </summary>
    public bool Movable
    {
        get { return _canMove;  }
        set { _canMove = value; }
    }

    /// <summary>
    /// 파이프 매니저를 설정하는 프로퍼티입니다.
    /// </summary>
    public PipeManager PipeManager
    {
        set { _pipeManager = value; }
    }

    /// <summary>
    /// 파이프를 제어하는 매니저입니다.
    /// </summary>
    private PipeManager _pipeManager;

    /// <summary>
    /// 파이프의 이동 속력입니다.
    /// </summary>
    private float _moveSpeed;

    /// <summary>
    /// 파이프 시작 위치의 X좌표 값입니다.
    /// </summary>
    private float _startXPosition;

    /// <summary>
    /// 파이프 끝 위치의 X좌표 값입니다.
    /// </summary>
    private float _endXPosition;

    /// <summary>
    /// 파이프가 움직일 수 있는지 확인합니다.
    /// </summary>
    /// <remarks>
    /// 파이프 오브젝트가 움직일 수 있다면 true, 그렇지 않으면 false입니다.
    /// </remarks>
    private bool _canMove = true;

    /// <summary>
    /// 파이프 시작 위치의 X값을 초기화 합니다.
    /// </summary>
    private void Awake()
    {
        _startXPosition = transform.position.x;
    }

    /// <summary>
    /// 파이프의 움직임을 수행합니다.
    /// </summary>
    /// <remarks>
    /// 이때, 이동은 오른쪽에서 왼쪽으로 진행되고 움직임이 비활성화 되어 있다면 아무 동작도 수행하지 않습니다.
    /// </remarks>
    private void Update()
    {
        // 움직임이 비활성화 되면 아무 동작도 수행하지 않음.
        if (!_canMove)
        {
            return;
        }

        Vector2 currentPosition = transform.position;
        currentPosition.x -= Time.deltaTime * _moveSpeed;
        transform.position = currentPosition;

        if (currentPosition.x <= _endXPosition)
        {
            _canMove = false;

            Vector2 position;
            position.x = 5.0f;
            position.y = 1.0f;
            transform.position = position;

            _pipeManager.EnqueuePipeToWaitQueue(this.gameObject);
        }
    }
}
