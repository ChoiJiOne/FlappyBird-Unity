using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��׶����� ��������Ʈ�� �����մϴ�.
/// </summary>
/// <remarks>
/// �� ��ũ��Ʈ�� �� ���� ��׶��� ������Ʈ�� �Բ� �����մϴ�.
/// </remarks>
public class BgSpriteController : MonoBehaviour
{
    /// <summary>
    /// ����� ��-���� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public static bool Day
    {
        get { return _isDay;  }
        set { _isDay = value; }
    }

    /// <summary>
    /// ��� ��������Ʈ �������� ������ �������Դϴ�.
    /// </summary>
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// ����� ������ Ȯ���մϴ�.
    /// </summary>
    /// <remarks>
    /// ����� ���̶�� true, ���̶�� false�Դϴ�.
    /// </remarks>
    private static bool _isDay = true;

    /// <summary>
    /// ��������Ʈ �������� �����մϴ�.
    /// </summary>
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
