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
    /// 타이틀이 움직이는 거리입니다.
    /// </summary>
    [SerializeField]
    private float _moveLength;

    /// <summary>
    /// 타이틀이 움직이는 초 단위 시간 값입니다.
    /// </summary>
    /// <remarks>
    /// 움직이는 시간은 위 방향으로 출발해서 원래 위치로 돌아오는 시간입니다.
    /// </remarks>
    [SerializeField]
    private float _moveTime;

    /// <summary>
    /// 타이틀의 누적 시간 값입니다.
    /// </summary>
    /// <remarks>
    /// 누적 시간 값은 _moveTime를 넘을 수 없습니다.
    /// </remarks>
    private float _currentStepTime = 0.0f;

    /// <summary>
    /// 타이틀 UI의 랙 트랜스폼 참조 값을 설정하고 움직일 때 기준 위치를 지정합니다.
    /// </summary>
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _moveBasePosition = _rectTransform.anchoredPosition;
    }

    /// <summary>
    /// 타이틀이 포물선 운동을 수행하도록 위치를 업데이트합니다.
    /// </summary>
    /// <remarks>
    /// 포물선 운동의 식은 다음과 같습니다.
    /// 시간 t에 대하여 움직일 때, a초만큼 최대 h 움직일 때,
    /// y = (4 * h / a^2) * t * (a - t)
    /// 아래의 코드에서 constant가 (4 * h / a^2)를 계산한 것입니다.
    /// </remarks>
    private void Update()
    {
        _currentStepTime += Time.deltaTime;
        if (_currentStepTime > _moveTime)
        {
            _currentStepTime -= _moveTime;
        }

        float constant = (4.0f * _moveLength) / (_moveTime * _moveTime);

        Vector2 newMovePosition = _moveBasePosition;
        newMovePosition.y += constant * _currentStepTime * (_moveTime - _currentStepTime);

        _rectTransform.anchoredPosition = newMovePosition;
    }
}
