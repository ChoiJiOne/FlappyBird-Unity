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
    /// ����� ��/���� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public static bool Day
    {
        get { return _isDay; }
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
    /// �� ����� ��������Ʈ�Դϴ�.
    /// </summary>
    private static Sprite s_daySprite;

    /// <summary>
    /// �� ����� ��������Ʈ�Դϴ�.
    /// </summary>
    private static Sprite s_nightSprite;

    /// <summary>
    /// ��������Ʈ �������� ��/�� ����� ��������Ʈ�� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        if (s_daySprite == null)
        {
            s_daySprite = Resources.Load<Sprite>("Sprites/Day");
        }

        if (s_nightSprite == null)
        {
            s_nightSprite = Resources.Load<Sprite>("Sprites/Night");
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_isDay)
        {
            _spriteRenderer.sprite = s_daySprite;
        }
        else
        {
            _spriteRenderer.sprite = s_nightSprite;
        }
    }

    /// <summary>
    /// ��׶����� ��������Ʈ ���� ������ �����մϴ�.
    /// </summary>
    /// <remarks>
    /// �ܺο��� BackgroundSpriteController.Day �� �̿��ؼ� ���� �����ߴٸ�, �� �޼��带 �ݵ�� ȣ���ؾ� ���� ������ ����˴ϴ�.
    /// </remarks>
    public void ApplySprite()
    {
        if (_isDay)
        {
            _spriteRenderer.sprite = s_daySprite;
        }
        else
        {
            _spriteRenderer.sprite = s_nightSprite;
        }
    }
}
