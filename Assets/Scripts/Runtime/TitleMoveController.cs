using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� �� Ÿ��Ʋ�� �������� �����մϴ�.
/// </summary>
public class TitleMoveController : MonoBehaviour
{
    /// <summary>
    /// Ÿ��Ʋ UI�� �� Ʈ�������Դϴ�.
    /// </summary>
    /// <remakrs>
    /// Ÿ��Ʋ �� Ʈ�������� ��Ŀ(Anchors)�� Canvas �������� center/middle �Դϴ�.
    /// </remakrs>
    private RectTransform _rectTransform;

    /// <summary>
    /// Ÿ��Ʋ�� ������ �� ������ �Ǵ� ��ġ�Դϴ�.
    /// </summary>
    private Vector2 _moveBasePosition;

    /// <summary>
    /// Ÿ��Ʋ�� �����̴� �Ÿ��Դϴ�.
    /// </summary>
    private float _moveLength = 30.0f;

    /// <summary>
    /// Ÿ��Ʋ�� �����̴� �� ���� �ð� ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// �����̴� �ð��� �� �������� ����ؼ� ���� ��ġ�� ���ƿ��� �ð��Դϴ�.
    /// </remarks>
    private float _moveTime = 1.0f;

    /// <summary>
    /// Ÿ��Ʋ�� ���� �ð� ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// ���� �ð� ���� _moveTime�� ���� �� �����ϴ�.
    /// </remarks>
    private float _currentStepTime;
    
    /// <summary>
    /// �� Ʈ�������� Ÿ��Ʋ�� ������ �� ������ �Ǵ� ��ġ ���� �����մϴ�.
    /// </summary>
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _moveBasePosition = _rectTransform.anchoredPosition;
    }

    /// <summary>
    /// Ÿ��Ʋ�� ������ ��� �ϵ��� ������Ʈ�մϴ�.
    /// </summary>
    /// <remarks>
    /// ������ ��� ���� ������ �����ϴ�.
    /// �ð� t�� ���Ͽ� ������ ��, a�ʸ�ŭ �ִ� h ������ ��,
    /// y = (4 * h / a^2) * t * (a - t)
    /// �Ʒ��� �ڵ忡�� constant�� (4 * h / a^2)�� ����� ���Դϴ�.
    /// </remarks>
    void Update()
    {
        _currentStepTime += Time.deltaTime;
        if(_currentStepTime > _moveTime)
        {
            _currentStepTime -= _moveTime;
        }

        float constant = (4.0f * _moveLength) / (_moveTime * _moveTime);

        Vector2 newMovePosition = _moveBasePosition;
        newMovePosition.y += constant * _currentStepTime * (_moveTime - _currentStepTime);

        _rectTransform.anchoredPosition = newMovePosition;
    }
}
