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
        get { return s_isDay; }
        set { s_isDay = value; }
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
    private static bool s_isDay;

    /// <summary>
    /// �� ����� ��������Ʈ�Դϴ�.
    /// </summary>
    private static Sprite s_daySprite;

    /// <summary>
    /// �� ����� ��������Ʈ�Դϴ�.
    /// </summary>
    private static Sprite s_nightSprite;

    /// <summary>
    /// �÷��̾��� ����� ������ Ȯ���ϴ� Ű ���Դϴ�.
    /// </summary>
    private static string s_isDayKey = "IsDay";

    /// <summary>
    /// ��������Ʈ �������� ��/�� ����� ��������Ʈ�� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (PlayerPrefs.HasKey(s_isDayKey))
        {
            int daySelectValue = PlayerPrefs.GetInt(s_isDayKey);
            s_isDay = (daySelectValue == 0);
        }

        if (s_daySprite == null)
        {
            s_daySprite = Resources.Load<Sprite>("Sprites/Day");
        }

        if (s_nightSprite == null)
        {
            s_nightSprite = Resources.Load<Sprite>("Sprites/Night");
        }

        if (s_isDay)
        {
            _spriteRenderer.sprite = s_daySprite;
        }
        else
        {
            _spriteRenderer.sprite = s_nightSprite;
        }
    }

    /// <summary>
    /// ������Ʈ�� �ı��Ǳ� ���� ��� ���� ������ �����մϴ�.
    /// </summary>
    private void OnDestroy()
    {
        int daySelectValue = s_isDay ? 0 : 1;
        PlayerPrefs.SetInt(s_isDayKey, daySelectValue);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// ��׶����� ��������Ʈ ���� ������ �����մϴ�.
    /// </summary>
    /// <remarks>
    /// �ܺο��� BackgroundSpriteController.Day �� �̿��ؼ� ���� �����ߴٸ�, �� �޼��带 �ݵ�� ȣ���ؾ� ���� ������ ����˴ϴ�.
    /// </remarks>
    public void ApplySprite()
    {
        if (s_isDay)
        {
            _spriteRenderer.sprite = s_daySprite;
        }
        else
        {
            _spriteRenderer.sprite = s_nightSprite;
        }
    }
}
