using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// UI�� �������� �����մϴ�.
/// </summary>
public class UIMoveController : MonoBehaviour
{
    /// <summary>
    /// UI�� �̵� �ð��Դϴ�.
    /// </summary>
    /// <remarks>
    /// �ð��� ������ �� �����Դϴ�.
    /// </remarks>
    [SerializeField]
    private float _moveTime;

    /// <summary>
    /// UI�� ���� ��ġ�Դϴ�.
    /// </summary>
    private Vector2 _startPosition;

    /// <summary>
    /// UI�� ���� ��ġ�Դϴ�.
    /// </summary>
    [SerializeField]
    private Vector2 _endPosition;

    /// <summary>
    /// UI�� �̵��ϴ� ���� ������ �ð� ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// �� ���� _moveTime ���� �Ѿ �� �����ϴ�.
    /// </remarks>
    private float _moveStepTime = 0.0f;

    /// <summary>
    /// UI�� ��ġ�� 
    /// </summary>
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
