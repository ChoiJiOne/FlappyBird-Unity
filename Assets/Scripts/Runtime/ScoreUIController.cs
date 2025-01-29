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
    /// �÷��̾��� ���ھ ǥ���ϴ� �ؽ�Ʈ UI�Դϴ�.
    /// </summary>
    [SerializeField]
    private GameObject _playerScoreUI;
    
    /// <summary>
    /// UI�� �� Ʈ���� ���� ���� ��ġ�� �ʱ�ȭ�մϴ�.
    /// </summary>
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _startPosition = _rectTransform.anchoredPosition;
    }

    /// <summary>
    /// UI�� ������ ��ġ�� �̵���ŵ�ϴ�.
    /// </summary>
    private void Update()
    {
        MoveScoreBoard();
    }

    /// <summary>
    /// ���ھ� ���带 �̵���ŵ�ϴ�.
    /// </summary>
    private void MoveScoreBoard()
    {
        // �����ߴٸ� �ƹ� ���۵� �������� ����.
        if (_isAtDestination)
        {
            return;
        }

        _moveStepTime += Time.deltaTime;
        if (_moveStepTime >= _moveTime)
        {
            _isAtDestination = true;
        }

        float t = Mathf.Clamp01(_moveStepTime / _moveTime);
        Vector2 newPosition = Vector2.Lerp(_startPosition, _endPosition, t);

        _rectTransform.anchoredPosition = newPosition;
    }
}
