using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ��׶��� ��������Ʈ�� �����մϴ�.
/// </summary>
/// <remarks>
/// �� ��ũ��Ʈ�� �� ���� ��׶��� ������Ʈ�� �Բ� �����մϴ�.
/// </remarks>
public class BackgroundSpriteController : MonoBehaviour
{
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
    /// �� ����� ��������Ʈ�Դϴ�.
    /// </summary>
    private static Sprite _daySprite;

    /// <summary>
    /// �� ����� ��������Ʈ�Դϴ�.
    /// </summary>
    private static Sprite _nightSprite;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
