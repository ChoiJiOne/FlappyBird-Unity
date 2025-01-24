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
    /// ��� ��������Ʈ �������� ������ �������Դϴ�.
    /// </summary>
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// ��������Ʈ �������� �����մϴ�.
    /// </summary>
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
