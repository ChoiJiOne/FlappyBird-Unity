using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 백그라운드를 제어하는 오브젝트입니다.
/// </summary>
/// <remarks>
/// 이 오브젝트는 세팅 씬의 'DAY'와 'NIGHT' 버튼과 함께 동작합니다.
/// </remarks>
public class BackgroundContoller : MonoBehaviour
{
    /// <summary>
    /// 백그라운드 오브젝트입니다.
    /// </summary>
    private Background _background;

    /// <summary>
    /// 첫 프레임이 시작되기 전에 호출합니다.
    /// </summary>
    void Start()
    {
        GameObject background = GameObject.Find("Background");
        _background = background.GetComponent<Background>();
    }

    /// <summary>
    /// 세팅 씬의 'DAY' 버튼을 클릭했을 때 수행할 동작입니다.
    /// </summary>
    public void OnClickDay()
    {
        if (Background.Day)
        {
            return;
        }

        Background.Day = true;
        _background.ApplySprite();
    }

    /// <summary>
    /// 세팅 씬의 'NIGHT' 버튼을 클릭했을 때 수행할 동작입니다.
    /// </summary>
    public void OnClickNight()
    {
        if (!Background.Day)
        {
            return;
        }

        Background.Day = false;
        _background.ApplySprite();
    }
}
