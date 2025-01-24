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
    /// 배경 스프라이트 렌더링을 수행할 렌더러입니다.
    /// </summary>
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// 스프라이트 렌더러를 설정합니다.
    /// </summary>
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
}
