using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 백그라운드 스프라이트를 제어합니다.
/// </summary>
/// <remarks>
/// 이 스크립트는 씬 내의 백그라운드 오브젝트와 함께 동작합니다.
/// </remarks>
public class BackgroundSpriteController : MonoBehaviour
{
    /// <summary>
    /// 배경의 낮/밤을 설정하는 프로퍼티입니다.
    /// </summary>
    public static bool Day
    {
        get { return s_isDay; }
        set { s_isDay = value; }
    }

    /// <summary>
    /// 배경 스프라이트 렌더링을 수행할 렌더러입니다.
    /// </summary>
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// 배경이 낮인지 확인합니다.
    /// </summary>
    /// <remarks>
    /// 배경이 낮이라면 true, 밤이라면 false입니다.
    /// </remarks>
    private static bool s_isDay;

    /// <summary>
    /// 낮 배경의 스프라이트입니다.
    /// </summary>
    private static Sprite s_daySprite;

    /// <summary>
    /// 밤 배경의 스프라이트입니다.
    /// </summary>
    private static Sprite s_nightSprite;

    /// <summary>
    /// 플레이어의 배경이 낮인지 확인하는 키 값입니다.
    /// </summary>
    private static string s_isDayKey = "IsDay";

    /// <summary>
    /// 스프라이트 렌더러와 낮/밤 배경의 스프라이트를 초기화합니다.
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
    /// 오브젝트가 파괴되기 전에 배경 변경 사항을 저장합니다.
    /// </summary>
    private void OnDestroy()
    {
        int daySelectValue = s_isDay ? 0 : 1;
        PlayerPrefs.SetInt(s_isDayKey, daySelectValue);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 백그라운드의 스프라이트 변경 사항을 적용합니다.
    /// </summary>
    /// <remarks>
    /// 외부에서 BackgroundSpriteController.Day 를 이용해서 값을 변경했다면, 이 메서드를 반드시 호출해야 변경 사항이 적용됩니다.
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
