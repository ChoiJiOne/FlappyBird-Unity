using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 백그라운드 전환을 수행합니다.
/// </summary>
public class BgSwitchController : MonoBehaviour
{
    /// <summary>
    /// 백그라운드의 스프라이트를 관리합니다.
    /// </summary>
    private BgSpriteController _bgSpriteController;

    /// <summary>
    /// 백그라운드의 스프라이트 관리 오브젝트를 초기화합니다.
    /// </summary>
    private void Awake()
    {
        GameObject background = GameObject.Find("Background");
        _bgSpriteController = background.GetComponent<BgSpriteController>();
    }
}
