using System;
using System.Data;
using UnityEngine;

/// <summary>
/// ���� �����մϴ�.
/// </summary>
public class BirdController : MonoBehaviour
{
    /// <summary>
    /// �÷��̾ �����ϴ� ���� �����Դϴ�.
    /// </summary>
    /// <remarks>
    /// Idle: ���� ���� �� ��� �����Դϴ�.
    /// Jump: Ŭ���Ͽ� ���� ���� ���� �����Դϴ�.
    /// Fall: ������ ������ �������� �����Դϴ�.
    /// Dead: ������Ʈ�� �浹�� �����Դϴ�.
    /// </remarks>
    public enum State
    {
        Idle,
        Jump,
        Fall,
        Dead,
    }

    /// <summary>
    /// ���� ���� �� �ִϸ��̼� Ŭ���� �����մϴ�.
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// ���� ������ �� �浹 ó���� ���� ��ü(RigidBody)�Դϴ�.
    /// </summary>
    private Rigidbody2D _rigidBody;

    /// <summary>
    /// �÷��̾ �����ϴ� ���� ���� �����Դϴ�.
    /// </summary>
    private State _currentState = State.Idle;

    /// <summary>
    /// ���� ���� �ӷ��Դϴ�.
    /// </summary>
    public float _jumpSpeed;

    /// <summary>
    /// ���� ȸ�� �ӷ��Դϴ�.
    /// </summary>
    public float _rotateSpeed;

    /// <summary>
    /// ���� �ִ� ȸ�����Դϴ�.
    /// </summary>
    /// <remarks>
    /// �̶� ȸ������ ���ʺй� (ex, 30��, 60��) �����Դϴ�.
    /// </remarks>
    private const float MAX_ROTATE_ANGLE = 30.0f;

    /// <summary>
    /// �Է� ó�� �� GetMouseButtonDown�� ������ ���콺�� ���� ��ư �ڵ��Դϴ�.
    /// </summary>
    private const int LEFT_MOUSE_BUTTON_CODE = 0;

    /// <summary>
    /// ���� ���� �� �ִϸ��̼� Ŭ���� �����ϴ� �ִϸ����͸� �ʱ�ȭ�մϴ�.
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

                float rotateAngle = -Time.deltaTime * _rotateSpeed;
                transform.Rotate(0.0f, 0.0f, rotateAngle);

                float rotateEulerAngleZ = transform.rotation.eulerAngles.z;
                if (240.0f <= rotateEulerAngleZ && rotateEulerAngleZ <= 270.0f)
                {
                    rotateEulerAngleZ = 270.0f;

                    Vector3 rotateEulerAngle = Vector3.zero;
                    rotateEulerAngle.z = rotateEulerAngleZ;

                    transform.rotation = Quaternion.Euler(rotateEulerAngle);
                }
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
    }

    /// <summary>
    /// ���� ������ �� �� �ִ��� Ȯ���մϴ�.
    /// </summary>
    /// <returns>
    /// ������ �� �� �ִٸ� true, �׷��� ������ false�� ��ȯ�մϴ�.
    /// </returns>
    private bool CanJump()
    {
        return Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON_CODE) && (_currentState == State.Idle || _currentState == State.Fall);
    }

    /// <summary>
    /// ������ �����մϴ�.
    /// </summary>
    /// <remarks>
    /// �� �޼���� ���� ���°� Idle Ȥ�� Fall �϶��� �����մϴ�.
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
    /// ���� �߷� Ȱ��ȭ ���θ� �����մϴ�.
    /// </summary>
    /// <param name="isActive">���� �߷� Ȱ��ȭ �����Դϴ�. �߷��� Ȱ��ȭ�Ѵٸ� true, �׷��� ������ false�Դϴ�.</param>
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
    /// ���� �ִϸ��̼� Ȱ��ȭ ���θ� �����մϴ�.
    /// </summary>
    /// <param name="isActive">�ִϸ��̼��� Ȱ��ȭ �����Դϴ�. �ִϸ��̼��� Ȱ��ȭ�ϴٸ� true, �׷��� ������ false�Դϴ�.</param>
    private void ActiveAnimation(bool isActive)
    {
        _animator.enabled = isActive;
    }
}
