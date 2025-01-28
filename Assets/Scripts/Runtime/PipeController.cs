using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �÷��� �� ���� ������ ������Ʈ�� �����մϴ�.
/// </summary>
public class PipeController : MonoBehaviour
{
    /// <summary>
    /// �������� �̵� �ӷ��� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public float MoveSpeed
    {
        get { return _moveSpeed;  }
        set { _moveSpeed = value; }
    }

    /// <summary>
    /// �������� ������ ���θ� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public bool Movable
    {
        get { return _canMove;  }
        set { _canMove = value; }
    }

    /// <summary>
    /// �������� �̵� �ӷ��Դϴ�.
    /// </summary>
    private float _moveSpeed;

    /// <summary>
    /// �������� ������ �� �ִ��� Ȯ���մϴ�.
    /// </summary>
    /// <remarks>
    /// ������ ������Ʈ�� ������ �� �ִٸ� true, �׷��� ������ false�Դϴ�.
    /// </remarks>
    private bool _canMove = true;

    /// <summary>
    /// �������� �������� �����մϴ�.
    /// </summary>
    /// <remarks>
    /// �̶�, �̵��� �����ʿ��� �������� ����ǰ� �������� ��Ȱ��ȭ �Ǿ� �ִٸ� �ƹ� ���۵� �������� �ʽ��ϴ�.
    /// </remarks>
    private void Update()
    {
        // �������� ��Ȱ��ȭ �Ǹ� �ƹ� ���۵� �������� ����.
        if (!_canMove)
        {
            return;
        }

        Vector2 currentPosition = transform.position;
        currentPosition.x -= Time.deltaTime * _moveSpeed;
        transform.position = currentPosition;
    }
}