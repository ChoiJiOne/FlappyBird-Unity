using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �÷��� �� ���� ���� �� �� �̺�Ʈ�� �����մϴ�.
/// </summary>
public class GameManager : MonoBehaviour
{
    /// <summary>
    /// ���� ���� �̵� �ӷ� ���� ���� ������Ƽ�Դϴ�.
    /// </summary>
    /// <remarks>
    /// �ܺο����� ������ �� ������ Getter�� �����մϴ�.
    /// </remarks>
    public float MoveSpeed
    {
        get { return _moveSpeed; }
    }

    /// <summary>
    /// ���� ���� �̵� �ӷ� ���Դϴ�
    /// </summary>
    [SerializeField]
    private float _moveSpeed;

    /// <summary>
    /// ���� ���� �׶��� ������Ʈ�Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject _ground;

    /// <summary>
    /// ���� ���� ������ ������Ʈ�� �����ϴ� �Ŵ����Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject _pipeManager;

    /// <summary>
    /// �׶����� �ӷ� ���� �����մϴ�.
    /// </summary>
    private void Awake()
    {
        GroundController groundController = _ground.GetComponent<GroundController>();
        groundController.MoveSpeed = _moveSpeed;
    }
}
