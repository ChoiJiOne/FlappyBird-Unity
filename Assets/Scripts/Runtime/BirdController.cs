using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 플레이 씬 내의 새를 제어합니다.
/// </summary>
public class BirdController : MonoBehaviour
{
    /// <summary>
    /// 플레이어가 제어하는 새의 상태입니다.
    /// </summary>
    /// <remarks>
    /// Idle: 게임 시작 전 대기 상태입니다.
    /// Jump: 클릭하여 새가 점프 중인 상태입니다.
    /// Fall: 점프가 끝나고 떨어지는 상태입니다.
    /// Dead: 오브젝트와 충돌한 상태입니다.
    /// </remarks>
    public enum State
    {
        Idle,
        Jump,
        Fall,
        Dead,
    }

    /// <summary>
    /// 새의 애니메이션을 제어합니다.
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// 새의 움직임 및 충돌 처리를 위한 강체(RigidBody)입니다.
    /// </summary>
    private Rigidbody2D _rigidbody;

    /// <summary>
    /// 애니메이션과 리지드바디의 참조를 초기화합니다.
    /// </summary>
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
    }
}
