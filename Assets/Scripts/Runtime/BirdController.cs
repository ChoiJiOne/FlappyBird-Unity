using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �÷��� �� ���� ���� �����մϴ�.
/// </summary>
public class BirdController : MonoBehaviour
{
    /// <summary>
    /// ���� ������ ���θ� �����մϴ�.
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
    /// ���� �ִϸ��̼��� �����մϴ�.
    /// </summary>
    private Animator _animator;

    /// <summary>
    /// ���� ������ �� �浹 ó���� ���� ��ü(RigidBody)�Դϴ�.
    /// </summary>
    private Rigidbody2D _rigidbody;

    /// <summary>
    /// ���� ���� �����Դϴ�.
    /// </summary>
    private State _currentState = State.Idle;

    /// <summary>
    /// ���� �ӷ��Դϴ�.
    /// </summary>
    [SerializeField]
    private float _jumpSpeed;

    /// <summary>
    /// ȸ�� �ӷ��Դϴ�.
    /// </summary>
    [SerializeField]
    private float _rotateSpeed;

    /// <summary>
    /// �Է� ó�� �� GetMouseButtonDown�� ������ ���콺�� ���� ��ư �ڵ��Դϴ�.
    /// </summary>
    private const int LEFT_MOUSE_BUTTON_CODE = 0;

    /// <summary>
    /// �ִϸ��̼ǰ� ������ٵ��� ������ �ʱ�ȭ�մϴ�.
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
    /// ���� �߷� Ȱ��ȭ ���θ� �����մϴ�.
    /// </summary>
    /// <param name="isActive">���� �߷� Ȱ��ȭ �����Դϴ�. �߷��� Ȱ��ȭ�Ѵٸ� true, �׷��� ������ false�Դϴ�.</param>
    private void SetActiveGravity(bool isActive)
    {
        _rigidbody.simulated = isActive;
    }

    /// <summary>
    /// ���� �ִϸ��̼� Ȱ��ȭ ���θ� �����մϴ�.
    /// </summary>
    /// <param name="isActive">�ִϸ��̼��� Ȱ��ȭ �����Դϴ�. �ִϸ��̼��� Ȱ��ȭ�ϴٸ� true, �׷��� ������ false�Դϴ�.</param>
    private void SetActiveAnimation(bool isActive)
    {
        _animator.enabled = isActive;
    }
}
