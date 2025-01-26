using System;
using System.Data;
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
    public enum State
    {
        Idle,
        Jump,
        Fall,
        Dead,
    }

    /// <summary>
    /// 새의 현재 상태와 관련 요소를 설정하는 프로퍼티입니다.
    /// </summary>
    public State CurrentState
    {
        get { return _currentState; }
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
    private State _currentState = State.Idle;

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
    private const float MAX_ROTATE_ANGLE = 30.0f;

    /// <summary>
    /// 새의 Y좌표 최대 값입니다.
    /// </summary>
    /// <remarks>
    /// 이 상수는 새가 외부로 나갈 수 없도록 조정하기 위한 값입니다.
    /// </remarks>
    private const float MAX_Y_POSITION = 5.0f;

    /// <summary>
    /// 입력 처리 시 GetMouseButtonDown에 전달할 마우스의 왼쪽 버튼 코드입니다.
    /// </summary>
    private const int LEFT_MOUSE_BUTTON_CODE = 0;

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
        switch(_currentState)
        {
            case State.Idle:
                if (CanJump())
                {
                    StartJump();
                }
                break;

            case State.Fall:
                if (CanJump())
                {
                    StartJump();
                }

                Rotate();
                break;

            case State.Jump:
                if (_rigidBody.velocity.y <= 0.0f)
                {
                    _currentState = State.Fall;
                    ActiveAnimation(false);
                }
                break;

            case State.Dead:
                break;
        }

        if (_currentState != State.Dead)
        {
            AdjustToBounds();
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
        return Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON_CODE) && (_currentState == State.Idle || _currentState == State.Fall);
    }

    /// <summary>
    /// 점프를 시작합니다.
    /// </summary>
    /// <remarks>
    /// 이 메서드는 현재 상태가 Idle 혹은 Fall 일때만 동작합니다.
    /// </remarks>
    private void StartJump()
    {
        if (_currentState == State.Jump || _currentState == State.Dead)
        {
            return;
        }

        Vector2 velocity = Vector2.zero;
        velocity.x = _rigidBody.velocity.x;
        velocity.y = _jumpSpeed;
        _rigidBody.velocity = velocity;

        transform.rotation = Quaternion.Euler(0.0f, 0.0f, MAX_ROTATE_ANGLE);

        _currentState = State.Jump;

        ActiveGravity(true);
        ActiveAnimation(true);
    }

    /// <summary>
    /// 새를 회전시킵니다.
    /// </summary>
    /// <remarks>
    /// 회전 각의 범위는 육십분법 기준으로 -90 에서 30 사이이고, 현재 상태가 Fall일때만 동작합니다.
    /// </remarks>
    private void Rotate()
    {
        if (_currentState != State.Fall)
        {
            return;
        }

        float rotateAngle = -Time.deltaTime * _rotateSpeed;
        transform.Rotate(0.0f, 0.0f, rotateAngle);

        // 2차원 평면에서 제 3사분면의 각 범위 
        const float ROTATE_START_THIRD_QUADRANT = 240.0f;
        const float ROTATE_END_THIRD_QUADRANT = 270.0f;

        float rotateEulerAngleZ = transform.rotation.eulerAngles.z;
        if (rotateEulerAngleZ < ROTATE_START_THIRD_QUADRANT || rotateEulerAngleZ > ROTATE_END_THIRD_QUADRANT)
        {
            return;
        }

        Vector3 rotateEulerAngle = Vector3.zero;
        rotateEulerAngle.z = ROTATE_END_THIRD_QUADRANT;

        transform.rotation = Quaternion.Euler(rotateEulerAngle);
    }

    /// <summary>
    /// 새가 카메라 영역을 벗어나지 못하게 위치를 조정합니다.
    /// </summary>
    private void AdjustToBounds()
    {
        if (transform.position.y < MAX_Y_POSITION)
        {
            return;
        }

        Vector3 adjustTargetPosition = transform.position;
        adjustTargetPosition.y = MAX_Y_POSITION;
        transform.position = adjustTargetPosition;
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
