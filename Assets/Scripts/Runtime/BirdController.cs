using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 게임 플레이 씬 내의 새를 제어합니다.
/// </summary>
public class BirdController : MonoBehaviour
{
    /// <summary>
    /// 새의 움직임 여부를 설정합니다.
    /// </summary>
    public bool Movable
    {
        set
        {
            SetActiveGravity(value);
            SetActiveAnimation(value);
        }
    }

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
    /// 현재 새의 상태입니다.
    /// </summary>
    private State _currentState = State.Idle;

    /// <summary>
    /// 점프 속력입니다.
    /// </summary>
    [SerializeField]
    private float _jumpSpeed;

    /// <summary>
    /// 회전 속력입니다.
    /// </summary>
    [SerializeField]
    private float _rotateSpeed;

    /// <summary>
    /// 입력 처리 시 GetMouseButtonDown에 전달할 마우스의 왼쪽 버튼 코드입니다.
    /// </summary>
    private const int LEFT_MOUSE_BUTTON_CODE = 0;

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

    /// <summary>
    /// 새가 점프를 뛸 수 있는지 확인합니다.
    /// </summary>
    /// <returns>
    /// 점프를 뛸 수 있다면 true, 그렇지 않으면 false를 반환합니다.
    /// </returns>
    private bool CanJump()
    {
        return Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON_CODE) && (_currentState == State.Idle || _currentState == State.Fall);
    }

    /// <summary>
    /// 새의 중력 활성화 여부를 설정합니다.
    /// </summary>
    /// <param name="isActive">새의 중력 활성화 여부입니다. 중력을 활성화한다면 true, 그렇지 않으면 false입니다.</param>
    private void SetActiveGravity(bool isActive)
    {
        _rigidbody.simulated = isActive;
    }

    /// <summary>
    /// 새의 애니메이션 활성화 여부를 설정합니다.
    /// </summary>
    /// <param name="isActive">애니메이션의 활성화 여부입니다. 애니메이션을 활성화하다면 true, 그렇지 않으면 false입니다.</param>
    private void SetActiveAnimation(bool isActive)
    {
        _animator.enabled = isActive;
    }
}
