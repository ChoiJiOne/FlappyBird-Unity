using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���ھ� UI�� �����մϴ�.
/// </summary>
/// <remarks>
/// �̶�, �������� �ӷ��� �ð� ������ �����մϴ�.
/// ���� ��� 2�ʶ�� �����ϸ� ������ ��ġ���� 2�ʵ��� �̵��մϴ�.
/// </remarks>
public class ScoreUIController : MonoBehaviour
{
    /// <summary>
    /// UI�� �� Ʈ�������Դϴ�.
    /// </summary>
    private RectTransform _rectTransform;

    /// <summary>
    /// UI�� �̵� �ð��Դϴ�.
    /// </summary>
    /// <remarks>
    /// �ð��� ������ �� �����Դϴ�.
    /// </remarks>
    [SerializeField]
    private float _moveTime;

    /// <summary>
    /// UI�� ���� ��ġ�Դϴ�.
    /// </summary>
    private Vector2 _startPosition;

    /// <summary>
    /// UI�� ���� ��ġ�Դϴ�.
    /// </summary>
    [SerializeField]
    private Vector2 _endPosition;

    /// <summary>
    /// UI�� �̵��ϴ� ���� ������ �ð� ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// �� ���� _moveTime ���� �Ѿ �� �����ϴ�.
    /// </remarks>
    private float _moveStepTime = 0.0f;

    /// <summary>
    /// UI�� ���� ��ġ�� �ִ��� Ȯ���մϴ�.
    /// </summary>
    private bool _isAtDestination = false;

    /// <summary>
    /// UI�� �� Ʈ���� ���� ���� ��ġ�� �ʱ�ȭ�մϴ�.
    /// </summary>
    void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = _rectTransform.anchoredPosition;
    }

    /// <summary>
    /// UI�� ������ ��ġ�� �̵���ŵ�ϴ�.
    /// </summary>
    void Update()
    {
        if (_moveStepTime >= _moveTime)
        {
            return;
        }

        _moveStepTime += Time.deltaTime;

        float t = _moveStepTime / _moveTime;
        Vector2 newPosition = (1.0f - t) * _startPosition + t * _endPosition;

        _rectTransform.anchoredPosition = newPosition;
    }
}
