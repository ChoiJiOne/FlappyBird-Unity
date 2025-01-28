using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ���� ������ ������Ʈ�� �����մϴ�.
/// </summary>
public class PipeManager : MonoBehaviour
{
    /// <summary>
    /// �������� �̵� �ӷ��� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public float MoveSpeed
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    /// <summary>
    /// �������� ������ ������Ʈ�Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject _pipePrefab;

    /// <summary>
    /// ������ �� ��ġ�� X��ǥ ���Դϴ�.
    /// </summary>
    [SerializeField]
    private float _endXPosition;

    /// <summary>
    /// �������� �̵� �ӵ��Դϴ�.
    /// </summary>
    private float _moveSpeed;

    /// <summary>
    /// ������ �Ŵ����� �����ϴ� �������� �����Դϴ�.
    /// </summary>
    [SerializeField]
    private int _pipeCount;

    /// <summary>
    /// ��� ���� ������ ������Ʈ�� ť�Դϴ�.
    /// </summary>
    private Queue<GameObject> _waitPipeObjects;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
}
