using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 파이프의 움직임을 제어합니다.
/// </summary>
public class PipeController : MonoBehaviour
{    
    /// <summary>
    /// 파이프의 이동 속도를 설정하는 프로퍼티입니다.
    /// </summary>
    public float Speed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    /// <summary>
    /// 파이프의 움직임을 설정하는 프로퍼티입니다.
    /// </summary>
    public bool Movable
    {
        get { return _canMove; }
        set { _canMove = value; }
    }
    
    /// <summary>
    /// 파이프의 이동 속도입니다.
    /// </summary>
    private float _moveSpeed = 0.0f;

    /// <summary>
    /// 파이프의 움직임 여부입니다.
    /// </summary>
    private bool _canMove = false;

    /// <summary>
    /// 파이프가 움직일 수 있다면 왼쪽에서 오른쪽으로 이동합니다.
    /// </summary>
    private void Update()
    {
    }
}
