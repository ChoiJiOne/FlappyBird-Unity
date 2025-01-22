using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Background : MonoBehaviour
{
    /// <summary>
    /// �������� Ʈ�������Դϴ�. ��׶����� ������ ���� �����ϱ� ���� ��� �����Դϴ�.
    /// </summary>
    private Transform _transform;

    /// <summary>
    /// ��׶��尡 �������� ��������Ʈ�� ������ ��������Ʈ �������Դϴ�.
    /// </summary>
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// ����� ������ ������ Ȯ���մϴ�. ���̶�� true, ���̶�� false�Դϴ�.
    /// </summary>
    private bool _isDay;

    /// <summary>
    /// '��' ��׶��尡 ��������Ʈ�Դϴ�.
    /// </summary>
    private Sprite _dayBackground;

    /// <summary>
    /// '��' ��׶��� ��������Ʈ�Դϴ�.
    /// </summary>
    private Sprite _nightBackground;

    /// <summary>
    /// ù �������� ���۵Ǳ� ���� ȣ���մϴ�.
    /// </summary>
    void Start()
    {
        _isDay = true;
        _dayBackground = Resources.Load<Sprite>("Sprite/background_day");
        _nightBackground = Resources.Load<Sprite>("Sprite/background_night");
        _transform = GetComponent<Transform>();
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
