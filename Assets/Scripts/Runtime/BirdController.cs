using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 새를 제어합니다.
/// </summary>
public class BirdController : MonoBehaviour
{
    /// <summary>
    /// 플레이어가 제어하는 새의 상태입니다.
    /// </summary>
    /// <remarks>
    /// IDLE: 게임 시작 전 대기 상태입니다.
    /// JUMP: 클릭하여 새가 점프 중인 상태입니다.
    /// FALL: 점프가 끝나고 떨어지는 상태입니다.
    /// DEAD: 오브젝트와 충돌한 상태입니다.
    /// </remarks>
    public enum BirdState
    {
        IDLE,
        JUMP,
        FALL,
        DEAD,
    }

    /// <summary>
    /// 새의 색상 별 애니메이션 클립을 제어합니다.
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// 새의 움직임 및 충돌 처리를 위한 강체(RigidBody)입니다.
    /// </summary>
    private Rigidbody2D _rigidBody;

    /// <summary>
    /// 새가 점프하는지 확인합니다. 
    /// </summary>
    /// <remarks>
    /// 새가 점프하고있다면 true, 그렇지 않으면 false입니다.
    /// </remarks>
    private bool _isJump = false;

    /// <summary>
    /// 새의 색상 별 애니메이션 클립을 제어하는 애니메이터를 초기화합니다.
    /// </summary>
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !_isJump)
        {
            Vector2 velocity = Vector2.zero;
            velocity.x = _rigidBody.velocity.x;
            velocity.y = 10.0f;
            _rigidBody.velocity = velocity;

            _isJump = true;
        }

        if (_isJump && _rigidBody.velocity.y <= 0.0f)
        {
            _isJump = false;
        }
    }
}
