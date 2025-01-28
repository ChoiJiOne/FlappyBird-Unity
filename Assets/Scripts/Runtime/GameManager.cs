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

    private void Awake()
    {
        
    }
}
