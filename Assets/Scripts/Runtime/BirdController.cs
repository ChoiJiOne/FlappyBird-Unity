using System.Collections;
using System.Collections.Generic;
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
    public enum BirdState
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
    private BirdState _currentState = BirdState.Idle;

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
    private readonly float _maxRotateAngle = 30.0f;

    /// <summary>
    /// ���� �ּ� ȸ�����Դϴ�.
    /// </summary>
    /// <remarks>
    /// �̶� ȸ������ ���ʺй� (ex, 30��, 60��) �����Դϴ�.
    /// </remarks>
    private readonly float _minRotateAngle = -90.0f;

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
    /// ���� ������ �� �� �ִ��� Ȯ���մϴ�.
    /// </summary>
    /// <returns>
    /// ������ �� �� �ִٸ� true, �׷��� ������ false�� ��ȯ�մϴ�.
    /// </returns>
    private bool CanJump()
    {
        return _currentState == BirdState.Idle || _currentState == BirdState.Fall;
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
