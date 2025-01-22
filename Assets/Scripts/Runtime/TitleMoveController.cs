using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� ���� Ÿ��Ʋ�� �����Դϴ�.
/// </summary>
[ExecuteAlways]
public class TitleMoveController : MonoBehaviour
{
    /// <summary>
    /// Ÿ��Ʋ�� �� Ʈ�������Դϴ�.
    /// </summary>
    /// <remarks>
    /// Ÿ��Ʋ �� Ʈ�������� ��Ŀ(Anchors)�� Canvas �������� center/middle �Դϴ�.
    /// </remarks>
    private RectTransform _rectTransform;

    /// <summary>
    /// Ÿ��Ʋ�� ������ �� ������ �Ǵ� ��ġ�Դϴ�.
    /// </summary>
    private Vector2 _moveBasePosition;

    /// <summary>
    /// Ÿ��Ʋ�� ������ ���� �����Դϴ�.
    /// </summary>
    public float _moveHeight;

    /// <summary>
    /// Ÿ��Ʋ�� �����̴� �ð� ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// �����̴� �ð��� ���� �����̱� �����ؼ� ���� ��ġ�� ���ƿ��� �ð��Դϴ�.
    /// </remarks>
    public float _moveTime;

    /// <summary>
    /// Ÿ��Ʋ�� ���� �ð� ���Դϴ�.
    /// </summary>
    /// <remarks>
    /// �� ���� �ð� ���� _moveTime�� �Ѿ �� �����ϴ�.
    /// </remarks>
    private float _currentStepTime;

    /// <summary>
    /// ù �������� ���۵Ǳ� ���� ȣ���մϴ�.
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
    /// �Ʒ��� �ڵ忡�� constant�� (4 * h / a^2)�� ����� ����.
    /// </remarks>
    void Update()
    {
        // ���ø����̼��� �������� �ƴ϶��, �ƹ����۵� �������� ����.
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
