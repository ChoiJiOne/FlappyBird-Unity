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

    /// <summary>
    /// DAY 버튼을 클릭했을 때의 동작입니다.
    /// </summary>
    /// <remarks>
    /// 만약, 백그라운드가 DAY로 설정되어 있다면 아무 동작도 수행하지 않습니다.
    /// </remarks>
    public void OnClickSwitchDayButton()
    {
        if (BgSpriteController.Day)
        {
            return;
        }

        SwitchBackgroundSprite();
    }

    /// <summary>
    /// NIGHT 버튼을 클릭했을 때의 동작입니다.
    /// </summary>
    /// <remarks>
    /// 만약, 백그라운드가 NIGHT로 설정되어 있다면 아무 동작도 수행하지 않습니다.
    /// </remarks>
    public void OnClickSwitchNightButton()
    {
        if (!BgSpriteController.Day)
        {
            return;
        }

        SwitchBackgroundSprite();
    }

    /// <summary>
    /// 백그라운드의 스프라이트를 반대로 전환합니다.
    /// </summary>
    /// <remarks>
    /// 낮(DAY)이라면 밤(NIGHT)으로 설정하고, 밤이면 낮으로 설정합니다.
    /// </remarks>
    private void SwitchBackgroundSprite()
    {
        BgSpriteController.Day = !BgSpriteController.Day;
        _bgSpriteController.ApplySprite();
    }
}
