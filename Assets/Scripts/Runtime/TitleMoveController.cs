using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 시작 씬 내의 타이틀 UI 이동을 제어합니다.
/// </summary>
public class TitleMoveController : MonoBehaviour
{
    /// <summary>
    /// 타이틀 UI의 랙 트랜스폼입니다.
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
    /// 타이틀 UI의 랙 트랜스폼 참조 값을 설정하고 움직일 때 기준 위치를 지정합니다.
    /// </summary>
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _moveBasePosition = _rectTransform.anchoredPosition;
    }

    // Update is called once per frame
    private void Update()
    {
        
    }
}
