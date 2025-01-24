using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 백그라운드의 스프라이트를 제어합니다.
/// </summary>
/// <remarks>
/// 이 스크립트는 씬 내의 백그라운드 오브젝트와 함께 동작합니다.
/// </remarks>
public class BgSpriteController : MonoBehaviour
{
    /// <summary>
    /// 배경의 낮-밤을 설정하는 프로퍼티입니다.
    /// </summary>
    public static bool Day
    {
        get { return _isDay;  }
        set { _isDay = value; }
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
    private static bool _isDay = true;

    /// <summary>
    /// 스프라이트 렌더러를 설정합니다.
    /// </summary>
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
