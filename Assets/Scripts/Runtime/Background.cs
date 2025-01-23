using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

/// <summary>
/// �ΰ��� ��׶��带 �����մϴ�.
/// </summary>
public class Background : MonoBehaviour
{
    /// <summary>
    /// ��׶����� ��-���� �����ϴ� ������Ƽ�Դϴ�.
    /// </summary>
    public static bool Day
    {
        get { return _isDay; }
        set { _isDay = value; }
    }

    /// <summary>
    /// ��׶��尡 �������� ��������Ʈ�� ������ ��������Ʈ �������Դϴ�.
    /// </summary>
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// ����� ������ ������ Ȯ���մϴ�. ���̶�� true, ���̶�� false�Դϴ�.
    /// </summary>
    private static bool _isDay;

    /// <summary>
    /// '��' ��׶��尡 ��������Ʈ�Դϴ�.
    /// </summary>
    private static Sprite _dayBackground;

    /// <summary>
    /// '��' ��׶��� ��������Ʈ�Դϴ�.
    /// </summary>
    private static Sprite _nightBackground;

    /// <summary>
    /// ù �������� ���۵Ǳ� ���� ȣ���մϴ�.
    /// </summary>
    void Start()
    {
        _isDay = true;

        if (_dayBackground == null)
        {
            _dayBackground = Resources.Load<Sprite>("Sprite/Day");
        }

        if (_nightBackground == null)
        {
            _nightBackground = Resources.Load<Sprite>("Sprite/Night");
        }

        _spriteRenderer = GetComponent<SpriteRenderer>();
        if (_isDay)
        {
            _spriteRenderer.sprite = _dayBackground;
        }
        else
        {
            _spriteRenderer.sprite = _nightBackground;
        }
    }

    /// <summary>
    /// �� ������ �� �� ȣ���մϴ�.
    /// </summary>
    void Update()
    {
    }
}
