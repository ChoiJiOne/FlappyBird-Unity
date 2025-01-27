using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� �������� �����մϴ�.
/// </summary>
public class PipeController : MonoBehaviour
{    
    /// <summary>
    /// �������� �̵� �ӵ��� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public float Speed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    /// <summary>
    /// �������� �������� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public bool Movable
    {
        get { return _canMove; }
        set { _canMove = value; }
    }
    
    /// <summary>
    /// �������� �̵� �ӵ��Դϴ�.
    /// </summary>
    private float _moveSpeed = 0.0f;

    /// <summary>
    /// �������� ������ �����Դϴ�.
    /// </summary>
    private bool _canMove = false;

    /// <summary>
    /// ������ ������ ������Ʈ�鿡 �浹 �̺�Ʈ�� �����մϴ�.
    /// </summary>
    private void Start()
    {
    }

    /// <summary>
    /// �������� ������ �� �ִٸ� ���ʿ��� ���������� �̵��մϴ�.
    /// </summary>
    private void Update()
    {
        if (!_canMove)
        {
            return;
        }

        Vector2 currentPosition = transform.position;

        currentPosition.x -= Time.deltaTime * 5.0f;

        transform.position = currentPosition;
    }
}
