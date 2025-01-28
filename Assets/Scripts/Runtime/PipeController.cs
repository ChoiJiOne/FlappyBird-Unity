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
    /// ������ �� ��ġ�� X��ǥ ���� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public float EndXPosition
    {
        get { return _endXPosition; }
        set { _endXPosition = value; }
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
    /// ������ �Ŵ����� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public PipeManager PipeManager
    {
        set { _pipeManager = value; }
    }

    /// <summary>
    /// ���� �������� Y��ǥ ���� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public float YPosition
    {
        set
        {
            _currentYPosition = value;

            Vector2 currentPosition = transform.position;
            currentPosition.y = _currentYPosition;

            transform.position = currentPosition;
        }
    }

    /// <summary>
    /// �������� �����ϴ� �Ŵ����Դϴ�.
    /// </summary>
    private PipeManager _pipeManager;

    /// <summary>
    /// �������� �̵� �ӷ��Դϴ�.
    /// </summary>
    private float _moveSpeed;

    /// <summary>
    /// ������ ���� ��ġ�� X��ǥ ���Դϴ�.
    /// </summary>
    private float _startXPosition;

    /// <summary>
    /// ������ �� ��ġ�� X��ǥ ���Դϴ�.
    /// </summary>
    private float _endXPosition;

    /// <summary>
    /// ���� �������� Y��ǥ ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// �� ���� ������ �Ŵ����� �̿��ؼ� ������ ������ �����˴ϴ�.
    /// </remarks>
    private float _currentYPosition;

    /// <summary>
    /// �������� ������ �� �ִ��� Ȯ���մϴ�.
    /// </summary>
    /// <remarks>
    /// ������ ������Ʈ�� ������ �� �ִٸ� true, �׷��� ������ false�Դϴ�.
    /// </remarks>
    private bool _canMove = true;

    /// <summary>
    /// ������ ���� ��ġ�� X���� �ʱ�ȭ �մϴ�.
    /// </summary>
    private void Awake()
    {
        _startXPosition = transform.position.x;
    }

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

        if (currentPosition.x <= _endXPosition)
        {
            _canMove = false;

            currentPosition.x = _startXPosition;
            transform.position = currentPosition;

            _pipeManager.EnqueuePipeToWaitQueue(this.gameObject);
        }
    }
}
