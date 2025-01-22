using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class Background : MonoBehaviour
{
    /// <summary>
    /// 백그라운드의 낮-밤을 설정하는 프로퍼티입니다.
    /// </summary>
    public bool Day
    {
        get { return _isDay; }
        set { _isDay = value; }
    }

    /// <summary>
    /// 백그라운드가 렌더링할 스프라이트를 설정할 스프라이트 렌더러입니다.
    /// </summary>
    private SpriteRenderer _spriteRenderer;

    /// <summary>
    /// 배경이 낮인지 밤인지 확인합니다. 낮이라면 true, 밤이라면 false입니다.
    /// </summary>
    private bool _isDay;

    /// <summary>
    /// '낮' 백그라운드가 스프라이트입니다.
    /// </summary>
    private Sprite _dayBackground;

    /// <summary>
    /// '밤' 백그라운드 스프라이트입니다.
    /// </summary>
    private Sprite _nightBackground;

    /// <summary>
    /// 첫 프레임이 시작되기 전에 호출합니다.
    /// </summary>
    void Start()
    {
        _isDay = true;
        _dayBackground = Resources.Load<Sprite>("Sprite/background_day");
        _nightBackground = Resources.Load<Sprite>("Sprite/background_night");
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
    /// 매 프레임 한 번 호출합니다.
    /// </summary>
    void Update()
    {
    }
}
