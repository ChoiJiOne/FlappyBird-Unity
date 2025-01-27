using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 플레이 씬 내의 파이프 오브젝트를 제어합니다.
/// </summary>
public class PipeController : MonoBehaviour
{
    /// <summary>
    /// 파이프의 움직임 여부를 설정하는 프로퍼티입니다.
    /// </summary>
    public bool Movable
    {
        get { return _canMove;  }
        set { _canMove = value; }
    }

    /// <summary>
    /// 파이프의 이동 속도입니다.
    /// </summary>
    [SerializeField]
    private float _moveSpeed;

    /// <summary>
    /// 파이프가 움직일 수 있는지 확인합니다.
    /// </summary>
    /// <remarks>
    /// 파이프 오브젝트가 움직일 수 있다면 true, 그렇지 않으면 false입니다.
    /// </remarks>
    private bool _canMove = true;

    private void Start()
    {
        
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
    }
}
