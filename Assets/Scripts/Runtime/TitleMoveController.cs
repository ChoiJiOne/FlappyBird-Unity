using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 시작 씬 타이틀의 움직임을 제어합니다.
/// </summary>
public class TitleMoveController : MonoBehaviour
{
    /// <summary>
    /// 타이틀 UI의 랙 트랜스폼입니다.
    /// </summary>
    /// <remakrs>
    /// 타이틀 랙 트랜스폼의 앵커(Anchors)는 Canvas 기준으로 center/middle 입니다.
    /// </remakrs>
    private RectTransform _rectTransform;

    /// <summary>
    /// 타이틀이 움직일 때 기준이 되는 위치입니다.
    /// </summary>
    private Vector2 _moveBasePosition;

    /// <summary>
    /// 랙 트랜스폼과 타이틀이 움직일 때 기준이 되는 위치 값을 설정합니다.
    /// </summary>
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _moveBasePosition = _rectTransform.anchoredPosition;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
