using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �������� �������� �����մϴ�.
/// </summary>
public class PipeController : MonoBehaviour
{
    /// <summary>
    /// �������� �������� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public bool Movable
    {
        get { return _canMove; }
        set { _canMove = value; }
    }

    /// <summary>
    /// �������� ������ �����Դϴ�.
    /// </summary>
    private bool _canMove = false;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }
}
