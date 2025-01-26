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
    /// ���� ���� �� �ִϸ��̼� Ŭ���� �����ϴ� �ִϸ����͸� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && CanJump())
        {
            Vector2 velocity = Vector2.zero;
            velocity.x = _rigidBody.velocity.x;
            velocity.y = 10.0f;
            _rigidBody.velocity = velocity;

            _currentState = BirdState.Jump;
        }

        if (_currentState == BirdState.Jump && _rigidBody.velocity.y <= 0.0f)
        {
            _currentState = BirdState.Fall;
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
}
