using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �÷��� �� ���� ������ ������Ʈ�� �����մϴ�.
/// </summary>
public class PipeController : MonoBehaviour
{
    /// <summary>
    /// �������� ������ ���θ� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public bool Movable
    {
        get { return _canMove;  }
        set { _canMove = value; }
    }

    /// <summary>
    /// �������� �̵� �ӵ��Դϴ�.
    /// </summary>
    [SerializeField]
    private float _moveSpeed;

    /// <summary>
    /// �������� ������ �� �ִ��� Ȯ���մϴ�.
    /// </summary>
    /// <remarks>
    /// ������ ������Ʈ�� ������ �� �ִٸ� true, �׷��� ������ false�Դϴ�.
    /// </remarks>
    private bool _canMove = true;

    private void Start()
    {
        
    }

    private void Update()
    {
    }
}
