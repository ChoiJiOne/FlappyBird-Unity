using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 시작 씬의 타이틀을 움직입니다.
/// </summary>
[ExecuteInEditMode]
public class TitleMoveController : MonoBehaviour
{
    /// <summary>
    /// 타이틀의 랙 트랜스폼입니다.
    /// </summary>
    /// <remarks>
    /// 타이틀 랙 트랜스폼의 앵커(Anchors)는 Canvas 기준으로 center/middle 입니다.
    /// </remarks>
    private RectTransform _rectTransform;

    /// <summary>
    /// 타이틀이 움직일 때 기준이 되는 위치입니다.
    /// </summary>
    private Vector2 _moveBasePosition;

    /// <summary>
    /// 타이틀이 움직일 때의 높이입니다.
    /// </summary>
    public float _moveHeight;

    /// <summary>
    /// 첫 프레임이 시작되기 전에 호출합니다.
    /// </summary>
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _moveBasePosition = _rectTransform.anchoredPosition;
    }

    /// <summary>
    /// 매 프레임 한 번 호출합니다.
    /// </summary>
    void Update()
    {
        
    }
}
