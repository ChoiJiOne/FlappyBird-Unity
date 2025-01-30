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
    /// 배경 스프라이트 렌더링을 수행할 렌더러입니다.
    /// </summary>
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// 배경이 낮인지 확인합니다.
    /// </summary>
    /// <remarks>
    /// 배경이 낮이라면 true, 밤이라면 false입니다.
    /// </remarks>
    private static bool _isDay = true;

    /// <summary>
    /// 낮 배경의 스프라이트입니다.
    /// </summary>
    private static Sprite _daySprite;

    /// <summary>
    /// 밤 배경의 스프라이트입니다.
    /// </summary>
    private static Sprite _nightSprite;

    /// <summary>
    /// 스프라이트 렌더러와 낮/밤 배경의 스프라이트를 초기화합니다.
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
