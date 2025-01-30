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

    /// <summary>
    /// ��������Ʈ �������� ��/�� ����� ��������Ʈ�� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        if (_daySprite == null)
        {
            _daySprite = Resources.Load<Sprite>("Sprites/Day");
        }

        if (_nightSprite == null)
        {
            _nightSprite = Resources.Load<Sprite>("Sprites/Night");
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_isDay)
        {
            _spriteRenderer.sprite = _daySprite;
        }
        else
        {
            _spriteRenderer.sprite = _nightSprite;
        }
    }

    void Update()
    {
        
    }
}
