using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 시작 씬의 타이틀을 움직입니다.
/// </summary>
[ExecuteAlways]
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
    /// 타이틀이 움직이는 시간 값입니다.
    /// </summary>
    /// <remarks>
    /// 움직이는 시간은 위로 움직이기 시작해서 원래 위치로 돌아오는 시간입니다.
    /// </remarks>
    public float _moveTime;

    /// <summary>
    /// 타이틀의 누적 시간 값입니다.
    /// </summary>
    /// <remarks>
    /// 이 누적 시간 값은 _moveTime을 넘어설 수 없습니다.
    /// </remarks>
    private float _currentStepTime;

    /// <summary>
    /// 첫 프레임이 시작되기 전에 호출합니다.
    /// </summary>
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _moveBasePosition = _rectTransform.anchoredPosition;
    }

    /// <summary>
    /// 타이틀이 포물선 운동을 하도록 업데이트합니다.
    /// </summary>
    /// <remarks>
    /// 포물선 운동의 식은 다음과 같습니다.
    /// 시간 t에 대하여 움직일 때, a초만큼 최대 h 움직일 때,
    /// y = (4 * h / a^2) * t * (a - t)
    /// 아래의 코드에서 constant가 (4 * h / a^2)를 계산한 것임.
    /// </remarks>
    void Update()
    {
        // 애플리케이션이 실행중이 아니라면, 아무동작도 수행하지 않음.
        if(!Application.isPlaying)
        {
            return;
        }

        _currentStepTime += Time.deltaTime;
        if (_currentStepTime > _moveTime)
        {
            _currentStepTime -= _moveTime;
        }

        float constant = (4.0f * _moveHeight) / (_moveTime * _moveTime);

        Vector2 newMovePosition = _moveBasePosition;
        newMovePosition.y += constant * _currentStepTime * (_moveTime - _currentStepTime);

        _rectTransform.anchoredPosition = newMovePosition;
    }
}
