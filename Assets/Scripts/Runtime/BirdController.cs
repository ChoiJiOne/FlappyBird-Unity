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
    /// Idle: 게임 시작 전 대기 상태입니다.
    /// Jump: 클릭하여 새가 점프 중인 상태입니다.
    /// Fall: 점프가 끝나고 떨어지는 상태입니다.
    /// Dead: 오브젝트와 충돌한 상태입니다.
    /// </remarks>
    public enum BirdState
    {
        Idle,
        Jump,
        Fall,
        Dead,
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
    /// 플레이어가 제어하는 새의 현재 상태입니다.
    /// </summary>
    private BirdState _currentState = BirdState.Idle;

    /// <summary>
    /// 새의 점프 속력입니다.
    /// </summary>
    public float _jumpSpeed;

    /// <summary>
    /// 새의 회전 속력입니다.
    /// </summary>
    public float _rotateSpeed;

    /// <summary>
    /// 새의 최대 회전각입니다.
    /// </summary>
    /// <remarks>
    /// 이때 회전각은 육십분법 (ex, 30도, 60도) 기준입니다.
    /// </remarks>
    private readonly float _maxRotateAngle = 30.0f;

    /// <summary>
    /// 새의 최소 회전각입니다.
    /// </summary>
    /// <remarks>
    /// 이때 회전각은 육십분법 (ex, 30도, 60도) 기준입니다.
    /// </remarks>
    private readonly float _minRotateAngle = -90.0f;

    /// <summary>
    /// 새의 색상 별 애니메이션 클립을 제어하는 애니메이터를 초기화합니다.
    /// </summary>
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
        
        ActiveGravity(false);
        ActiveAnimation(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanJump())
        {
            Vector2 velocity = Vector2.zero;
            velocity.x = _rigidBody.velocity.x;
            velocity.y = _jumpSpeed;
            _rigidBody.velocity = velocity;

            _currentState = BirdState.Jump;
            ActiveGravity(true);
            ActiveAnimation(true);
        }

        if (_currentState == BirdState.Jump && _rigidBody.velocity.y <= 0.0f)
        {
            _currentState = BirdState.Fall;
            ActiveAnimation(false);
        }
    }

    /// <summary>
    /// 새가 점프를 뛸 수 있는지 확인합니다.
    /// </summary>
    /// <returns>
    /// 점프를 뛸 수 있다면 true, 그렇지 않으면 false를 반환합니다.
    /// </returns>
    private bool CanJump()
    {
        return _currentState == BirdState.Idle || _currentState == BirdState.Fall;
    }

    /// <summary>
    /// 새의 중력 활성화 여부를 설정합니다.
    /// </summary>
    /// <param name="isActive">새의 중력 활성화 여부입니다. 중력을 활성화한다면 true, 그렇지 않으면 false입니다.</param>
    private void ActiveGravity(bool isActive)
    {
        float gravityScale = 0.0f;
        if (isActive)
        {
            gravityScale = 1.0f;
        }

        _rigidBody.gravityScale = gravityScale;
    }

    /// <summary>
    /// 새의 애니메이션 활성화 여부를 설정합니다.
    /// </summary>
    /// <param name="isActive">애니메이션의 활성화 여부입니다. 애니메이션을 활성화하다면 true, 그렇지 않으면 false입니다.</param>
    private void ActiveAnimation(bool isActive)
    {
        _animator.enabled = isActive;
    }
}
